namespace Part2_HotelReservationSystem
{
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        CheckedIn,
        CheckedOut,
        Cancelled
    }

    public class Reservation
    {

        public int Id { get; }
        public DateTime CheckOutDate { get; }
        public DateTime CheckInDate { get; }
        public Room Room { get; }
        public ReservationStatus Status { get; private set; }

        public static List<Reservation> Reservations { get; } = new List<Reservation>();

        public int NumberOfNights =>
       (CheckOutDate - CheckInDate).Days;

        public decimal TotalCost =>
            NumberOfNights * Room.NightlyRate;
        public Reservation(int id, DateTime checkOutDate, DateTime checkInDate, Room room)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }
            if (Reservations.Any(r => r.Id == id))
            {
                throw new InvalidOperationException(
                    "A reservation with this ID already exists.");
            }
            if (checkInDate >= checkOutDate)
            {
                throw new ArgumentException("Check-in date must be before check-out date.");
            }
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room), "Room cannot be null.");
            }

            if (room.IsUnderMaintenance)
            {
                throw new ArgumentException("Room is under maintenance and cannot be reserved.");
            }
            if (HasDateOverlap(room, checkInDate, checkOutDate))
            {
                throw new ArgumentException("The room is already reserved for the selected dates.");
            }

            Id = id;
            CheckOutDate = checkOutDate;
            CheckInDate = checkInDate;
            Room = room;
            Status = ReservationStatus.Pending;
            Reservations.Add(this);
        }

        public void ConfirmReservation()
        {
            if (Status != ReservationStatus.Pending)
            {
                throw new InvalidOperationException("Only pending reservations can be confirmed.");
            }
            Status = ReservationStatus.Confirmed;
        }
        public void CheckIn()
        {
            if (Status != ReservationStatus.Confirmed)
            {
                throw new InvalidOperationException("Only confirmed reservations can be checked in.");
            }
            Status = ReservationStatus.CheckedIn;
        }
        public void CheckOut()
        {
            if (Status != ReservationStatus.CheckedIn)
            {
                throw new InvalidOperationException("Only checked-in reservations can be checked out.");
            }
            Status = ReservationStatus.CheckedOut;
        }
        public void CancelReservation()
        {
            if (Status != ReservationStatus.Pending &&
                Status != ReservationStatus.Confirmed)
            {
                throw new InvalidOperationException(
                    "Only pending or confirmed reservations can be cancelled.");
            }

            Status = ReservationStatus.Cancelled;
        }
        private static bool HasDateOverlap(Room room, DateTime checkInDate, DateTime checkOutDate)
        {
            foreach (var reservation in Reservations)
            {
                if (reservation.Room.RoomNumber != room.RoomNumber)
                {
                    continue;
                }

                if (reservation.Status == ReservationStatus.Cancelled ||
                    reservation.Status == ReservationStatus.CheckedOut)
                {
                    continue;
                }

                if (checkInDate < reservation.CheckOutDate &&
                    checkOutDate > reservation.CheckInDate)
                {
                    return true;
                }
            }

            return false;
        }
        public static void CreateReservation()
        {
            int guestId = Helper.ReadInt("Enter guest ID: ");

            Guest? guest = Guest.Guests.FirstOrDefault(g => g.Id == guestId);

            if (guest == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }

            int roomNumber = Helper.ReadInt("Enter room number: ");

            Room? room = Room.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            int reservationId = Helper.ReadInt("Enter reservation ID: ");

            DateTime checkInDate = Helper.ReadDate("Enter check-in date (yyyy-MM-dd): ");
            DateTime checkOutDate = Helper.ReadDate("Enter check-out date (yyyy-MM-dd): ");


            Reservation reservation = new Reservation(reservationId, checkOutDate, checkInDate, room);

            guest.AddReservation(reservation);

            Console.WriteLine(
                $"Reservation {reservation.Id} created successfully for {guest.FullName}.");
            Console.WriteLine($"Total cost: {reservation.TotalCost}");
        }
        public static void PrintAllReservations()
        {
            if (Reservations.Count == 0)
            {
                Console.WriteLine("No reservations found.");
                return;
            }

            foreach (var reservation in Reservations)
            {
                Console.WriteLine(
                    $"ID: {reservation.Id}, " +
                    $"Room: {reservation.Room.RoomNumber}, " +
                    $"Check-In: {reservation.CheckInDate:yyyy-MM-dd}, " +
                    $"Check-Out: {reservation.CheckOutDate:yyyy-MM-dd}, " +
                    $"Status: {reservation.Status}, " +
                    $"Total Cost: {reservation.TotalCost}");
            }
        }
        public static void ChangeReservationStatus(string action)
        {
            int id = Helper.ReadInt("Enter reservation ID: ");

            Reservation? reservation = Reservation.Reservations
                .FirstOrDefault(r => r.Id == id);

            if (reservation == null)
            {
                Console.WriteLine("Reservation not found.");
                return;
            }

            switch (action)
            {
                case "confirm":
                    reservation.ConfirmReservation();
                    Console.WriteLine("Reservation confirmed successfully.");
                    break;

                case "checkin":
                    reservation.CheckIn();
                    Console.WriteLine("Guest checked in successfully.");
                    break;

                case "checkout":
                    reservation.CheckOut();
                    Console.WriteLine("Guest checked out successfully.");
                    break;

                case "cancel":
                    reservation.CancelReservation();
                    Console.WriteLine("Reservation cancelled successfully.");
                    break;
            }
        }
        public static void SeedData()
        {
            if (Reservations.Count > 0)
                return;

            Guest guest1 = Guest.Guests[0];
            Guest guest2 = Guest.Guests[1];
            Guest guest3 = Guest.Guests[2];

            Room room101 = Room.Rooms.First(r => r.RoomNumber == 101);
            Room room102 = Room.Rooms.First(r => r.RoomNumber == 102);
            Room room103 = Room.Rooms.First(r => r.RoomNumber == 103);

            Reservation reservation1 = new Reservation(
                1,
                new DateTime(2026, 10, 25),
                new DateTime(2026, 10, 22),
                room101
            );


            Reservation reservation2 = new Reservation(
                2,
                new DateTime(2026, 10, 30),
                new DateTime(2026, 10, 27),
                room102
            );

            Reservation reservation3 = new Reservation(
                3,
                new DateTime(2026, 11, 5),
                new DateTime(2026, 11, 1),
                room103
            );

            reservation1.ConfirmReservation();
            reservation2.ConfirmReservation();
            reservation3.ConfirmReservation();

            guest1.AddReservation(reservation1);
            guest2.AddReservation(reservation2);
            guest3.AddReservation(reservation3);
        }


    }
}