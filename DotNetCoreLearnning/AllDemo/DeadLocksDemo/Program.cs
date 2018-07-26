using System;
using System.Threading;

namespace DeadLocksDemo
{
    class Program
    {
        public static object lock_A = new object();
        public static object lock_B = new object();
        public void DoSomething()
        {

            lock (lock_A)
            {
                Thread.Sleep(500);
                Console.WriteLine("我是lock_A,我想要lock_B");
                lock (lock_B)
                {
                    Console.WriteLine("没出现这句话表示死锁了");
                }
            }
        }

        static void Main()
        {
            Program a = new Program();
            Thread th = new Thread(new ThreadStart(a.DoSomething));
            th.Start();

            lock (lock_B)
            {

                Console.WriteLine("我是lock_B,我想要lock_A");
                lock (lock_A)
                {
                    Console.WriteLine("没出现这句话表示死锁了");
                }
            }

            Console.WriteLine("没出现这句话表示死锁了");
        }

    }

}
