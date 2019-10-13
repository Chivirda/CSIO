using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSIO
{
    class Program
    {
        static string first = "first.txt";
        static string second = "second.txt";
        static void Main(string[] args)
        {
            
            System.Console.Write("Введите длину файлов: ");
            var lengthOfFile = int.Parse(Console.ReadLine());

            #region Создание файлов
            createFiles(first, lengthOfFile);
            createFiles(second, lengthOfFile);
            System.Console.WriteLine("Записано!");
            #endregion

            #region Сортировка и запись файлов
            sortFiles(first);
            sortFiles(second);
            System.Console.WriteLine("Отсортировано!");
            #endregion

            createResult();
            System.Console.WriteLine("Готово!");


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

            Sort.bubbleSort(nums);

            using (var sw = new StreamWriter(nameOfFile, false, Encoding.UTF8))
            {
                for(int i = 0; i < nums.Count; i++)
                {
                    sw.WriteLine(nums[i]);
                }
            }

        }

        static void createFiles(string nameOfFile, int lengthOfFile)
        {
            using (var sw = new StreamWriter(nameOfFile, false, Encoding.UTF8))
            {
                var rand = new Random();
                for(int i = 0; i < lengthOfFile; i++)
                {
                    sw.WriteLine(rand.Next(1, 100));
                }
            }
        }

        static void createResult()
        {
            var resultFile = "result.txt";
            var firstList = grabFileToList(first);
            var secondList = grabFileToList(second);

            var resultList = new List<int>();
            resultList.AddRange(firstList);
            resultList.AddRange(secondList);

            Sort.bubbleSort(resultList);

            using (var sw = new StreamWriter(resultFile, false, Encoding.UTF8))
            {
                for(var i = 0; i < resultList.Count; i++)
                {
                    sw.WriteLine(resultList[i]);
                }
            }

        }

        static List<int> grabFileToList(string fileName)
        {
            var numList = new List<int>();
            using (var sr = new StreamReader(fileName, Encoding.UTF8))
            {
                while(!sr.EndOfStream)
                {
                    numList.Add(int.Parse(sr.ReadLine()));
                }
            }

            return numList;
        }
    }
}
