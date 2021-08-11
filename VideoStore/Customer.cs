using System.Collections.Generic;

namespace VideoStore
{
    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
            Rentals = new List<Rental>();
        }

        public string Name { get; }
        public List<Rental> Rentals { get; }

        public void AddRental(Rental rental)
        {
            Rentals.Add(rental);
        }
    }
}