using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.day2
{
    class Day2
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

        public static int CurrentX = 0; //CurrentX = 1 for Day 1
        public static int CurrentY = 2; //CurrentY = 1 for Day 1

        public static int CurrentPosition = 5;
        public static string Instructions = "RRLLRLLRULLRUUUDRDLDDLLLDDDDDUUURRRRUUDLRULURRRDRUDRUUDDRUDLLLRLDDDUDRDDRRLLLLRLRLULUURDRURRUULDRRDUDURRUURURDLURULLDUDRDLUUUUDDURRLLLUDLDLRDRRRDULLDLDULLDRLDLDURDLRRULLDDLDRLLLUDDLLRDURULLDDDDDUURURLRLRRDUURUULRLLLULLRLULLUUDRRLLDURLDDDDULUUDLUDDDULRLDURDDRUUDRRUUURLLLULURUDRULDRDUDUDRRDDULRURLLRRLRRLLDLULURDRDRULDRDRURUDLLRRDUUULDDDUURDLULDLRLLURRURLLUDURDDRUDRDLLLLDLRLDLDDRDRRDUUULLUULRRDLURLDULLDLDUUUULLLDRURLRULLULRLULUURLLRDDRULDULRLDRRURLURUDLRRRLUDLDUULULLURLDDUDDLLUDRUDRLDUDURRRRLRUUURLUDDUDURDUDDDLLRLRDDURDRUUDUDRULURLRLDRULDRRLRLDDDRDDDRLDUDRLULDLUDLRLRRRLRDULDDLRRDDLDDULDLLDU\r\nRULLUDDUDLULRRDLLDRUDLLLDURLLLURDURLRDRRDLRDRDLLURRULUULUDUDDLLRRULLURDRLDURDLDDUURLUURLDLDLRLDRLRUULDRLRLDRLRLUDULURDULLLDRUDULDURURRRUDURDUDLRDRRURULRRLRLRRRRRRDRUDLDRULDRUDLRDLRRUDULDLRLURRRLLDRULULRUDULRLULLRLULDRUDUULLRUULDULDUDDUUULLLDRDDRRDLURUUDRRLRRRDLRRLULLLLDLRUULDLLULURUURURDRURLLDUDRRURRURRUUDDRRDDRRRRUDULULRLUULRRDDRDDLLUDLDLULLRLDRLLUULDURLDRULDDUDRUUUURRLDDUDRUURUDLLDLDLURDLULDRLLLULLLUDLLDLD\r\nRDLDULURDLULRRDLRLLLULRUULURULLLDLLDDRLLURUUUURDRLURLLRLRLLLULRDLURDURULULDDUDDUDRLRLDLULLURRRUULUDRDURRRUDDDLUDLDLRLRRLLLRUULLLLURRDDDRRRUURULRLDRRRLRLUDDRRULDDDRUUDDRLLDULRLUDUDLDLDDDUDDLLDDRDRDUDULDRRUDRDRRDRLUURDLRDDDULLDRRRRRUDRLURDUURRDDRLUDLURRRLRDDDLRRLUULRLURDUUURRDLDDULLLRURRRUDRLUDLLDDDDDUDDRDULLUUDDURRLULLUDULUUDRLDRRRLLURLRRLLDLLLLUDRUUUDDULLRDLLDUDUDUURRUUUDRUURDRDLLDLDDULLDDRRULDLDDUUURLDLULLLRRLLRDDULLDLDLDDLDLDULURRDURURDRDRRDLR\r\nRDRLRRUUDRLDUDLLDLUDLUUDUDLRRUUDRDDDLDDLLLRRRUDULLRRRRRURRRLUDDDLRRRRUUULDURDRULLDLRURRUULUDRURRRRLRURLRDUUDUDUDRDDURRURUDLLLLLRURUULRUURLLURDRUURLUDDDRLDDURDLDUDRURDRLRRRRUURDDRRRRURDLUUDRLDRDUULURUDDULLURRDUDLUULLDURRURLUDUUDRDDDUUDDUUUULDLDUDDLUDUUDRURLLULRUUULLRRDDUDDLULDDUUUDLUDDLDDLLRUUDRULLRRDRLLDLLRRLULLRRDDRLRDUULLLUULLDLLUDUDDLRDULUDLDLUDDRRRRDUDLUULLULDLRRDLULRLRRRULRURRDRLULDDUDLDLDULLURLLRDLURRULURDLURLUDRDRRUUDRLLUDDRLRDDUURLRRDUDLDRURDUUUDRRLLRDLDLLDRRURLUDURUULDUDLDDDDRUULLDDRLRURRDURLURRLDDRRRRLRLRDRURUDDRDLDRURLULDDL\r\nRULRDLDDLRURDDDDDDRURLLLDDDUUULLRRDLDLURUURLUDLURRLUDUURDULDRUULDDURULDUULDDULLLUDLRULDRLDLRDDRRDLDDLLDRRUDDUDRDUULUDLLLDDLUUULDDUUULRRDULLURLULDLRLLLRLURLLRLRLDRDURRDUUDDURRULDDURRULRDRDUDLRRDRLDULULDRDURDURLLLDRDRLULRDUURRUUDURRDRLUDDRRLDLDLULRLLRRUUUDDULURRDRLLDLRRLDRLLLLRRDRRDDLDUULRLRRULURLDRLRDULUDRDLRUUDDDURUDLRLDRRUDURDDLLLUDLRLURDUDUDULRURRDLLURLLRRRUDLRRRLUDURDDDDRRDLDDLLDLRDRDDRLLLURDDRDRLRULDDRRLUURDURDLLDRRRDDURUDLDRRDRUUDDDLUDULRUUUUDRLDDD";
        public static void Main(string[] args)
        {
            //CalculateDay1Code();
            CalculateDay2Code();
        }

        public static void CalculateDay1Code()
        {
            foreach (
    string currentNumberInstructions in Instructions.Split(new string[] { "\r\n" }, StringSplitOptions.None))
            {
                foreach (char c in currentNumberInstructions)
                {
                    //Console.Write("Moving " + c + " from " + CurrentX + ", " + CurrentY + "(" + ArrayValuesDay1[CurrentY][CurrentX] + ")");
                    switch (c)
                    {
                        case 'U':
                            CurrentY = Math.Max(0, CurrentY - 1);
                            break;
                        case 'D':
                            CurrentY = Math.Min(2, CurrentY + 1);
                            break;
                        case 'L':
                            CurrentX = Math.Max(0, CurrentX - 1);
                            break;
                        case 'R':
                            CurrentX = Math.Min(2, CurrentX + 1);
                            break;
                    }
                    //Console.WriteLine(" to " + CurrentX + ", " + CurrentY + "(" + ArrayValuesDay1[CurrentY][CurrentX] + ")");
                }
                Console.WriteLine("X: " + CurrentX + ", Y: " + CurrentY + " = " + ArrayValuesDay1[CurrentY][CurrentX]);

            }
        }

        public static void CalculateDay2Code()
        {
            foreach (
                string currentNumberInstructions in Instructions.Split(new string[] {"\r\n"}, StringSplitOptions.None))
            {
                foreach (char c in currentNumberInstructions)
                {
                    //Console.Write("Moving " + c + " from " + CurrentX + ", " + CurrentY + "(" + GetChar(ArrayValuesDay2[CurrentY][CurrentX]) + ")");
                    switch (c)
                    {
                        case 'U':
                            int yUp = Math.Max(0, CurrentY - 1);
                            if (GetAt(CurrentX, yUp) != -1)
                            {
                                CurrentY = yUp;
                            }
                            break;
                        case 'D':
                            int yDown = Math.Min(4, CurrentY + 1);
                            if (GetAt(CurrentX, yDown) != -1)
                            {
                                CurrentY = yDown;
                            }
                            break;
                        case 'L':
                            int xLeft = Math.Max(0, CurrentX - 1);
                            if (GetAt(xLeft, CurrentY) != -1)
                            {
                                CurrentX = xLeft;
                            }
                            break;
                        case 'R':
                            int xRight = Math.Min(4, CurrentX + 1);
                            if (GetAt(xRight, CurrentY) != -1)
                            {
                                CurrentX = xRight;
                            }
                            break;
                            
                    }
                    //Console.WriteLine(" to " + CurrentX + ", " + CurrentY + "(" + GetChar(ArrayValuesDay2[CurrentY][CurrentX]) + ")");

                }
                Console.WriteLine("X: " + CurrentX + ", Y: " + CurrentY + " = " + GetChar(ArrayValuesDay2[CurrentY][CurrentX]));
            }
        }

        private static string GetChar(int number)
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

        private static int GetAt(int x, int y)
        {
            return ArrayValuesDay2[y][x];
        }

    }
}
