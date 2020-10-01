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
        public AddOrderWindow()
        {
            InitializeComponent();
            DataContext = new OrderViewModel();
        }

        public OrderViewModel OrderResult { get; private set; }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            OrderResult = (OrderViewModel)DataContext;
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void addDetailButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddDetailWindow((OrderViewModel)DataContext);
            bool result = dialog.ShowDialog().GetValueOrDefault(false);
            if (result)
            {
                ((OrderViewModel)DataContext).AddDetail(dialog.DetailResult);
            }
        }

        private void deleteDetailButton_Click(object sender, RoutedEventArgs e)
        {
            var detail = (OrderDetailViewModel)detailDataGrid.SelectedItem;
            if(detail!=null)
            {
                ((OrderViewModel)DataContext).RemoveDetail(detail);
            }
        }
    }
}
