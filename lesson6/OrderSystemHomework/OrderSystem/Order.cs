using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Order()
        {
            //Client = new Client();
            //OrderDetails = new List<OrderDetail>();
        }

        public Order(Client client, List<OrderDetail> details)
        {
            Client = client;
            OrderDetails = details;
        }

        private int id;
        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderId
        {
            get => id;
            set => id = value;
        }

        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        /// <summary>
        /// 订单客户
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// 订单详情列表
        /// </summary>
        public virtual List<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        [NotMapped]
        public decimal PriceSum
        {
            get
            {
                decimal sum = 0;
                if (OrderDetails == null)
                    return 0;
                foreach (var detail in OrderDetails)
                {
                    if (detail != null && detail.Commodity != null)
                        sum += detail.Commodity.Price * detail.Count;
                }
                /*OrderDetails.ForEach(
                    detail => sum += detail.Commodity.Price * detail.Count);*/
                return sum;
            }
        }

        /// <summary>
        /// 该订单是否包含某件商品
        /// </summary>
        public bool ContainsCommodity(Commodity commodity) =>
            OrderDetails.Find(detail => detail.Commodity.Equals(commodity)) != null;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"OrderId: {OrderId}\n\n")
              .Append($"client:\n{Client}\n\n")
              .Append($"price sum: {PriceSum}\n\n")
              .Append("details:\n");
            OrderDetails.ForEach(detail => sb.Append($"{detail}\n"));
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
                && OrderDetails.Equals(other.OrderDetails);
        }

        // override object.GetHashCode
        public override int GetHashCode() => Client.GetHashCode()
                                           ^ OrderDetails.GetHashCode();
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
