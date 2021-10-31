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
            _cashes.Add(new S() { CashIndex = 1, CasherDelayTime = 1200, IsWorking = true });
            _cashes.Add(new S() { CashIndex = 2, CasherDelayTime = 2200, IsWorking = true });
            _cashes.Add(new S() { CashIndex = 3, CasherDelayTime = 2900, IsWorking = true });
            _cashes.Add(new S() { CashIndex = 4, CasherDelayTime = 1000, IsWorking = true });
            _cashes.Add(new S() { CashIndex = 5, CasherDelayTime = 3200, IsWorking = true });

            Console.WriteLine($"Cashes are set");
        }

        public void Run()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread cashThread = new Thread(_cashes[i].GetMoney);
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



            //foreach (P customer in _customers)
            //{
            //    Thread customerthread = new Thread(new ParameterizedThreadStart(customer.TakeQueue));
            //    customerthread.Start(_cashes);
            //}
        }


    }
}
