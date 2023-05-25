using System.Threading;
using System;
using ConsoleApp1;

namespace ConsoleApp1
{
    class Program
    {
        static int[] timeBreakThread = new int[1];
        static int[] steps = new int[1];
        public static int collThread;
        static void Main(string[] args)
        {
            Console.WriteLine("Coll thread:");
            collThread = int.Parse(Console.ReadLine());
            timeBreakThread = new int[collThread];
            steps = new int[collThread];
            Console.WriteLine("Print time(ms) and step");
            for (int i = 0; i < collThread; i++)
            {
                Console.WriteLine("Thread " + (i) + ":");
                String[] line = Console.ReadLine().Trim().Split(" ");
                timeBreakThread[i] = int.Parse(line[0]);
                steps[i] = int.Parse(line[1]);
            }
            (new Program()).Start();
        }

        void Start()
        {
            for (int i = 0; i < collThread; i++)
            {
                BreakThread breakThread = new BreakThread();
                breakThread.setTime(timeBreakThread[i]);
                MainThread mainThread = new MainThread(i, breakThread, steps[i]);
                new Thread(mainThread.Run).Start();
                new Thread(breakThread.Run).Start();

            }
        }
        private bool[] canStop;

        public bool CanStop(int id)
        {
            return canStop[id];
        }
    }
}
