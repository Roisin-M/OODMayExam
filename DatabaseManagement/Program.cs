using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODMayExam;
using System.Data.Entity;

namespace DatabaseManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create Db Model
            RestaurantData db = new RestaurantData("OODExam_RoisinMuldoon");
            //create some Bookings
            Booking b1 = new Booking() { BookingsDate = new DateTime(2024, 05, 13), NumberOfParticipants = 2 };
            Booking b2 = new Booking() { BookingsDate = new DateTime(2024, 05, 10), NumberOfParticipants = 5 };
            Booking b3 = new Booking() { BookingsDate = new DateTime(2024, 05, 11), NumberOfParticipants = 8 };

            //create some Customers
            Customer c1 = new Customer() { Name = "Tom Jones", ContactNumber = "086-123 4567" };
            Customer c2 = new Customer() { Name = "Mary Smith", ContactNumber = "086 546 3214" };
            Customer c3 = new Customer() { Name = "Jo Doyle", ContactNumber = "087 1221 222" };
            //add bookings to customers
            c1.Bookings.Add(b1);
            c2.Bookings.Add(b2);
            c3.Bookings.Add(b3);

            //add to db
            db.Bookings.Add(b1);
            db.Bookings.Add(b2);
            db.Bookings.Add(b3);
            db.Customers.Add(c1);
            db.Customers.Add(c2);
            db.Customers.Add(c3);

            //save changes
            db.SaveChanges();

            // i have an sql server error, seems to not work on this machine 
        }
    }
}
