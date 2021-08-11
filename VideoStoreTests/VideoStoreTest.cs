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
            var movie = MovieFactory.CreateMovie("The Cell", MovieConstants.NewRelease);
            customer.AddRental(new Rental(movie, 3));
            
            Assert.AreEqual("Rental Record for Fred\n\tThe Cell\t9\nYou owed 9\nYou earned 2 frequent renter points\n", StatementService.BuildStatement(customer));
        }

        [TestMethod]
        public void TestDualNewReleaseStatement()
        {
            var movie1 = MovieFactory.CreateMovie("The Cell", MovieConstants.NewRelease);
            var movie2 = MovieFactory.CreateMovie("The Tigger Movie", MovieConstants.NewRelease);
            customer.AddRental(new Rental(movie1, 3));
            customer.AddRental(new Rental(movie2, 3));
            
            Assert.AreEqual("Rental Record for Fred\n\tThe Cell\t9\n\tThe Tigger Movie\t9\nYou owed 18\nYou earned 4 frequent renter points\n", StatementService.BuildStatement(customer));
        }

        [TestMethod]
        public void TestSingleChildrensStatement()
        {
            var movie = MovieFactory.CreateMovie("The Tigger Movie", MovieConstants.Childrens);
            customer.AddRental(new Rental(movie, 3));
            
            Assert.AreEqual("Rental Record for Fred\n\tThe Tigger Movie\t1.5\nYou owed 1.5\nYou earned 1 frequent renter points\n", StatementService.BuildStatement(customer));
        }

        [TestMethod]
        public void TestMultipleRegularStatement()
        {
            var movie1 = MovieFactory.CreateMovie("Plan 9 from Outer Space", MovieConstants.Regular);
            var movie2 = MovieFactory.CreateMovie("8 1/2", MovieConstants.Regular);
            var movie3 = MovieFactory.CreateMovie("Eraserhead", MovieConstants.Regular);
            customer.AddRental(new Rental(movie1, 1));
            customer.AddRental(new Rental(movie2, 2));
            customer.AddRental(new Rental(movie3, 3));

            Assert.AreEqual("Rental Record for Fred\n\tPlan 9 from Outer Space\t2\n\t8 1/2\t2\n\tEraserhead\t3.5\nYou owed 7.5\nYou earned 3 frequent renter points\n", StatementService.BuildStatement(customer));
        }
    }
}
