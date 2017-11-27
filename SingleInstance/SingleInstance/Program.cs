using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            const string mutexName = "RUNMEONLYONCE";
            System.Threading.Mutex mutex = null;
            while (true)
            {
                try
                {
                    mutex = Mutex.OpenExisting(mutexName);
                    Console.WriteLine("Mutex found, exiting...");
                    mutex.Close();
                    break;
                }
                catch (WaitHandleCannotBeOpenedException)
                {
                    bool mutexIsMine = true;
                    mutex = new Mutex(mutexIsMine, mutexName); 
                    Console.WriteLine("Mutex not found, created.");
                }
            }

            //Checking if more than one instance of the application is running
            var exists = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1;
            Console.WriteLine(exists);

            Console.ReadKey();
        }
    }
}
