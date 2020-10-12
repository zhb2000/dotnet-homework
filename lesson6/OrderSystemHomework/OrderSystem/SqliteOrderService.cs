using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    /// <summary>
    /// 订单管理系统（使用 SQLite 数据库）
    /// </summary>
    class SqliteOrderService : IOrderService
    {
        private readonly OrderContext context;
        public SqliteOrderService(string dataSource)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
            optionsBuilder.UseSqlite($"Data Source={dataSource}");
            context = new OrderContext(optionsBuilder.Options);
            context.Database.EnsureCreated();
        }

        public int AddOrder(Order order)
        {
            context.Add(order);
            context.SaveChanges();
            return order.OrderId;
        }

        public bool Exists(Order order) => context.Orders.Contains(order);

        public bool Exists(int id) => context.Orders.Find(id) != null;

        public Order Get(int id) => context.Orders.Find(id);

        public void RemoveOrder(int id)
        {
            var order = context.Orders.Find(id);
            if (order == null)
            {
                throw new OrderNotExistException();
            }
            else
            {
                RemoveOrder(order);
            }
        }

        public void RemoveOrder(Order order)
        {
            if (!Exists(order))
            {
                throw new OrderNotExistException();
            }
            else
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 删除所有数据（测试用）
        /// </summary>
        public void DeleteAllData()
        {
            var clients = new List<Client>();
            foreach (var client in context.Clients)
            {
                clients.Add(client);
            }
            context.RemoveRange(clients.ToArray());
            context.SaveChanges();
        }

        public IEnumerator<Order> GetEnumerator()
        {
            var orders = new List<Order>();
            foreach (var order in context.Orders)
            {
                orders.Add(order);
            }
            foreach (var order in orders)
            {
                yield return order;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
    }
}
