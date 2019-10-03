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
            System.Console.Write("Enter length of files: ");
            var lengthOfFile = int.Parse(Console.ReadLine());

            #region Создание файлов
            createFiles(first, lengthOfFile, 1, 50);
            createFiles(second, lengthOfFile, 50, 100);
            System.Console.WriteLine("Записано!");
            #endregion

            #region Сортировка и запись файлов
            sortFiles(first);
            sortFiles(second);
            System.Console.WriteLine("Отсортировано!");
            #endregion
        }

        static void sortFiles(string nameOfFile)
        {
            var nums = new List<int>();

            using (var sr = new StreamReader(nameOfFile, Encoding.UTF8))
            {
                while(!sr.EndOfStream)
                {
                    nums.Add(int.Parse(sr.ReadLine()));
                }
            }

            nums.Sort();

            using (var sw = new StreamWriter(nameOfFile, false, Encoding.UTF8))
            {
                for(int i = 0; i < nums.Count; i++)
                {
                    sw.WriteLine(nums[i]);
                }
            }

        }

        static void createFiles(string nameOfFile, int lengthOfFile, int min, int max)
        {
            using (var sw = new StreamWriter(nameOfFile, false, Encoding.UTF8))
            {
                var rand = new Random();
                for(int i = 0; i < lengthOfFile; i++)
                {
                    sw.WriteLine(rand.Next(min, max));
                }
            }
        }
    }
}
