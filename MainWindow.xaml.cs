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
using System.Collections.Generic;

namespace WpfPriorityQueue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PriorityQueue<Customer> queue;
        Random rng = new Random();

        public MainWindow()
        {
            InitializeComponent();
            
            queue = new PriorityQueue<Customer>();
            PopulateQueue(queue, new Customer("Simon", rng.Next(1, 3)), new Customer("Fillip", rng.Next(1, 3)), new Customer("Jokum", rng.Next(1, 3)));

            PopulateListbox(queue);
        }

        private void btnTagOpkald_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                queue.Dequeue();
                lstboxQueue.Items.Clear();
                PopulateListbox(queue);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
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
        
        private void PopulateListbox(PriorityQueue<Customer> cs)
        {
            for (int i = 0; i < queue.Length; i++)
            {
                lstboxQueue.Items.Add(string.Format("{0}'s value is {1} ", cs.OnThisIndex(i), Enum.GetName(typeof(Customer.Values), cs.OnThisIndex(i).CustomerValue)));
            }
            
        }

        private void PopulateQueue(PriorityQueue<Customer> queue, params Customer[] ts)
        {
            foreach (Customer c in ts)
            {
                if (c.CustomerValue == 2)
                {
                    queue.AddPriority(c);
                }
                else
                {
                    queue.Add(c);
                }
            }
        }
    }
}
