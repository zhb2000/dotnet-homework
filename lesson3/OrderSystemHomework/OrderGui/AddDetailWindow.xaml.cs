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
        public AddDetailWindow(OrderViewModel orderVM)
        {
            InitializeComponent();
            this.orderVM = orderVM;
            DataContext = new OrderDetailViewModel(orderVM);
        }

        public OrderDetailViewModel DetailResult;

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            DetailResult = (OrderDetailViewModel)DataContext;
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private OrderViewModel orderVM;
    }
}
