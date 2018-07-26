using System;
using EasyNetQ;
using Messages;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Receive<TextMesage>("message",(m)=> HandleTextMessage(m));

                Console.WriteLine("Listening for message.Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void HandleTextMessage(TextMesage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message:{0}", textMessage.Text);
            Console.ResetColor();
        }
    }
}
