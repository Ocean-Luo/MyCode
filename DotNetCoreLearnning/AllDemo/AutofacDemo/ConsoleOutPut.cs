using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacDemo
{
    public class ConsoleOutPut:IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
