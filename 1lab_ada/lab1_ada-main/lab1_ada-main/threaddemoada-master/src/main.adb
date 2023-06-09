with Ada.Text_IO;
with Ada.Integer_Text_IO;
procedure Main is

   can_stop : array(1..5) of Boolean := (others => False);
   pragma Atomic (can_stop);
   coll_thread : Integer := 5;

   task type break_thread is
      entry Set (Value : Duration, Id : Integer);
   end break_thread;
   task type main_thread is
      entry Set (value : Long_Long_Integer, Id : Integer);
   end main_thread;

   task body break_thread is
      time : Duration;
      id :Integer;
   begin
      accept Set (value : in Duration, Id : in Integer) do
         begin
            time := value;
            id := Id;
         end;
      end Set;
      delay time;
      can_stop(id) := True;
   end break_thread;

   task body main_thread is
      step : Long_Long_Integer;
      col  : Long_Long_Integer := 0;
      sum  : Long_Long_Integer := 0;
      id : Integer;
   begin
      accept Set (value : in Long_Long_Integer, Id : in Integer) do
         begin
            step := value;
            id := Id;
         end;
      end Set;
      loop
         col := col + 1;
         sum := sum + col * step;
         exit when can_stop(id);
      end loop;
      Ada.Text_IO.Put_Line ("col- " & col'Img & " sum- " & sum'Img);
   end main_thread;
   S_D : array (1 .. 5) of Standard.Duration := (3.0, 2.0, 1.0, 1.5, 0.5);
   M   : array (1 .. coll_thread) of main_thread;
   S   : array (1 .. coll_thread) of break_thread;
   N   : array (1 .. coll_thread) of Long_Long_Integer := (1, 2, 3, 4, 5);
begin
   for I in M'Range loop
      M (I).Set(N(I), I);
      S (I).Set(S_D(I), I);

   end loop;

end Main;
