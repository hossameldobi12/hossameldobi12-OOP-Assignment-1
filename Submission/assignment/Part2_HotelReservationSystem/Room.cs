namespace Part2_HotelReservationSystem
{
    public enum RoomType
    {
        Single,
        Double,
        Suite
    }

    public class Room
    {
     
        public int RoomNumber { get; }
        public RoomType RoomType { get; }
        public decimal NightlyRate { get;private set; }
        public bool IsUnderMaintenance { get; private set; }
        public static List<Room> Rooms { get; } = new List<Room>();

        public Room(int roomNumber, RoomType roomType, decimal nightlyRate, bool isUnderMaintenance)
        {
          if(roomNumber <= 0)
            {
                throw new ArgumentException("Room number must be a positive integer.", nameof(roomNumber));
            }
            if (nightlyRate <= 0)
            {
               throw new ArgumentException("Nightly rate cannot be negative or zero.", nameof(nightlyRate));
            }
            if(Rooms.Any(r => r.RoomNumber == roomNumber))
            {
                throw new InvalidOperationException(
                    "A room with this number already exists.");
            }

            RoomNumber = roomNumber;
            RoomType = roomType;
            NightlyRate = nightlyRate;
            IsUnderMaintenance = isUnderMaintenance;
            Rooms.Add(this);
        }
        public void SetNightlyRate(decimal newRate)
        {
            if (newRate <= 0)
            {
                throw new ArgumentException("Nightly rate cannot be negative or zero.", nameof(newRate));
            }
            NightlyRate = newRate;
        }
        public void StartMaintenance()
        {
            IsUnderMaintenance = true;
        }

        public void EndMaintenance()
        {
            IsUnderMaintenance = false;
        }
        public static void AddRoom()
        {
            int roomNumber =Helper. ReadInt("Enter room number: ");

            Console.WriteLine("Room Types:");
            Console.WriteLine("0- Single");
            Console.WriteLine("1- Double");
            Console.WriteLine("2- Suite");

            int typeNumber = Helper.ReadInt("Choose room type: ");

            if (!Enum.IsDefined(typeof(RoomType), typeNumber))
            {
                throw new ArgumentException("Invalid room type.");
            }

            RoomType roomType = (RoomType)typeNumber;

            decimal nightlyRate = Helper.ReadDecimal("Enter nightly rate: ");

            Console.Write("Is the room under maintenance? (y/n): ");
            string answer = Console.ReadLine() ?? "";

            bool isUnderMaintenance =
                answer.Equals("y", StringComparison.OrdinalIgnoreCase);

            if (!isUnderMaintenance && !answer.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Please enter y or n.");
            }

            Room room = new Room(
                roomNumber,
                roomType,
                nightlyRate,
                isUnderMaintenance);

            Console.WriteLine($"Room {room.RoomNumber} added successfully.");
        }
        public static void PrintAllRooms()
        {
            if (Rooms.Count == 0)
            {
                Console.WriteLine("No rooms found.");
                return;
            }

            foreach (var room in Rooms)
            {
                Console.WriteLine(
                    $"Room: {room.RoomNumber}, Type: {room.RoomType}, " +
                    $"Rate: {room.NightlyRate}, Maintenance: {room.IsUnderMaintenance}");
            }
        }

        public static void ChangeRoomRate()
        {
            int roomNumber = Helper.ReadInt("Enter room number: ");

            Room? room = Room.Rooms.FirstOrDefault(
                r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            decimal newRate =Helper. ReadDecimal("Enter new nightly rate: ");

            room.SetNightlyRate(newRate);

            Console.WriteLine("Nightly rate updated successfully.");
        }

        public static void ChangeMaintenanceStatus(bool startMaintenance)
        {
            int roomNumber = Helper.ReadInt("Enter room number: ");

            Room? room = Room.Rooms.FirstOrDefault(
                r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            if (startMaintenance)
            {
                room.StartMaintenance();
                Console.WriteLine("Room maintenance started.");
            }
            else
            {
                room.EndMaintenance();
                Console.WriteLine("Room maintenance ended.");
            }
        }
        public static void SeedData()
        {
            if (Rooms.Count > 0)
                return;

            new Room(101, RoomType.Single, 1000m, false);
            new Room(102, RoomType.Double, 1500m, false);
            new Room(103, RoomType.Suite, 3000m, false);
            new Room(104, RoomType.Double, 1800m, true);
            new Room(105, RoomType.Single, 1200m, false);
        }


    }
}