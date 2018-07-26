using System;

namespace DelegateDemo
{
    class Program
    {
        public delegate void printDelegate();
        public static printDelegate method;

        public void print()
        {
            int a = 5;
            Console.WriteLine("请调用委托来执行");
        }

        public void useDelegate(printDelegate d)
        {
           
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            method = new printDelegate(p.print);
            p.useDelegate(method);
            Console.WriteLine("Hello World!");
            Console.Read();
        }
    }
}
