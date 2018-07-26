using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 5;
            for (int j = 0; j < 5; j++)
            {
                Task.Run(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        while (m < 10)
                        {
                            m++;
                            Thread.Sleep(1000);
                            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                        }
                    }
                });
            }
            Console.Read();
        }
    }
}
