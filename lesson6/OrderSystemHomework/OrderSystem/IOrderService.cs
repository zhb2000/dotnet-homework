using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    public interface IOrderService : IEnumerable<Order>
    {
        /// <summary>
        /// 添加订单，返回订单的 id
        /// </summary>
        /// <param name="order">订单</param>
        /// <returns>订单 id</returns>
        int AddOrder(Order order);

        /// <summary>
        /// 查询订单是否存在
        /// </summary>
        bool Exists(Order order);

        /// <summary>
        /// 用 id 查询订单是否存在
        /// </summary>
        bool Exists(int id);

        /// <summary>
        /// 用 id 删除订单
        /// </summary>
        /// <param name="id">订单 id</param>
        void RemoveOrder(int id);

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="order">订单</param>
        void RemoveOrder(Order order);

        /// <summary>
        /// 获取订单，若订单不存在则返回 null
        /// </summary>
        /// <param name="id">订单 id</param>
        /// <returns>订单，若订单不存在则为 null</returns>
        Order Get(int id);
    }
}
