using System;
using System.Collections.Generic;
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

        private string address;
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
        public Commodity Commodity { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int Count { get; set; }

        public override string ToString()
        {
            return $"address: {Address}\n" +
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
