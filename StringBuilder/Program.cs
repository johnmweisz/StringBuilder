using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace StringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input a list of numbers separated by a -");
            var input = Console.ReadLine();
            Console.WriteLine(IsConsecutive(input));
            Console.WriteLine(IsDuplicate(input));

            Console.WriteLine("input a time in format HH:MM");
            input = Console.ReadLine();
            Console.WriteLine(ValidTime(input));

            Console.WriteLine("input words seperated by a space");
            input = Console.ReadLine();
            Console.WriteLine(PascalCase(input));
        }

        static string IsConsecutive(string input)
        {
            var number = Int32.MinValue;
            foreach (var item in input)
            {
                if (item != '-')
                {
                    if (Convert.ToInt32(item) < number)
                    {
                        return "Not Consecutive";
                    }
                    number = item;
                }
            }
            return "Consecutive";
        }

        static string IsDuplicate(string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return "No Input";
            HashSet<int> hash = new HashSet<int>();
            foreach (var charNum in input)
            {
                if (charNum != '-')
                {
                    if(!hash.Add(Convert.ToInt32(charNum))) return "Duplicate";
                }
            }
            return "No duplicates";
        }

        static string ValidTime(string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return "Invalid input";
            var checker = input.Split(':');
            if (checker.Length != 2) return "Invalid time";
            foreach (var digits in checker)
            {
                if (digits.Length != 2) return "Invalid Time"
            }
            try
            {
                var hour = Convert.ToInt32(checker[0]);
                var minute = Convert.ToInt32(checker[1]);
                if (hour < 0 || hour > 24) return "Invalid time";
                if (minute < 0 || minute > 60) return "Invalid time";
                return "Valid time";
            }
            catch
            {
                return "Invalid time";
            }
        }

        static string PascalCase(string input)
        {
            var builder = new System.Text.StringBuilder();
            var stringArr = input.Split(' ');
            foreach (var str in stringArr)
            {
                var newWord = str[0].ToString().ToUpper() + str.ToLower().Substring(1);
                builder.Append(newWord);
            }
        }
    }
}
