using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OrderSystem;

namespace OrderGui
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var bindingSource = new MainWinViewModel(new OrderService());
            DataContext = bindingSource;
        }

        /// <summary>
        /// 创建装有随机订单的 Service（测试用）
        /// </summary>
        static OrderService ServiceWithRand()
        {
            OrderService service = new OrderService();
            int cnt = 10;
            for (int i = 1; i <= cnt; i++)
            {
                service.AddOrder(RandomOrder.RandOrder());
            }
            return service;
        }

        private void randButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWinViewModel)DataContext).SetDataSource(ServiceWithRand());
        }

        private void addOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddOrderWindow();
            bool result = dialog.ShowDialog().GetValueOrDefault(false);
            if (result)
            {
                ((MainWinViewModel)DataContext).AddOrder(dialog.OrderResult);
            }
        }

        private void removeOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var order = (OrderViewModel)orderDataGrid.SelectedItem;
            if (order != null)
            {
                ((MainWinViewModel)DataContext).RemoveOrder(order);
            }
        }

        private void exportButton_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string folderPath = dialog.SelectedPath;
                    try
                    {
                        ((MainWinViewModel)DataContext).Export(folderPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    MessageBox.Show($"Export succeeded.\n" +
                        $"The file is at \"{folderPath}\\service.xml\".");
                }
            }
        }

        private void importButton_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.OpenFileDialog())
            {
                dialog.Multiselect = false;
                dialog.Filter = "XML File(*.xml)|*.xml";
                var result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string filepath = dialog.FileName;
                    try
                    {
                        ((MainWinViewModel)DataContext).Import(filepath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWinViewModel)DataContext).Refresh();
        }

        private void addDetailButton_Click(object sender, RoutedEventArgs e)
        {
            var order = (OrderViewModel)orderDataGrid.SelectedItem;
            if (order != null)
            {
                var dialog = new AddDetailWindow(order);
                bool result = dialog.ShowDialog().GetValueOrDefault(false);
                if (result)
                {
                    order.AddDetail(dialog.DetailResult);
                }
            }
        }

        private void removeDetailButton_Click(object sender, RoutedEventArgs e)
        {
            var detail = (OrderDetailViewModel)detailDataGrid.SelectedItem;
            if (detail != null)
            {
                var order = (OrderViewModel)orderDataGrid.SelectedItem;
                order.RemoveDetail(detail);
            }
        }

        public class MainWinViewModel
        {
            public MainWinViewModel(OrderService service)
            {
                Orders = new ObservableCollection<OrderViewModel>();
                SetDataSource(service);
            }

            public ObservableCollection<OrderViewModel> Orders { get; }

            public void SetDataSource(OrderService service)
            {
                Orders.Clear();
                this.service = service;
                service.ForEach(order => Orders.Add(new OrderViewModel(order)));
            }

            public void Refresh() => SetDataSource(service);

            public void RemoveOrder(OrderViewModel order)
            {
                service.RemoveOrder(order.Id);
                Orders.Remove(order);
            }

            public void AddOrder(OrderViewModel order)
            {
                service.AddOrder(order.OrderEntity);
                Orders.Add(order);
            }

            public void Export(string folderPath)
                => service.Export(folderPath + @"\service.xml");

            public void Import(string filepath)
                => SetDataSource(OrderService.Import(filepath));

            private OrderService service;
        }

        public class OrderViewModel : INotifyPropertyChanged
        {
            public OrderViewModel(Order order)
            {
                this.OrderEntity = order;
                Details = new ObservableCollection<OrderDetailViewModel>();
                order.Details.ForEach(
                    detail => Details.Add(new OrderDetailViewModel(detail, this)));
            }

            /// <summary>
            /// 创建一个空的 OrderViewModel
            /// </summary>
            public OrderViewModel()
            {
                OrderEntity = new Order(new Client(), new List<OrderDetail>());
                Details = new ObservableCollection<OrderDetailViewModel>();
            }

            public int Id
            {
                get => OrderEntity.Id;
            }

            public string ClientName
            {
                get => OrderEntity.Client.Name;
                set => OrderEntity.Client.Name = value;
            }

            public string ClientPhone
            {
                get => OrderEntity.Client.Phone;
                set
                {
                    try
                    {
                        OrderEntity.Client.Phone = value;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

            public decimal PriceSum { get => OrderEntity.PriceSum; }

            public ObservableCollection<OrderDetailViewModel> Details { get; }

            public void AddDetail(OrderDetailViewModel detail)
            {
                OrderEntity.Details.Add(detail.DetailEntity);
                Details.Add(detail);
                NotifyPriceSumChange();
            }

            public void RemoveDetail(OrderDetailViewModel detail)
            {
                int index = Details.IndexOf(detail);
                OrderEntity.Details.RemoveAt(index);
                Details.RemoveAt(index);
                NotifyPriceSumChange();
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public void NotifyPropertyChange(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public void NotifyPriceSumChange() => NotifyPropertyChange("PriceSum");

            /// <summary>
            /// 关联的订单详情实体类
            /// </summary>
            public Order OrderEntity { get; }
        }

        public class OrderDetailViewModel
        {
            public OrderDetailViewModel(OrderDetail detail, OrderViewModel fatherVM)
            {
                DetailEntity = detail;
                this.fatherVM = fatherVM;
            }

            /// <summary>
            /// 创建一个空的 OrderDetailViewModel
            /// </summary>
            public OrderDetailViewModel(OrderViewModel fatherVM)
            {
                DetailEntity = new OrderDetail();
                this.fatherVM = fatherVM;
            }

            public string Address
            {
                get => DetailEntity.Address;
                set => DetailEntity.Address = value;
            }

            public string CommodityName
            {
                get => DetailEntity.Commodity.Name;
                set => DetailEntity.Commodity.Name = value;
            }

            public decimal CommodityPrice
            {
                get => DetailEntity.Commodity.Price;
                set
                {
                    try
                    {
                        DetailEntity.Commodity.Price = value;
                        fatherVM.NotifyPropertyChange("PriceSum");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

            public int Count
            {
                get => DetailEntity.Count;
                set
                {
                    try
                    {
                        DetailEntity.Count = value;
                        fatherVM.NotifyPriceSumChange();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

            /// <summary>
            /// 关联的订单详情实体类
            /// </summary>
            public OrderDetail DetailEntity { get; }

            private readonly OrderViewModel fatherVM;
        }
    }
}
