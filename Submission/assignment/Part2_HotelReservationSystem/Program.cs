
using System;
using System.Globalization;
using System.Linq;
using Part2_HotelReservationSystem;


Guest.SeedData();
Room.SeedData();
Reservation.SeedData();

Console.WriteLine("Welcome to Hotel Reservation System!");

string choice;

do
{
    Console.WriteLine("\n------------- HOTEL MENU ------------");
    Console.WriteLine("1- Print All Guests");
    Console.WriteLine("2- Print All Rooms");
    Console.WriteLine("3- Print All Reservations");
    Console.WriteLine("4- Add Guest");
    Console.WriteLine("5- Add Room");
    Console.WriteLine("6- Create Reservation");
    Console.WriteLine("7- Show Guest Reservations");
    Console.WriteLine("8- Confirm Reservation");
    Console.WriteLine("9- Check In");
    Console.WriteLine("10- Check Out");
    Console.WriteLine("11- Cancel Reservation");
    Console.WriteLine("12- Change Room Nightly Rate");
    Console.WriteLine("13- Start Room Maintenance");
    Console.WriteLine("14- End Room Maintenance");
    Console.WriteLine("0- Exit");
    Console.Write("Choose an option: ");

    choice = Console.ReadLine() ?? "";

    try
    {
        switch (choice)
        {
            case "1":
                Guest.PrintAllGuests();
                break;

            case "2":
                Room.PrintAllRooms();
                break;

            case "3":
                Reservation.PrintAllReservations();
                break;

            case "4":
                Guest.AddGuest();
                break;

            case "5":
                Room.AddRoom();
                break;

            case "6":
                Reservation.CreateReservation();
                break;

            case "7":
                Guest.ShowGuestReservations();
                break;

            case "8":
                Reservation.ChangeReservationStatus("confirm");
                break;

            case "9":
                Reservation.ChangeReservationStatus("checkin");
                break;

            case "10":
                Reservation.ChangeReservationStatus("checkout");
                break;

            case "11":
                Reservation.ChangeReservationStatus("cancel");
                break;

            case "12":
                Room.ChangeRoomRate();
                break;

            case "13":
                Room.ChangeMaintenanceStatus(true);
                break;

            case "14":
                Room.ChangeMaintenanceStatus(false);
                break;

            case "0":
                Console.WriteLine("Goodbye!");
                break;

            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

} while (choice != "0");


