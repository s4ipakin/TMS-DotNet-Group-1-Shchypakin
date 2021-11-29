using System.Collections.Generic;
using TMS.DotNet.Group._1.Shchypakin.Homework_8.Data;

namespace TMS.DotNet.Group._1.Shchypakin.Homework_8.Ligic.Interfaces
{
    public interface ICustomer
    {
        /// <summary>
        /// Adds randomly Products to the local list
        /// </summary>
        /// <param name="allProducts"></param>
        public void BuyProducts(Dictionary<ProductName, Product> allProducts);

        /// <summary>
        /// Returns the local list of bought products
        /// </summary>
        /// <returns></returns>
        public List<Product> GetBoughtProducts();
    }
}