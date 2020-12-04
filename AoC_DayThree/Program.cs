using System;
using System.IO;
using System.Collections.Generic;

namespace AoC_DayThree
{
    class Program
    {
        static List<string> GetInput()
        {
            List<string> input = new List<string>();
            StreamReader reader = new StreamReader(@"C:\Users\mwlee\source\repos\AdventOfCode2020\AoC_DayThree\input.txt");

            while (!reader.EndOfStream)
            {
                input.Add(reader.ReadLine());
            }

            reader.Close();
            return input;
        }

        static int PartOne(List<string> input)
        {
            int currentIndex = 0;
            int treeCount = 0;
            bool test = false;

            foreach (string s in input)
            {
                if (test)
                {
                    test = false;
                    continue;
                }
                if (s[currentIndex] == '#') { treeCount += 1; }
                currentIndex += 1;
                if (currentIndex >= 31) { currentIndex -= 31; }
                test = true;
            }

            return treeCount;
        }

        // Slopes:
        // Right 1, Down 1
        // Right 3, Down 1
        // Right 5, Down 1
        // Right 7, Down 1
        // Right 1, Down 2
        static long PartTwo(List<string> input)
        {
            int[] slopes = new int[] { 1, 3, 5, 7, 1 };
            int currentIndex = 0;
            int treeCount = 0;
            long treeTotal = 1;

            List<int> treeList = new List<int>();

            for (int i = 0; i < slopes.Length; i++)
            {
                foreach (string s in input)
                {
                    if (i == 4 && input.IndexOf(s) % 2 == 1) { continue; }

                    if (s[currentIndex] == '#') { treeCount += 1; }
                    currentIndex += slopes[i];
                    if (currentIndex >= 31) { currentIndex -= 31; }
                }

                currentIndex = 0;
                Console.WriteLine("Tree count for slope {0}: {1}", i, treeCount);
                treeList.Add(treeCount);
                treeCount = 0;
            }

            foreach (int i in treeList)
            {
                treeTotal *= i;
            }
            return treeTotal;
        }

        static void Main(string[] args)
        {
            List<string> input = GetInput();

            Console.WriteLine("Tree Count Part One: " + PartOne(input));
            Console.WriteLine("Tree Multiplied Total Part Two: " + PartTwo(input));
            Console.ReadLine();
        }
    }
}
