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

        public Order(Client client, List<OrderDetail> details)
        {
            Client = client;
            Details = details;
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
        /// 订单详情列表
        /// </summary>
        public List<OrderDetail> Details { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal PriceSum 
        {
            get
            {
                decimal sum = 0;
                Details.ForEach(detail => sum += detail.Commodity.Price * detail.Count);
                return sum;
            }
        }

        /// <summary>
        /// 该订单是否包含某件商品
        /// </summary>
        public bool ContainsCommodity(Commodity commodity) => 
            Details.Find(detail => detail.Commodity.Equals(commodity)) != null;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"id: {Id}\n\n")
              .Append($"client:\n{Client}\n\n")
              .Append($"price sum: {PriceSum}\n\n")
              .Append("details:\n");
            Details.ForEach(detail => sb.Append($"{detail}\n"));
            sb.Append("\n");
            return sb.ToString();
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
                && Details.Equals(other.Details);
        }

        // override object.GetHashCode
        public override int GetHashCode() => Client.GetHashCode()
                                           ^ Details.GetHashCode();
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
