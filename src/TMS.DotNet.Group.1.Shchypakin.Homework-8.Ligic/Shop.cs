using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            allProducts.Add(ProductName.Beaf, new Product(ProductName.Beaf, 15));
            allProducts.Add(ProductName.Bread, new Product(ProductName.Bread, 3));
            allProducts.Add(ProductName.Wine, new Product(ProductName.Wine, 150));
            allProducts.Add(ProductName.Cheese, new Product(ProductName.Cheese, 19));
            allProducts.Add(ProductName.Lemon, new Product(ProductName.Lemon, 10));
            allProducts.Add(ProductName.Melon, new Product(ProductName.Melon, 25));
            allProducts.Add(ProductName.Tuna, new Product(ProductName.Tuna, 35));
        }

        public void SetCashes()
        {
            Random random = new Random();
            bool isAnyWorking = false;
            for (int i = 1; i < 6; i++)
            {
                _cashes.Add(new S() { CashIndex = i, CasherDelayTime = random.Next(1000, 3500) });
                if (_cashes[i-1].IsWorking)
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

        public void Run()
        {
            foreach (S cash in _cashes)
            {
                Thread cashThread = new Thread(cash.GetMoney);
                cashThread.Start();
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
        }


    }
}
