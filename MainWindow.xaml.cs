using System;
using System.Windows;
using System.Diagnostics;
using System.Windows.Threading;

namespace WpfPriorityQueue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PriorityQueue<Customer> queue = new PriorityQueue<Customer>();
        Random rng = new Random();
        DispatcherTimer timer = new DispatcherTimer();
        
        private int Timer { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);

            PopulateQueue(queue, new Customer("Simon", rng.Next(1, 3)), new Customer("Fillip", rng.Next(1, 3)), new Customer("Jokum", rng.Next(1, 3)));
            PopulateListbox(queue);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTimer.Content = ++Timer;
        }

        private void btnTagOpkald_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                queue.Dequeue();
                lstboxQueue.Items.Clear();
                PopulateListbox(queue);
                txtOpkald.Text = "I et opkald med " + queue.Peek();
                Timer = 0;
                lblTimer.Content = Timer;
                timer.Start();
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
