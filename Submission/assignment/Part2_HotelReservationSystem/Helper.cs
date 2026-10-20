using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Part2_HotelReservationSystem
{
    public static class Helper
    {    
        

   



        public static void ShowCompletedReservationsTotal()
        {
            decimal total = Reservation.Reservations
                .Where(r => r.Status == ReservationStatus.CheckedOut)
                .Sum(r => r.TotalCost);

            Console.WriteLine($"Completed reservations total: {total}");
        }


        public static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }

                Console.WriteLine("Please enter a valid integer.");
            }
        }


        public static decimal ReadDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                {
                    return value;
                }

                Console.WriteLine("Please enter a valid number.");
            }
        }


        public static DateTime ReadDate(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }

                Console.WriteLine("Invalid date. Use yyyy-MM-dd, for example 2026-10-20.");
            }
        }

    }
}
