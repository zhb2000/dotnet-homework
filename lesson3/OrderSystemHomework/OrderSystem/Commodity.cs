using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    /// <summary>
    /// 商品实体类
    /// </summary>
    [Serializable]
    public class Commodity
    {
        public Commodity() { }

        public Commodity(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }

        private decimal price;
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price
        {
            get => price;
            set => price = value >= 0
                ? value
                : throw new InvalidPriceException(value);
        }

        public override string ToString() => $"name: {Name}, price: {Price}";

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Commodity other = (Commodity)obj;
            return Name == other.Name && Price == other.Price;
        }

        // override object.GetHashCode
        public override int GetHashCode() => Name.GetHashCode() ^ Price.GetHashCode();
    }

    /// <summary>
    /// 价格非法
    /// </summary>
    public class InvalidPriceException : ApplicationException
    {
        public InvalidPriceException(decimal price)
            : base($"{price} is not a valid price.") { }
    }
}
