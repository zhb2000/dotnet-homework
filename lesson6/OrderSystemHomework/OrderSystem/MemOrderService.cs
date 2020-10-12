using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderSystem
{
    /// <summary>
    /// 订单管理系统（使用内存中的 List）
    /// </summary>
    public class MemOrderService : IEnumerable<Order>, IOrderService
    {
        /// <summary>
        /// 订单列表
        /// </summary>
        public List<Order> Orders { get; private set; } = new List<Order>();

        public int AddOrder(Order order)
        {
            if (order == null)
            {
                throw new NullArgumentException();
            }
            if (Exists(order))
            {
                throw new OrderExistException();
            }
            order.OrderId = idCounter;
            idCounter++;
            Orders.Add(order);
            return order.OrderId;
        }

        public bool Exists(Order order) => Orders.Contains(order);

        public bool Exists(int id) => Orders.Find(order => order.OrderId == id) != null;

        public void RemoveOrder(int id)
        {
            int rmCnt = Orders.RemoveAll(order => order.OrderId == id);
            if (rmCnt == 0)
            {
                throw new OrderNotExistException();
            }
        }

        public void RemoveOrder(Order order)
        {
            if (!Exists(order))
            {
                throw new OrderNotExistException();
            }
            Orders.Remove(order);
        }

        public Order Get(int id)
        {
            return Orders.Find(order => order.OrderId == id);
        }

        public IEnumerator<Order> GetEnumerator()
        {
            foreach (Order order in Orders)
            {
                yield return order;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void ForEach(Action<Order> action)
        {
            foreach (Order order in Orders)
            {
                action?.Invoke(order);
            }
        }

        /// <summary>
        /// 序列化为 XML
        /// </summary>
        /// <param name="path">文件路径</param>
        public void Export(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, Orders);
            }
        }

        /// <summary>
        /// 订单编号计数器
        /// </summary>
        private int idCounter = 0;

        /// <summary>
        /// 从 XML 反序列化
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>OrderSystem 对象</returns>
        public static MemOrderService Import(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                MemOrderService service = new MemOrderService
                {
                    Orders = (List<Order>)serializer.Deserialize(fs)
                };
                int maxId = -1;
                service.Orders.ForEach(order => maxId = Math.Max(maxId, order.OrderId));
                service.idCounter = maxId + 1;
                return service;
            }
        }
    }

    /// <summary>
    /// 订单已存在，在添加订单时抛出
    /// </summary>
    public class OrderExistException : ApplicationException
    { }

    /// <summary>
    /// 订单不存在，在删除时抛出
    /// </summary>
    public class OrderNotExistException : ApplicationException
    { }
}
