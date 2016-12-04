using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.day4
{
    public class Day4
    {
        public const string Directory =
            @"C:\Users\Niels Bokmans\Documents\Visual Studio 2013\Projects\AdventOfCode\AdventOfCode\data\";

        public static void Main(string[] args)
        {
            FileInfo input = new FileInfo(Directory + "Day4.txt");
            List<Room> rooms = new List<Room>();
            using (StreamReader reader = input.OpenText())
            {
                string room = "";
                while ((room = reader.ReadLine()) != null)
                {
                    rooms.Add(new Room(room));
                }
            }

            int roomSectorNumber = 0;
            foreach (Room room in rooms.Where(x => x.IsValidChecksum()))
            {
                roomSectorNumber += room.RoomNumber;
            }
            Console.WriteLine("Total number of room numbers with valid checksum (p1): " + roomSectorNumber);
            Console.WriteLine("Room number of room containing north pole stuff (p2): " +
                              rooms.First(x => x.DecryptRoomName().Contains("north")).RoomNumber);
        }
    }

    public class Room
    {
        public const string RoomRegex = @"(.+)-(\d+)\[(.+)\]";

        public string RoomName;
        public int RoomNumber;
        public string RoomChecksum;

        public Room(string room)
        {
            Match match = new Regex(RoomRegex).Match(room);
            if (match.Success)
            {
                RoomName = match.Groups[1].Value;
                RoomNumber = int.Parse(match.Groups[2].Value);
                RoomChecksum = match.Groups[3].Value;
            }
        }

        public bool IsValidChecksum()
        {
            var letters =
                RoomName.Replace("-", string.Empty).GroupBy(c => c)
                    .Select(x => new {x.Key, count = x.Count()})
                    .OrderByDescending(x => x.count)
                    .ThenBy(x => x.Key)
                    .Take(5);
            string checksum = new string(letters.Select(x => x.Key).ToArray());
            return checksum.Equals(RoomChecksum);
        }

        public string DecryptRoomName()
        {
            char[] roomName = RoomName.Replace("-", " ").ToCharArray();
            for (int i = 0; i < RoomName.Length; i++)
            {
                for (int j = 0; j < RoomNumber%26; j++)
                {
                    switch (roomName[i])
                    {
                        case ' ':
                            continue;
                        case 'z':
                            roomName[i] = 'a';
                            break;
                        default:
                            roomName[i] = (char) (roomName[i] + 1);
                            break;
                    }
                }
            }
            return new string(roomName);
        }
    }
}