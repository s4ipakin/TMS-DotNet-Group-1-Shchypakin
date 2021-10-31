using System;
using TMS.DotNet.Group._1.Shchypakin.Homework_8.Data;
using TMS.DotNet.Group._1.Shchypakin.Homework_8.Ligic;
using TMS.DotNet.Group._1.Shchypakin.Homework_8.Ligic.Interfaces;

namespace TMS.DotNet.Group._1.Shchypakin.Homework_8.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop<Cash, Customer> shop = new Shop<Cash, Customer>();
            shop.SetCashes();
            shop.Run();
        }
    }
}
