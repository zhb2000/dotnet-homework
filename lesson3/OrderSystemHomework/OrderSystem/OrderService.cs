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
    /// 订单管理系统
    /// </summary>
    public class OrderService : IEnumerable<Order>
    {
        /// <summary>
        /// 添加订单，返回订单的 id
        /// </summary>
        /// <param name="order">订单</param>
        /// <returns>订单 id</returns>
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
            order.Id = idCounter;
            idCounter++;
            orders.Add(order);
            return order.Id;
        }

        /// <summary>
        /// 查询订单是否存在
        /// </summary>
        public bool Exists(Order order) => orders.Contains(order);

        /// <summary>
        /// 用 id 查询订单是否存在
        /// </summary>
        public bool Exists(int id) => orders.Find(order => order.Id == id) != null;

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id">订单 id</param>
        public void RemoveOrder(int id)
        {
            int rmCnt = orders.RemoveAll(order => order.Id == id);
            if (rmCnt == 0)
            {
                throw new OrderNotExistException();
            }
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="order">订单</param>
        public void RemoveOrder(Order order)
        {
            if (!Exists(order))
            {
                throw new OrderNotExistException();
            }
            orders.Remove(order);
        }

        /// <summary>
        /// 获取订单，若订单不存在则返回 null
        /// </summary>
        /// <param name="id">订单 id</param>
        /// <returns>订单，若订单不存在则为 null</returns>
        public Order Get(int id)
        {
            return orders.Find(order => order.Id == id);
        }

        public IEnumerator<Order> GetEnumerator()
        {
            foreach (Order order in orders)
            {
                yield return order;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// 序列化为 XML
        /// </summary>
        /// <param name="path">文件路径</param>
        public void Export(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, orders);
            }
        }

        /// <summary>
        /// 订单列表
        /// </summary>
        private List<Order> orders = new List<Order>();
        /// <summary>
        /// 订单编号计数器
        /// </summary>
        private int idCounter = 0;

        /// <summary>
        /// 从 XML 反序列化
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>OrderSystem 对象</returns>
        public static OrderService Import(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                OrderService service = new OrderService
                {
                    orders = (List<Order>)serializer.Deserialize(fs)
                };
                int maxId = -1;
                service.orders.ForEach(order => maxId = Math.Max(maxId, order.Id));
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
