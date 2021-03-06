using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TMS.DotNet.Group._1.Shchypakin.Homework_8.Data;
using TMS.DotNet.Group._1.Shchypakin.Homework_8.Ligic.Interfaces;

namespace TMS.DotNet.Group._1.Shchypakin.Homework_8.Ligic
{
    public class Shop<S, P>
        where S : ICash, new()
        where P : ICustomer, new()
    {
        private List<S> _cashes = new List<S>();
        private P[] _customers = new P[30];
        private Dictionary<ProductName, Product> allProducts = new Dictionary<ProductName, Product>();

        public Shop()
        {
            Random random = new Random();
            foreach (ProductName product in (ProductName[])Enum.GetValues(typeof(ProductName)))
            {
                allProducts.Add(product, new Product(product, random.Next(5, 150)));
            }
        }

        /// <summary>
        /// Sets Cashes and assignes their indexes and delay time
        /// </summary>
        public void SetCashes()
        {
            Random random = new Random();
            bool isAnyWorking = false;
            for (int i = 1; i < 6; i++)
            {
                _cashes.Add(new S() { CashIndex = i, CasherDelayTime = random.Next(1000, 3500) });
                if (_cashes[i - 1].IsWorking)
                {
                    isAnyWorking = true;
                    Console.WriteLine($"Cash {i} is working");
                }
            }

            if (!isAnyWorking)
            {
                int workingCashListIndex = random.Next(0, _cashes.Count - 1);
                _cashes[workingCashListIndex].IsWorking = true;
                Console.WriteLine($"Cash {_cashes[workingCashListIndex].CashIndex} is working");
            }

            Console.WriteLine($"Cashes are set");
        }

        /// <summary>
        /// Runs the shop
        /// </summary>
        public void Run()
        {
            Task[] cashTasks = new Task[5];
            int taskIndex = 0;
            foreach (S cash in _cashes)
            {
                cashTasks[taskIndex] = Task.Factory.StartNew(() => cash.GetMoney());
                taskIndex++;
            }

            for (int i = 0; i < 30; i++)
            {
                _customers[i] = new P();
                _customers[i].BuyProducts(allProducts);
            }

            foreach (var customer in _customers)
            {
                Random random = new();
                int delay = random.Next(100, 1000);
                Thread.Sleep(delay);
                S leastBusyCash = _cashes.Where(x => x.IsWorking).OrderBy(x => x.GetQueueCount()).First();
                leastBusyCash.TakeQueue(customer);
            }

            Task.WaitAll(cashTasks);
        }
    }
}