using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new SqliteOrderService(
                "C:/Users/zhb/Documents/sqlitedb/order.db");
            service.DeleteAllData(); //删除之前的数据
            for (int i = 1; i <= 10; i++) //填充 10 个随机订单
            {
                service.AddOrder(RandomOrder.RandOrder());
            }

            //用 LINQ 语法查询
            Console.WriteLine("查询总价超过 200 元的订单，按订单 ID 排序。");
            var result = from order in service
                         where order.PriceSum > 200
                         orderby order.OrderId
                         select order;
            foreach (var order in result)
            {
                Console.WriteLine(order);
                Console.WriteLine("---------------------------------");
            }

            Console.WriteLine("查询含单价超过 50 元商品的订单，按订单 ID 排序。");
            result = from order in service
                     where order.OrderDetails.Find(detail => detail.Commodity.Price > 50) != null
                     orderby order.OrderId
                     select order;
            foreach (var order in result)
            {
                Console.WriteLine(order);
                Console.WriteLine("---------------------------------");
            }
        }
    }

    public class RandomOrder
    {
        /// <summary>
        /// 生成一个随机的订单
        /// </summary>
        public static Order RandOrder()
        {
            var client = new Client(RandString(), rand.Next(0, 1234567).ToString());
            var details = new List<OrderDetail>();
            var detailCnt = rand.Next(1, 5);
            for (int i = 1; i <= detailCnt; i++)
            {
                details.Add(RandDetail());
            }
            var order = new Order(client, details);
            return order;
        }

        private static string RandString()
        {
            var s = new StringBuilder();
            for (int i = 1; i <= 10; i++)
            {
                char ch = (char)('a' + rand.Next(0, 25));
                s.Append(ch);
            }
            return s.ToString();
        }

        /// <summary>
        /// 生成随机 decimal，[a, b)
        /// </summary>
        private static decimal RandDecimal(decimal a, decimal b)
        {
            double span = decimal.ToDouble(b - a);
            decimal span2 = decimal.Parse((rand.NextDouble() * span).ToString("N2"));
            return a + span2;
        }

        /// <summary>
        /// 生成一个随机商品
        /// </summary>
        /// <returns></returns>
        private static Commodity RandCommodity()
        {
            return new Commodity(RandString(), RandDecimal(10, 100));
        }

        /// <summary>
        /// 生成一个随机订单详情
        /// </summary>
        /// <returns></returns>
        private static OrderDetail RandDetail()
        {
            int count = rand.Next(1, 5);
            return new OrderDetail(RandString(), RandCommodity(), count);
        }

        private static Random rand = new Random();
    }
}
