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

        public OrderDetail(string address) => Address = address;

        private string address;
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get => address;
            set => address = value.Trim();
        }

        public override string ToString() => $"address: {Address}";

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            OrderDetail other = (OrderDetail)obj;
            return Address == other.Address;
        }

        // override object.GetHashCode
        public override int GetHashCode() => Address.GetHashCode();
    }
}
