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
using MainWinViewModel = OrderGui.MainWindow.MainWinViewModel;
using OrderViewModel = OrderGui.MainWindow.OrderViewModel;
using OrderDetailViewModel = OrderGui.MainWindow.OrderDetailViewModel;

namespace OrderGui
{
    /// <summary>
    /// AddOrderWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        /// <summary>
        /// 添加订单窗口的 View Model
        /// </summary>
        private readonly OrderViewModel vm;

        public AddOrderWindow()
        {
            InitializeComponent();
            vm = new OrderViewModel();
            DataContext = vm;
        }

        /// <summary>
        /// 通过 OrderResult 属性获取添加订单的结果
        /// </summary>
        public OrderViewModel OrderResult { get; private set; }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            OrderResult = vm;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void AddDetailButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddDetailWindow(vm);
            bool result = dialog.ShowDialog().GetValueOrDefault(false);
            if (result)
            {
                vm.AddDetail(dialog.DetailResult);
            }
        }

        private void DeleteDetailButton_Click(object sender, RoutedEventArgs e)
        {
            var detail = (OrderDetailViewModel)detailDataGrid.SelectedItem;
            if (detail != null)
            {
                vm.RemoveDetail(detail);
            }
        }
    }
}
