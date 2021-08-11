using System.Collections.Generic;

namespace VideoStore
{
    public class Customer
    {
        public string Name { get; }
        public List<Rental> Rentals { get; }

        public Customer(string name)
        {
            Name = name;
            Rentals = new List<Rental>();
        }

        public void AddRental(Rental rental)
        {
            Rentals.Add(rental);
        }
    }
}