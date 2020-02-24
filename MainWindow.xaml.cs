using System;
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

namespace WpfPriorityQueue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PriorityQueue<Customer> queue;
        public MainWindow()
        {
            InitializeComponent();
            Customer cs = new Customer("Simon", 1);
            Customer cs2 = new Customer("Fillip", 2);

            queue = new PriorityQueue<Customer>(cs, cs2);
        }

        private void btnTagOpkald_Click(object sender, RoutedEventArgs e)
        {
            Customer cs = new Customer("Simon", 1);

            lstboxQueue.Items.Add(string.Format("{0}'s value is {1} ", cs, Enum.GetName(typeof(Customer.Values), cs.CustomerValue)));
            buttonFlicker();
        }

        

        private void btnHangUp_Click(object sender, RoutedEventArgs e)
        {
            buttonFlicker();
        }
        
        private void buttonFlicker()
        {
            btnHangUp.IsEnabled = !btnHangUp.IsEnabled;
            btnHangUp.IsDefault = !btnHangUp.IsDefault;
            btnTagOpkald.IsEnabled = !btnTagOpkald.IsEnabled;
            btnTagOpkald.IsDefault = !btnTagOpkald.IsDefault;
        }
    }
}
