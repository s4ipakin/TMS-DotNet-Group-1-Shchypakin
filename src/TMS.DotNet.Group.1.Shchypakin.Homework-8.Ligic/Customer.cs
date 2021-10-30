using System;
using System.Collections.Generic;
using System.Linq;
using TMS.DotNet.Group._1.Shchypakin.Homework_8.Data;
using TMS.DotNet.Group._1.Shchypakin.Homework_8.Ligic.Interfaces;

namespace TMS.DotNet.Group._1.Shchypakin.Homework_8.Ligic
{
    public class Customer : ICustomer
    {
        private readonly List<Product> boughtProducts = new();

        public List<Product> GetBoughtProducts() => boughtProducts;

        public void BuyProducts(Dictionary<ProductName, Product> allProducts)
        {
            Random random = new Random();
            int productsCount = random.Next(1, 10);
            List<int> productTypes = Enum.GetValues(typeof(ProductName))
                   .OfType<ProductName>().Select(x => (int)x)
                   .ToList();
            int productType = productTypes[random.Next(0, productTypes.Count - 1)];

            for (int i = 1; i <= productsCount; i++)
            {
                boughtProducts.Add(allProducts[(ProductName)productType]);
            }
        }
    }
}