using System;
using System.Collections.Generic;
using System.IO;

namespace AoC_DayOne
{
    class Program
    {
        static List<int> getInput()
        {
            List<int> input = new List<int>();

            StreamReader reader = new StreamReader(@"C:\Users\mwlee\source\repos\AdventOfCode2020\AoC_DayOne\input.txt");

            while (reader.EndOfStream == false)
            {
                int inputValue = int.Parse(reader.ReadLine());

                input.Add(inputValue);
            }

            reader.Close();
            return input;
        }

        static int partOne(List<int> input)
        {
            int a;

            foreach (int i in input)
            {
                a = 2020 - i;
                if (input.Contains(a))
                {
                    Console.WriteLine("i: {0}, a: {1}, product: {2}", i, a, i * a);
                    return i * a;
                }
            }

            return -1;
        }

        static int partTwo(List<int> input)
        {
            int a;
            int b;

            foreach (int i in input)
            {
                foreach (int j in input)
                {
                    a = 2020 - i;
                    b = a - j;

                    if (input.Contains(j) && input.Contains(b))
                    {
                        Console.WriteLine("i: {0}, j: {1}, b: {2}", i, j, b);
                        return i * j * b;
                    }
                }
            }

            return -1;
        }

        static void Main(string[] args)
        {
            List<int> input = getInput();

            int solutionOne = partOne(input);
            int solutionTwo = partTwo(input);

            Console.WriteLine(solutionOne == -1 ? "No solution" : "Part One Solution: " + solutionOne.ToString());
            Console.WriteLine(solutionTwo == -1 ? "No solution" : "Part Two Solution: " + solutionTwo.ToString());

            Console.ReadLine();
        }
    }
}
