using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.day7
{
    public class Day7
    {
        public const string Directory =
            @"C:\Users\Niels Bokmans\Documents\Visual Studio 2013\Projects\AdventOfCode\AdventOfCode\data\";

        public const string SquareBracketRegex = @"(?<=\[)[^]]+(?=\])";

        public static void Main(string[] args)
        {
            FileInfo input = new FileInfo(Directory + "Day7.txt");
            int countDay1 = 0;
            int countDay2 = 0;
            using (StreamReader reader = input.OpenText())
            {
                string ip = "";
                while ((ip = reader.ReadLine()) != null)
                {
                    if (IsValid(ip))
                    {
                        //Console.WriteLine("Valid IP: " + ip);
                        countDay1++;
                    }
                    if (IsBab(ip))
                    {
                        //Console.WriteLine("Valid BAB: " + ip);
                        countDay2++;
                    }
                }
            }
            Console.WriteLine("Total valid ABBA (pt 1): " + countDay1);
            Console.WriteLine("Total valid BAB (pt 2): " + countDay2);
        }

        private static bool IsValid(string ip)
        {
            MatchCollection coll = Regex.Matches(ip, SquareBracketRegex);
            if (coll.Cast<Match>().Any(m => HasAbbaInString(m.Value)))
            {
                return false;
            }
            return HasAbbaInString(ip);
        }

        private static bool HasAbbaInString(string str)
        {
            for (int i = 0; i < str.Length - 3; i++)
            {
                if (str[i] == str[i + 3] && str[i + 1] == str[i + 2] && str[i] != str[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsBab(string input)
        {
            string[] split = input.Split('[', ']');
            for (int x = 0; x < split.Length; x++)
            {
                if (x%2 == 0)
                {
                    string ip = split[x];
                    for (int i = 0; i < ip.Length - 2; i++)
                    {
                        string substring = new string(new[] { ip[i], ip[i + 1], ip[i + 2] });
                        if (substring[0] == substring[2] && substring[0] != substring[1])
                        {
                            string reversed = new string(new[] { substring[1], substring[0], substring[1] });
                            if (HasBabInBrackets(reversed, input))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool HasBabInBrackets(string reversed, string ip)
        {
            return Regex.Matches(ip, SquareBracketRegex).Cast<Match>().Any(match => match.Value.Contains(reversed));
        }
    }
}