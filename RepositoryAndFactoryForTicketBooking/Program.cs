using RepositoryAndFactoryForTicketBooking.Entities;
using RepositoryAndFactoryForTicketBooking.Factory;
using RepositoryAndFactoryForTicketBooking.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndFactoryForTicketBooking
{
    internal class Program
    {
        static IPassengerRepository repo = new PassengerRepository();
        static void Main(string[] args)
        {
			try
			{
				TicketBooking();
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
			}
            finally
            {
                Console.ReadLine();
            }
        }

        private static void TicketBooking()
        {
            while (true)
            {
                Console.WriteLine("\n------------------Passenger Management----------------");
                Console.WriteLine("1. Create  2. Read  3. Update  4. Delete  5. Exit");
                var input = Console.ReadLine();
                if (input == "5") break;
                ExecuteChoice(input);
            }
        }

        private static void ExecuteChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Create();
                    break;
                case "2":
                    Read();
                    break;
                case "3":
                    Update();
                    break;
                case "4":
                    Delete();
                    break;
                default:
                    break;
            }
        }

        private static void Create()
        {
            Console.WriteLine();
            Console.Write("Name : ");
            string name = Console.ReadLine();
            Console.Write("Email : ");
            string email = Console.ReadLine();

            Console.Write("SeatType (1. FirstClass, 2. Economy): ");
            SeatType seatType = (SeatType)Enum.Parse(typeof(SeatType), Console.ReadLine());

            Console.Write("PaymentType (1. Card, 2. Cash): ");
            Payment payType = (Payment)Enum.Parse(typeof(Payment), Console.ReadLine());

            double firsClassPrice = 45000;
            double economyPrice = 30000;

            Console.Write("No Of Seat : ");
            int noOfSeat =Convert.ToInt32( Console.ReadLine());

            //New Passenger
            Passenger newPassenger = new Passenger(0, name, email, seatType, payType, firsClassPrice, economyPrice, noOfSeat);

            PassengerFactory factory = payType == Payment.Card ? (PassengerFactory)
                new CardFactory(newPassenger) : new CashFactory(newPassenger);

            factory.ProcessPassenger();

            repo.SavePassenger(newPassenger);
            Read();
        }

        private static void Read()
        {
            var passengerList = repo.GetPassengerList();
            Console.WriteLine("\n" + new string('=', 120));
            Console.WriteLine("\n\t\t\t\t\tPassenger Information List");
            Console.WriteLine("\n" + new string('=', 120));
            Console.WriteLine();

            string headerFormat = "  | {0, -3} | {1, -7} | {2, -12} | {3, -12} | {4, -10} | {5, -10} | {6, -12} | {7, -10} | {8, -10} |";
            Console.WriteLine(headerFormat, "ID", "Name", "SeatType", "Unit Price", "No Of Seat", "PayType", "Total", "CashBack", "Discounted");
            Console.WriteLine(new string('_', 120) + "\n\n");

            if (!passengerList.Any())
            {
                Console.WriteLine("\t\t\t\t\tNo Record Found");
            }
            else
            {
                foreach (var p in passengerList)
                {
                    string unitPrice = p.Type == Entities.SeatType.FirstClass ? p.FirstClassPrice.ToString("N2") : p.EconomyPrice.ToString("N2");

                    Console.WriteLine(headerFormat, p.PassengerID, p.Name, p.Type, unitPrice, p.NoOfSeat,  p.Pay, p.TotalPayment.ToString("N2"), p.CashBack.ToString("N2"), p.DiscountedPayment.ToString("N2"));
                }
                Console.WriteLine("\n" + new string('=', 120));
            }
            Console.WriteLine();
        }

        private static void Update()
        {
            Console.WriteLine();
            Console.Write("Enter Passenger ID to Update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }
            var passenger = repo.GetPassengerById(id);
            if (passenger == null)
            {
                Console.WriteLine("Passenger not found!");
                return;
            }

            Console.WriteLine($" {passenger.PassengerID}");
            Console.Write($"New Name (Prev. name - {passenger.Name}): ");
            passenger.Name = Console.ReadLine();
            Console.WriteLine($"New Passenger Type (Prev. type - {passenger.Type})");
            Console.Write("Seat Type (1. FirstClass, 2. Economy): ");
            passenger.Type = (SeatType)Enum.Parse(typeof(SeatType), Console.ReadLine());
            Console.Write($"New Payment Type (Prev. type - {passenger.Pay}) \n(1. Card, 2. Cash): ");
            passenger.Pay = (Payment)int.Parse(Console.ReadLine());

            //if(passenger.Pay == Payment.Card)
            //{
            //    if (passenger.Type == SeatType.FirstClass)
            //    {
            //        passenger.FirstClassPrice = 45000;
            //    }
            //    else if (passenger.Type == SeatType.Economy)
            //    {
            //        passenger.EconomyPrice = 30000;
            //    }
            //    //Console.Write($"New Total Payment: {passenger.TotalPayment}");
            //    //passenger.DiscountedPayment = 0;
            //}
            //else
            //{
            //    if (passenger.Type == SeatType.FirstClass)
            //    {
            //        passenger.FirstClassPrice = 38250;
            //    }
            //    else if (passenger.Type == SeatType.Economy)
            //    {
            //        passenger.EconomyPrice = 25500;
            //    }
            //    //Console.Write($"New Total Payment: {passenger.DiscountedPayment}");
            //    //Console.WriteLine();
            //    //passenger.TotalPayment = 0;
            //}

            Console.Write("No Of Seat : ");
            passenger.NoOfSeat = Convert.ToInt32(Console.ReadLine());

            PassengerFactory factory = passenger.Pay == Payment.Card
                ? (PassengerFactory)new CardFactory(passenger)
                : new CashFactory(passenger);
            factory.ProcessPassenger();

            repo.UpdatePassenger(passenger);
            Console.WriteLine("\nLabourer updated and recalculated successfully!");
            Read();
        }

        private static void Delete()
        {
            Console.WriteLine();
            Console.WriteLine("Enter Passenger ID to Delete");
            int id = Convert.ToInt32(Console.ReadLine());

            repo.DeletePassenger(id);
            Read();
        }
    }
}
