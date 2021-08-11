using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoStore;

namespace VideoStoreTests
{
    [TestClass]
    public class VideoStoreTest
    {
        private Customer customer;

        [TestInitialize]
        public void SetUp()
        {
            customer = new Customer("Fred");
        }

        [TestMethod]
        public void TestSingleNewReleaseStatement()
        {
            customer.AddRental(new Rental(new Movie("The Cell", MovieType.Regular), 3, RentalType.NewRelease));
            
            Assert.AreEqual("Rental Record for Fred\n\tThe Cell\t9\nYou owed 9\nYou earned 2 frequent renter points\n", StatementService.BuildStatement(customer));
        }

        [TestMethod]
        public void TestDualNewReleaseStatement()
        {
            customer.AddRental(new Rental(new Movie("The Cell", MovieType.Regular), 3, RentalType.NewRelease));
            customer.AddRental(new Rental(new Movie("The Tigger Movie", MovieType.Regular), 3, RentalType.NewRelease));
            
            Assert.AreEqual("Rental Record for Fred\n\tThe Cell\t9\n\tThe Tigger Movie\t9\nYou owed 18\nYou earned 4 frequent renter points\n", StatementService.BuildStatement(customer));
        }

        [TestMethod]
        public void TestSingleChildrensStatement()
        {
            customer.AddRental(new Rental(new Movie("The Tigger Movie", MovieType.Childrens), 3, RentalType.Regular));
            
            Assert.AreEqual("Rental Record for Fred\n\tThe Tigger Movie\t1.5\nYou owed 1.5\nYou earned 1 frequent renter points\n", StatementService.BuildStatement(customer));
        }

        [TestMethod]
        public void TestMultipleRegularStatement()
        {
            customer.AddRental(new Rental(new Movie("Plan 9 from Outer Space", MovieType.Regular), 1, RentalType.Regular));
            customer.AddRental(new Rental(new Movie("8 1/2", MovieType.Regular), 2, RentalType.Regular));
            customer.AddRental(new Rental(new Movie("Eraserhead", MovieType.Regular), 3, RentalType.Regular));

            Assert.AreEqual("Rental Record for Fred\n\tPlan 9 from Outer Space\t2\n\t8 1/2\t2\n\tEraserhead\t3.5\nYou owed 7.5\nYou earned 3 frequent renter points\n", StatementService.BuildStatement(customer));
        }
    }
}
