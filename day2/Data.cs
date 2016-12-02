using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.day2
{
    public class Data
    {
        public static int[][] ArrayValuesDay1 =
            {
                new int[] {1, 2, 3},
                new int[] {4, 5, 6},
                new int[] {7, 8, 9},
            };

        public static int[][] ArrayValuesDay2 =
            {
                new int[] {-1, -1, 1, -1, -1},
                new int[] {-1, 2, 3, 4, -1},
                new int[] {5, 6, 7, 8, 9},
                new int[] {-1, 10, 11, 12, -1},
                new int[] {-1, -1, 13, -1, -1},
            };

        public static Data Day1 = new Data(ArrayValuesDay1, 1, 1, 2);
        public static Data Day2 = new Data(ArrayValuesDay2, 0, 2, 4);

        public int StartingX;
        public int StartingY;
        public int[][] KeyPad;
        public int Max;

        public Data(int[][] keyPad, int startingX, int startingY, int max)
        {
            KeyPad = keyPad;
            StartingX = startingX;
            StartingY = startingY;
            Max = max;
        }

        public int GetAt(int x, int y)
        {
            return KeyPad[y][x];
        }

        public string GetChar(int number)
        {
            string cVal = number.ToString();
            if (number > 9)
            {
                switch (number)
                {
                    case 10:
                        cVal = "A";
                        break;
                    case 11:
                        cVal = "B";
                        break;
                    case 12:
                        cVal = "C";
                        break;
                    case 13:
                        cVal = "D";
                        break;
                }
            }
            return cVal;
        }
    }
}
