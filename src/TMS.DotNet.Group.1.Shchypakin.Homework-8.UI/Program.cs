using TMS.DotNet.Group._1.Shchypakin.Homework_8.Data;
using TMS.DotNet.Group._1.Shchypakin.Homework_8.Ligic;

namespace TMS.DotNet.Group._1.Shchypakin.Homework_8.UI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Shop<Cash, Customer> shop = new Shop<Cash, Customer>();
            shop.SetCashes();
            shop.Run();
        }
    }
}