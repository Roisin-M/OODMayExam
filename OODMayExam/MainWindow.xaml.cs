using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace OODMayExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RestaurantData db = new RestaurantData("OODExam_RoisinMuldoon");
        public MainWindow()
        {

            InitializeComponent();
        }
        private void dp_Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dp_Date.SelectedDate.HasValue)
            {
                DateTime selectedDate = dp_Date.SelectedDate.Value;
                UpdateBookingList(selectedDate);
                UpdateAvailableAndCapacity(selectedDate);
            }
        }

        private void UpdateBookingList(DateTime date)
        {
            var bookings = db.Bookings
                             .Include(b => b.Customer)  
                             .Where(b => DbFunctions.TruncateTime(b.BookingsDate) == date.Date)
                             .ToList();

            lbx_BookingDetails.Items.Clear();

            foreach (var booking in bookings)
            {
                string displayText = $"{booking.Customer.Name} ({booking.Customer.ContactNumber}) - Party of {booking.NumberOfParticipants}";
                lbx_BookingDetails.Items.Add(displayText);
            }
        }

        private void UpdateAvailableAndCapacity(DateTime date)
        {
             const int TOTAL_CAPACITY = 40;  
            int bookedSeats = db.Bookings
                                 .Where(b => DbFunctions.TruncateTime(b.BookingsDate) == date.Date)
                                 .Sum(b => b.NumberOfParticipants);

            int availableSeats = TOTAL_CAPACITY - bookedSeats;

            tblk_Capacity.Text = TOTAL_CAPACITY.ToString();
            tblk_NumBookings.Text = bookedSeats.ToString();
            tblk_Available.Text = availableSeats.ToString();
        }
        private void btn_CustomerSearch_Click(object sender, RoutedEventArgs e)
        {
            string customerName = tb_CustomerName.Text;
            var customers = db.Customers.Where(c => c.Name.Contains(customerName)).ToList();

            // Assuming CustomerSearchResults is initialized to take a list of customers
            var searchWindow = new CustomerSearchResults(customers);
            searchWindow.Show();
        }

    }
}
