using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    /// <summary>
    /// 订单详细
    /// </summary>
    [Serializable]
    public class OrderDetail
    {
        public OrderDetail() { }
        public OrderDetail(string address, Commodity commodity, int count)
        {
            if (address == null || commodity == null)
            {
                throw new NullArgumentException();
            }
            if (count <= 0)
            {
                throw new InvalidCountException(count);
            }
            Address = address;
            Commodity = commodity;
            Count = count;
        }

        [Key]
        public int OrderDetailId { get; set; }

        private string address;/* = "";*/
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get => address;
            set => address = value.Trim();
        }

        /// <summary>
        /// 商品
        /// </summary>
        public Commodity Commodity { get; set; } /*= new Commodity();*/

        private int count = 1;
        /// <summary>
        /// 商品数量
        /// </summary>
        public int Count
        {
            get => count;
            set => count = (value > 0)
                            ? value
                            : throw new InvalidCountException(value);
        }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        
        //public Order Order { get; set; }

        public override string ToString()
        {
            return $"OrderDetailId: {OrderDetailId}\n" +
                   $"address: {Address}\n" +
                   $"commodity: {Commodity}\n" +
                   $"count: {Count}";
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            OrderDetail other = (OrderDetail)obj;
            return Address == other.Address
                   && Commodity == other.Commodity
                   && Count == other.Count;
        }

        // override object.GetHashCode
        public override int GetHashCode() => Address.GetHashCode()
                                             ^ Commodity.GetHashCode()
                                             ^ Count;

    }

    /// <summary>
    /// 数量不合法
    /// </summary>
    public class InvalidCountException : ApplicationException
    {
        public InvalidCountException(int count)
            : base($"Count {count} is invalid.") { }
    }
}
