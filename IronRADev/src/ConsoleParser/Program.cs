using System;
using IronRADev;
namespace ConsoleParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var convert = new IronConvert();

            while (true)
            {
                Console.WriteLine(convert.DataReturn(convert.Parser(Console.ReadLine())));
            }
        }
    }
}
