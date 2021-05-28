using System;
using GestioneClientiOrdini.Core.BusinessLayer;
using GestioneClientiOrdini.Core.EF.Repositories;
using GestioneClientiOrdini.Core.Entities;
using GestioneClientiOrdini.Core.Interfaces;

namespace GestioneClientiOrdini.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Client for accessing Customer and Order services ===");

            IServiceBL bl = SetEnvironment();

            do
            {
                Console.WriteLine();
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Add new customer");
                Console.WriteLine("2. Place a new order");
                Console.WriteLine("3. Show order list for a customer");
                Console.WriteLine("4. Show order details");
                Console.WriteLine("4. Orders report");
                Console.WriteLine("0. Quit");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.WriteLine();
                        AddNewCustomer(bl);
                        break;
                    case '2':
                        Console.WriteLine();
                        PlaceNewOrder(bl);
                        break;
                    case '3':
                        Console.WriteLine();
                        ShowCustomerOrders(bl);
                        break;
                    case '4':
                        Console.WriteLine();
                        ShowOrderDetails(bl);
                        break;
                    case '5':
                        Console.WriteLine();
                        ReportOrders(bl);
                        break;
                    case '0':
                        return; // si esce dal programma
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }

            } while (true);

        }

        private static IServiceBL SetEnvironment()
        {
            ICustomer customerRepos = new EFCustomerRepository();
            IOrder orderRepos = new EFOrderRepository();

            return new ServiceBL(customerRepos, orderRepos);
        }

        private static void AddNewCustomer(IServiceBL bl)
        {
            Console.WriteLine("Please insert the required Customer data:");
            
            Console.Write("-- Name: ");
            string name = Console.ReadLine();

            Console.Write("-- Surname: ");
            string surname = Console.ReadLine();

            Console.Write("-- Customer code: ");
            string code = Console.ReadLine();

            if(bl.AddNewCustomer(new Customer
            {
                Code = code,
                Name = name,
                Surname = surname
            }))
                 Console.WriteLine($"Customer [{code}] {name} {surname} added correctly!");
            else
                Console.WriteLine("Something went wrong. Try again!");
        }

        private static void PlaceNewOrder(IServiceBL bl)
        {
            Console.WriteLine("Please insert the required Order details: ");
            
            int customerId;
            do
            {
                Console.Write("-- Customer id: ");
            } while (!int.TryParse(Console.ReadLine(), out customerId));

            Console.Write("-- Product code: ");
            string productCode = Console.ReadLine();

            decimal amount;
            do
            {
                Console.Write("-- Amount due: ");
            } while (!decimal.TryParse(Console.ReadLine(), out amount));
            

            if(bl.PlaceOrder(customerId, productCode, amount))
                Console.WriteLine($"Order placed for customer n° {customerId}!");
            else
                Console.WriteLine("Something went wrong. Try again!");
        }

        private static void ShowCustomerOrders(IServiceBL bl)
        {
            int customerId;
            do
            {
                Console.Write("-- Search for customer id n°: ");
            } while (!int.TryParse(Console.ReadLine(), out customerId));

            foreach (var o in bl.FetchOrdersByCustomer(customerId))
                Console.WriteLine(o);
        }

        private static void ShowOrderDetails(IServiceBL bl)
        {
            int orderId;
            do
            {
                Console.Write("-- Select order n°: ");
            } while (!int.TryParse(Console.ReadLine(), out orderId));

            Console.WriteLine(bl.GetOrderById(orderId));
        }

        private static void ReportOrders(IServiceBL bl)
        {
            throw new NotImplementedException();
        }
   
    }
}
