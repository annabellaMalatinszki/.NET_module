using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback callback = new WaitCallback(ShowMyText);
            ThreadPool.QueueUserWorkItem(callback, " Nothing");
            ThreadPool.QueueUserWorkItem(callback, " is");
            ThreadPool.QueueUserWorkItem(callback, " true,");
            ThreadPool.QueueUserWorkItem(callback, " everything");
            ThreadPool.QueueUserWorkItem(callback, " is");
            ThreadPool.QueueUserWorkItem(callback, " permitted.");

            Console.ReadKey();
        }

        private static void ShowMyText(Object state)
        {
            string txt = "State: " + (string)state;
            txt += " Thread: " + Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine(txt);
        }
    }
}
