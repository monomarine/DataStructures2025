using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _02._05_EventsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Order> _orders = new();
        public MainWindow()
        {
            InitializeComponent();
            _orders.Add(new Order(1, "Иванов"));
            _orders.Add(new Order(2, "Петров"));
            _orders.Add(new Order(3, "Кузнецов"));
            _orders.Add(new Order(4, "Семенов"));
            _orders.Add(new Order(5, "Кутузов"));

            ordersListBox.ItemsSource = _orders;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(ordersListBox.SelectedItem is Order)
            {
                Order order = (Order)ordersListBox.SelectedItem;
                order.PaidOrder(5000);

            }
        }

        private void OpenMonitor_Click(object sender, RoutedEventArgs e)
        {
            Monitor monitor = new(_orders);
            monitor.Show();
        }
    }
}