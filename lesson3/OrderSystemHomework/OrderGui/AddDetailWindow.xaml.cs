using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using OrderViewModel = OrderGui.MainWindow.OrderViewModel;
using OrderDetailViewModel = OrderGui.MainWindow.OrderDetailViewModel;

namespace OrderGui
{
    /// <summary>
    /// AddDetailWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddDetailWindow : Window
    {
        /// <summary>
        /// 添加订单详情窗口的 View Model
        /// </summary>
        private readonly OrderDetailViewModel vm;

        /// <param name="orderVM">所属的订单的 View Model</param>
        public AddDetailWindow(OrderViewModel orderVM)
        {
            InitializeComponent();
            this.orderVM = orderVM;
            vm = new OrderDetailViewModel(orderVM);
            DataContext = vm;
        }

        public OrderDetailViewModel DetailResult;

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            DetailResult = vm;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private readonly OrderViewModel orderVM;
    }
}
