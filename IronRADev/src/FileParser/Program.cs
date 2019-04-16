using System;
using System.IO;
namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter File Path");
            var filePath = Console.ReadLine();
            var newFilePath = filePath.Replace(".rad", ".cs");
            var buffer = new string[File.ReadAllLines(filePath).Length];
            int count = 0;
            string[] baseProg = { "class Program", "{", "static void Main(string[] args)", "{", "##Body", "}", "}" };
            var prog = String.Join(Environment.NewLine, baseProg);
            var convert = new IronRADev.IronConvert();
            foreach(string line in File.ReadAllLines(filePath))
            {
                buffer[count] = convert.StringReturn(line);
                count++;
            }
            var temp = String.Join(Environment.NewLine, buffer);
            prog = prog.Replace("##Body", temp);
            File.WriteAllText(newFilePath, prog);
        }
    }
}
