using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    /// <summary>
    /// 订单实体类
    /// </summary>
    [Serializable]
    public class Order
    {
        public Order() { }

        public Order(Client client, OrderDetail detail, Commodity commodity, int count)
        {
            if (client == null || detail == null || commodity == null)
            {
                throw new NullArgumentException();
            }
            if(count<=0)
            {
                throw new InvalidCountException(count);
            }
            Client = client;
            Detail = detail;
            Commodity = commodity;
            CommodityCount = count;
        }

        private int id = -1;
        /// <summary>
        /// 订单编号
        /// </summary>
        public int Id
        {
            get => id >= 0 ? id : throw new ApplicationException();
            set => id = value;
        }

        /// <summary>
        /// 订单客户
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// 订单详情
        /// </summary>
        public OrderDetail Detail { get; set; }

        /// <summary>
        /// 货物
        /// </summary>
        public Commodity Commodity { get; set; }

        /// <summary>
        /// 货物的数量
        /// </summary>
        public int CommodityCount { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal PriceSum { get => Commodity.Price * CommodityCount; }

        public override string ToString()
        {
            return $"id: {Id}\n\n" +
                   $"client:\n{Client}\n\n" +
                   $"detail:\n{Detail}\n\n" +
                   $"commodity:\n{Commodity}\n\n" +
                   $"commodity count: {CommodityCount}\n\n" +
                   $"price sum: {PriceSum}";
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Order other = (Order)obj;
            return Client.Equals(other.Client)
                && Detail.Equals(other.Detail)
                && Commodity.Equals(other.Commodity)
                && CommodityCount == other.CommodityCount;
        }

        // override object.GetHashCode
        public override int GetHashCode() => Client.GetHashCode()
                                           ^ Detail.GetHashCode()
                                           ^ Commodity.GetHashCode()
                                           ^ CommodityCount;
    }

    /// <summary>
    /// 数量不合法
    /// </summary>
    public class InvalidCountException : ApplicationException
    {
        public InvalidCountException(int count)
            : base($"Count {count} is invalid.") { }
    }

    /// <summary>
    /// 参数为 null
    /// </summary>
    public class NullArgumentException : ApplicationException
    {
        public NullArgumentException(string argName)
            : base($"Argument \"{argName}\" is null.") { }
        public NullArgumentException() { }
    }
}
