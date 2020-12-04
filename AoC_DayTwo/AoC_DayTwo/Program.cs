using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC_DayTwo
{
    class PasswordPartOne
    {
        public PasswordPartOne(string input)
        {
            PolicyMin = int.Parse(input.Substring(0, input.IndexOf("-")));
            PolicyMax = int.Parse(input.Substring(input.IndexOf("-") + 1, input.IndexOf(":") - input.IndexOf("-") - 2));
            PolicyChar = input[input.IndexOf(":") - 1];
            UserPassword = input.Substring(input.IndexOf(":") + 1);
            IsValid = checkIsValid();
        }

        public int PolicyMin { get; set; }
        public int PolicyMax { get; set; }
        public char PolicyChar { get; set; }
        public bool IsValid { get; set; }
        public string UserPassword { get; set; }

        private bool checkIsValid()
        {
            var validChars = UserPassword.Where(c => c == PolicyChar);

            if (validChars.Count() >= PolicyMin && validChars.Count() <= PolicyMax) { return true; }
            else { return false; }
        }
    }

    class PasswordPartTwo
    {
        public PasswordPartTwo(string input)
        {
            PolicyLocationOne = int.Parse(input.Substring(0, input.IndexOf("-"))) - 1;
            PolicyLocationTwo = int.Parse(input.Substring(input.IndexOf("-") + 1, input.IndexOf(":") - input.IndexOf("-") - 2)) - 1;
            PolicyChar = input[input.IndexOf(":") - 1];
            UserPassword = input.Substring(input.IndexOf(":") + 1);
            IsValid = checkIsValid();
        }

        public int PolicyLocationOne { get; set; }
        public int PolicyLocationTwo { get; set; }
        public char PolicyChar { get; set; }
        public bool IsValid { get; set; }
        public string UserPassword { get; set; }

        private bool checkIsValid()
        {
            if ((UserPassword[PolicyLocationOne] == PolicyChar &&
                UserPassword[PolicyLocationTwo] != PolicyChar) ||
                (UserPassword[PolicyLocationTwo] == PolicyChar &&
                UserPassword[PolicyLocationOne] != PolicyChar)) 
            { return true; }
            else { return false; }
        }
    }

    class Program
    {
        static List<string> GetInput()
        {
            StreamReader reader = new StreamReader(@"C:\Users\mwlee\source\repos\AdventOfCode2020\AoC_DayTwo\AoC_DayTwo\input.txt");

            List<string> input = new List<string>();

            while (!reader.EndOfStream)
            {
                string cleanString = String.Concat(reader.ReadLine().Where(c => !Char.IsWhiteSpace(c)));
                input.Add(cleanString);
            }

            reader.Close();
            return input;
        }

        static void Main(string[] args)
        {
            List<string> input = GetInput();
            List<PasswordPartOne> passwordsPartOne = new List<PasswordPartOne>();
            List<PasswordPartTwo> passwordsPartTwo = new List<PasswordPartTwo>();

            int validPasswordPartOneCount = 0;
            int validPasswordPartTwoCount = 0;

            foreach (string s in input)
            {
                passwordsPartOne.Add(new PasswordPartOne(s));
                passwordsPartTwo.Add(new PasswordPartTwo(s));
            }
            foreach (PasswordPartOne p in passwordsPartOne)
            {
                if (p.IsValid) { validPasswordPartOneCount += 1; }
            }
            foreach (PasswordPartTwo p in passwordsPartTwo)
            {
                if (p.IsValid) { validPasswordPartTwoCount += 1; }
            }

            Console.WriteLine(validPasswordPartOneCount);
            Console.WriteLine(validPasswordPartTwoCount);
            Console.ReadLine();
        }
    }
}
