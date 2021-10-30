namespace TMS.DotNet.Group._1.Shchypakin.Homework_8.Data
{
    public class Product
    {
        private readonly ProductName _name;
        private readonly double _price;

        public Product(ProductName name, double price)
        {
            _name = name;
            _price = price;
        }

        /// <summary>
        /// Product name
        /// </summary>
        public ProductName Name => _name;

        /// <summary>
        /// Product price
        /// </summary>
        public double Price => _price;
    }
}