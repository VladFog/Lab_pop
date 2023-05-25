using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BreakThread
    {
        private bool canBreak = false;
        private int time;

        public int getTime()
        {
            return time;
        }
        public void setTime(int value)
        {
            time = value;
        }
        public void Run()
        {
            Thread.Sleep(time);
            canBreak = true;
        }

        public bool isCanBreak()
        {
            return canBreak;
        }
    }
}
