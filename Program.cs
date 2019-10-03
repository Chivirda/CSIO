using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = "first.txt";
            var second = "second.txt";

            using (var sw = new StreamWriter(first, false, Encoding.UTF8))
            {
                var rand = new Random();
                for(int i = 0; i < 6; i++)
                {
                    sw.WriteLine(rand.Next(1, 50));
                }
            }

            using (var sw = new StreamWriter(second, false, Encoding.UTF8))
            {
                var rand = new Random();
                for(int i = 0; i < 6; i++)
                {
                    sw.WriteLine(rand.Next(50, 100));
                }
            }

            System.Console.WriteLine("Записано!");

            var firstNums = new List<int>();

            using (var sr = new StreamReader(first, Encoding.UTF8))
            {
                while(!sr.EndOfStream)
                {
                    firstNums.Add(int.Parse(sr.ReadLine()));
                }
            }

            firstNums.Sort();

            
        }
    }
}
