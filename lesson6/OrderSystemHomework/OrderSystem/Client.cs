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
    /// 客户实体类
    /// </summary>
    [Serializable]
    public class Client
    {
        public Client() { }
        public Client(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        [Key]
        public int ClientId { get; set; }

        private string name = "";
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get => name; set => name = value.Trim(); }

        private string phone = "";
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Phone
        {
            get => phone;
            set => phone = IsPhoneValid(value)
                ? value.Trim()
                : throw new InvalidPhoneException(value);
        }

        public override string ToString()
        {
            return $"ClientId: {ClientId}, name: {Name}, phone: {Phone}";
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Client other = (Client)obj;
            return Name == other.Name && Phone == other.Phone;
        }

        // override object.GetHashCode
        public override int GetHashCode() => Name.GetHashCode() ^ Phone.GetHashCode();

        private static bool IsPhoneValid(string phone)
        {
            foreach (char ch in phone)
            {
                if (!char.IsDigit(ch) && !char.IsWhiteSpace(ch) && ch != '-')
                {
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary>
    /// 电话号码非法
    /// </summary>
    class InvalidPhoneException : ApplicationException
    {
        public InvalidPhoneException(string phone)
            : base($"\"{phone}\" is not a valid phone number.") { }
    }
}
