using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OODMayExam
{
    public class Booking
    {
        //properties
        public int BookingId { get; set; }
        public DateTime BookingsDate { get; set; }
        public int NumberOfParticipants { get; set; }
        //foreign key id
        public int CustomerId { get; set; }
        //navigation property
        public virtual Customer Customer { get; set; }

    }
    public class Customer
    {
        //properties
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        //A customer can have many Bookings
        //Model a one-to-many relationship
        public List<Booking> Bookings { get; set; }

        //constructors
        public Customer()
        {
            Bookings = new List<Booking>();
        }
    }
    public class RestaurantData : DbContext
    {
        //comstructor
        public RestaurantData(string databaseName):base(databaseName) { }
        // 2 dbSets properties
        public DbSet<Booking> Bookings { get; set;}
        public DbSet<Customer> Customers { get;set; }
    }
}
