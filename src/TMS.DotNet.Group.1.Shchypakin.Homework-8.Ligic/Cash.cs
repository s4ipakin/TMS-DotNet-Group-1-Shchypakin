using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMS.DotNet.Group._1.Shchypakin.Homework_8.Ligic.Interfaces;

namespace TMS.DotNet.Group._1.Shchypakin.Homework_8.Data
{
    public class Cash : ICash
    {
        public int CashIndex { get; set; }
        public int CasherDelayTime { get; set; }
        public bool IsWorking { get; set; }
        public Queue<ICustomer> customers = new();
        private double _allCash = default;
        public Cash()
        {
            Random random = new();
            IsWorking = random.NextDouble() >= 0.5;
        }

        public void GetMoney()
        {
            Random rnd = new();
            CasherDelayTime = rnd.Next(1000, 3000);
            while (IsWorking)
            {
                if (customers.Count > 0)
                {
                    Thread.Sleep(CasherDelayTime);
                    ICustomer customer = customers.Dequeue();
                    var products = customer.GetBoughtProducts();
                    Console.WriteLine($"Cash {CashIndex}");
                    Console.WriteLine("The customer's check:");
                    Console.WriteLine();
                    double sum = 0.0;
                    foreach (var product in products)
                    {
                        sum += product.Price;
                        _allCash += product.Price;
                        Console.WriteLine($"{product.Name}.....{product.Price}");
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Sum:.....{sum}");
                    Console.WriteLine();
                    Console.WriteLine($"Total money int the cash:..... {_allCash}");
                    Console.WriteLine($"Customers remain in line: {customers.Count}");
                    Console.WriteLine(new string('=', 50));
                    Console.WriteLine();
                }
            }
        }

        public int GetQueueCount()
        {
            return customers.Count();
        }

        public void TakeQueue(ICustomer customer)
        {
            customers.Enqueue(customer);
            Console.WriteLine($"A custemer took line in {CashIndex}."
                + $" Line lenght is  {customers.Count}");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();
        }
    }
}