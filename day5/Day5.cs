using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.day5
{
    public class Day5
    {
        private const string Input = "ojvtpuvg";
        private const int InputPasswordCharacters = 8;
        private static readonly IEnumerable<int> AllNumbers = Enumerable.Range(1, int.MaxValue);
        private static readonly IEnumerable<int> PasswordPositionRange = Enumerable.Range(0, 8);
        private static readonly MD5 Md5 = MD5.Create();

        public static void Main(string[] args)
        {
            Console.WriteLine("Solution to day 5 part 1: " + CalculateDay1());
            Console.WriteLine("Solution to day 5 part 2: " + CalculateDay2());
        }


        public static string CalculateDay1()
        {
            return new string(AllNumbers.Select(hash => GenerateMd5Hash(Input + hash))
                .Where(hash => hash.StartsWith("00000"))
                .Select(c => c[5])
                .Take(InputPasswordCharacters)
                .ToArray());
        }

        public static string CalculateDay2()
        {
            return new string(PasswordPositionRange.Select(@char =>
                    AllNumbers.Select(hash => GenerateMd5Hash(Input + hash))
                        .Where(hash => hash.StartsWith("00000"))
                        .First(h => h[5] == @char)[6])
                .ToArray());
        }


        public static string GenerateMd5Hash(string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = Md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}