using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductoryTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 0, 2, 3, 9, 6, 1, 5, 7 };

            SortUtil.Sort(arr);

            PrintArray(arr);
            
            for (int i = -3; i < 12; i++)
            {
                Console.WriteLine($"i: {i}; etalon: {arr.ToList().BinarySearch(i)}; my: {BinarySearchUtil.BinarySearch(arr, i)}");
            }

            var singleWords = SingleWordsSearchUtil.GetSingleWords("word word word, gg, max, sonya!!! lol, lol");
            foreach (var s in singleWords)
                Console.WriteLine(s);

            Console.WriteLine(Int32.MaxValue);
            for (int i = 0; i < 13; i++)
                Console.WriteLine(FactorialUtil.GetFactorial(i));

            Console.WriteLine($"Correct bracket sequence: { BracketSequenceUtil.IsCorrect("({(()))}") }");
        }

        static void PrintArray<T>(T[] array)
        {
            foreach (var item in array)
                Console.Write($"{item} ");

            Console.WriteLine();
        }
    }
}
