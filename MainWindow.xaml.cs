using System;
using System.Windows;
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
        DispatcherTimer timer = new DispatcherTimer(); //Timer til opkaldsvarighed
        DispatcherTimer customerTimer = new DispatcherTimer(); //Timer til hvornår en ny kunde kommer i køen
        
        private int Timer { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            customerTimer.Tick += CustomerTimer_Tick;
            customerTimer.Interval = new TimeSpan(0, 0, 5); 
            customerTimer.Start();

            PopulateQueue(queue, new Customer("Simon", rng.Next(1, 3)), new Customer("Fillip", rng.Next(1, 3)), new Customer("Jokum", rng.Next(1, 3)), new Customer("Isak", rng.Next(1, 3)));
            PopulateListbox(queue);
        }

        private void CustomerTimer_Tick(object sender, EventArgs e)
        {
            PopulateQueue(queue, new Customer(CustomerNames.names[rng.Next(CustomerNames.names.Length)], rng.Next(1, 3)));
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
                txtOpkald.Text = "I et opkald med " + queue.Peek();
                queue.Dequeue();
                PopulateListbox(queue);
                Timer = 0;
                lblTimer.Content = Timer;
                timer.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Køen er tom");
                return;
            }
            buttonFlicker();
        }

        private void btnHangUp_Click(object sender, RoutedEventArgs e)
        {
            txtOpkald.Text = "Opkald afsluttet";
            timer.Stop();
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
            lstboxQueue.Items.Clear();
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
