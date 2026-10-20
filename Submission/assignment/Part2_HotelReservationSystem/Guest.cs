using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
    public class Guest
    {

        public int Id { get; }
        public string FullName { get; }
        public string Phone { get; }
        public static List<Guest> Guests { get; } = new List<Guest>();
        private List<Reservation> Reservations { get; }
        public IReadOnlyList<Reservation> GetReservations() => Reservations.AsReadOnly();
        public Guest(int id, string fullName, string phone)
        {
            if(id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.", nameof(id));
            }
            if(Guests.Exists(g => g.Id == id))
            {
                throw new InvalidOperationException(
                    "A guest with this ID already exists.");
            }
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be null or empty.", nameof(fullName));
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("Phone number cannot be null or empty.", nameof(phone));
            }
            Id = id;
            FullName = fullName;
            Phone = phone;
            Reservations = new List<Reservation>();
            Guests.Add(this);
        }
        public void AddReservation(Reservation reservation)
        {

            if (reservation == null)
            {
                throw new ArgumentNullException(
                    nameof(reservation),
                    "Reservation cannot be null.");
            }

            if (Reservations.Contains(reservation))
            {
                throw new InvalidOperationException(
                    "This reservation has already been added to this guest.");
            }

            Reservations.Add(reservation);
            
        }


        public void DisplayReservations()
        {
            if (Reservations.Count == 0)
            {
                Console.WriteLine("No reservations found for this guest.");
                return;
            }
            Console.WriteLine($"Reservations for {FullName}:");
            foreach (var reservation in Reservations)
            {
                Console.WriteLine($"   Reservation ID: {reservation.Id}, Room Number: {reservation.Room.RoomNumber}, Check-In: {reservation.CheckInDate.ToShortDateString()}, Check-Out: {reservation.CheckOutDate.ToShortDateString()}, Status: {reservation.Status}");
            }
        }
        public static void AddGuest()
        {
            int id = Helper.ReadInt("Enter guest ID: ");

            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine() ?? "";

            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine() ?? "";

            Guest guest = new Guest(id, fullName, phone);

            Console.WriteLine($"Guest '{guest.FullName}' added successfully.");
        }
        public static void PrintAllGuests()
        {
            if (Guests.Count == 0)
            {
                Console.WriteLine("No guests found.");
                return;
            }

            foreach (var guest in Guests)
            {
                Console.WriteLine(
                    $"ID: {guest.Id}, Name: {guest.FullName}, Phone: {guest.Phone}");
            }
        }
        public static void ShowGuestReservations()
        {
            int guestId = Helper.ReadInt("Enter guest ID: ");

            Guest? guest = Guest.Guests.FirstOrDefault(g => g.Id == guestId);

            if (guest == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }

            guest.DisplayReservations();
        }
        public static void SeedData()
        {
            if (Guests.Count > 0)
                return;

            new Guest(1, "Ahmed Mohamed", "01012345678");
            new Guest(2, "Omar Ali", "01123456789");
            new Guest(3, "Sara Hassan", "01234567890");
            new Guest(4, "Mona Ibrahim", "01512345678");
        }

    }
}
