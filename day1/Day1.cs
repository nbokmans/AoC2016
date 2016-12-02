using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.day1
{
    class Day1
    {
        public static string Instructions =
            "L5, R1, R3, L4, R3, R1, L3, L2, R3, L5, L1, L2, R5, L1, R5, R1, L4, R1, R3, L4, L1, R2, R5, R3, R1, R1, L1, R1, L1, L2, L1, R2, L5, L188, L4, R1, R4, L3, R47, R1, L1, R77, R5, L2, R1, L2, R4, L5, L1, R3, R187, L4, L3, L3, R2, L3, L5, L4, L4, R1, R5, L4, L3, L3, L3, L2, L5, R1, L2, R5, L3, L4, R4, L5, R3, R4, L2, L1, L4, R1, L3, R1, R3, L2, R1, R4, R5, L3, R5, R3, L3, R4, L2, L5, L1, L1, R3, R1, L4, R3, R3, L2, R5, R4, R1, R3, L4, R3, R3, L2, L4, L5, R1, L4, L5, R4, L2, L1, L3, L3, L5, R3, L4, L3, R5, R4, R2, L4, R2, R3, L3, R4, L1, L3, R2, R1, R5, L4, L5, L5, R4, L5, L2, L4, R4, R4, R1, L3, L2, L4, R3";

        public static int CurrentX = 0;
        public static int CurrentY = 0;

        public static Orientation CurrentOrientation;
        public static List<Tile> VisitedLocations = new List<Tile>();

        public static void Main(string[] args)
        {
            CurrentOrientation = Orientation.NORTH;
            foreach (string instruction in Instructions.Split(','))
            {
                int steps = int.Parse(Regex.Match(instruction, @"\d+").Value);
                CurrentOrientation = GetNextOrientation(instruction);
                if (AddSteps(steps))
                {
                    break;
                }
                Console.WriteLine("Moved " + steps + " steps " + CurrentOrientation);
            }
            Console.WriteLine("x: " + CurrentX + ", y: " + CurrentY);
            Console.WriteLine("Blocks away: " + CalculateBlocksAway());
        }

        public static int CalculateBlocksAway(Tile tile)
        {
            return Math.Abs(tile.X) + Math.Abs(tile.Y);
        }

        public static int CalculateBlocksAway()
        {
            return Math.Abs(CurrentX) + Math.Abs(CurrentY);
        }

        public enum Orientation
        {
            NORTH = 0,
            EAST = 90,
            SOUTH = 180,
            WEST = 270
        }

        public static bool AddSteps(int steps)
        {
            for (int i = 1; i <= steps; i++)
            {
                switch (CurrentOrientation)
                {
                    case Orientation.NORTH:
                        CurrentY += 1;
                        break;
                    case Orientation.EAST:
                        CurrentX += 1;
                        break;
                    case Orientation.SOUTH:
                        CurrentY -= 1;
                        break;
                    case Orientation.WEST:
                        CurrentX -= 1;
                        break;
                }
                Tile currentTile = new Tile(CurrentX, CurrentY);
                if (VisitedLocations.Any(t => t.X == currentTile.X && t.Y == currentTile.Y))
                {
                    Console.WriteLine("Duplicate tile found @ " + currentTile.X + ", " + currentTile.Y + " - " +
                                      CalculateBlocksAway(currentTile) + " blocks away");
                    return true;
                }
                VisitedLocations.Add(new Tile(CurrentX, CurrentY));
            }
            return false;
        }

        public static Orientation GetNextOrientation(string direction)
        {
            bool isR = direction.Contains("R");
            switch (CurrentOrientation)
            {
                case Orientation.NORTH:
                    return isR ? Orientation.EAST : Orientation.WEST;
                case Orientation.EAST:
                    return isR ? Orientation.SOUTH : Orientation.NORTH;
                case Orientation.SOUTH:
                    return isR ? Orientation.WEST : Orientation.EAST;
                case Orientation.WEST:
                    return isR ? Orientation.NORTH : Orientation.SOUTH;
            }
            return Orientation.NORTH;
        }

        public class Tile
        {
            public int X;
            public int Y;

            public Tile(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}