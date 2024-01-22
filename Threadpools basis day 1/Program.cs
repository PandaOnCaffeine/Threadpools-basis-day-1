using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Threadpools_basis_day_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunOpgThree();
            Console.ReadLine();
        }
        static void RunOpgOneAndTwo()
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");

            stopwatch.Start();
            ProcessWithThreadPoolMethod();
            stopwatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + stopwatch.ElapsedTicks.ToString());

            stopwatch.Reset();

            

            Console.WriteLine("Thread Execution");

            stopwatch.Start();
            ProcessWithThreadMethod();
            stopwatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + stopwatch.ElapsedTicks.ToString());
        }
        static void RunOpgThree()
        {
            Thread t = new Thread(() => Tester());

            Console.WriteLine(t.IsAlive); //Get a bool, true if thread is running, false if not
            Console.WriteLine(t.IsBackground); //Get a bool, true if background thread, false if not
            Console.WriteLine(t.Priority); //Get and set method, show thread priority

            t.Start(); //Starts thread
            Thread.Sleep(1000); //Suspends the thread for amount of milliseconds
            t.Suspend(); //Suspends the thread
            t.Resume(); //Resumes a suspended thread
            t.Abort(); //Terminates the thread, and shows a threadAbortException
            t.Join(); //wait for thread to finish the code its running, then terminates
        }
        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }
        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
        static void Process(object callback)
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {
                }
            }
        }
        static void Tester()
        {

        }
    }
}
