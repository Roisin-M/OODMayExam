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

namespace OODMayExam
{
    /// <summary>
    /// Interaction logic for CustomerSearchResults.xaml
    /// </summary>
    public partial class CustomerSearchResults : Window
    {
        private RestaurantData db = new RestaurantData("OODExam_RoisinMuldoon");
        private List<Customer> _customers;

        public CustomerSearchResults(List<Customer> customers)
        {
            InitializeComponent();
            _customers = customers;
            PopulateCustomerListBox();
        }

        private void PopulateCustomerListBox()
        {
            lbx_Customers.Items.Clear(); // Clear existing items if any

            foreach (var customer in _customers)
            {
                string displayText = $"{customer.Name} ({customer.ContactNumber})";
                lbx_Customers.Items.Add(displayText);
            }
        }
    }
}
