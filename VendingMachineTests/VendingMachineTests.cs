using Moq;
using VendingMachine;

namespace VendingMachineTest
{
    [TestFixture]
    public class VendingMachineTests
    {
        // Using a mocking library to mock up the vending machine interface.
        private Mock<IVendingMachine>? _machine;

        [SetUp]
        public void Setup()
        {
            // Instantiation of the mocked interface instance _machine.
            _machine = new Mock<IVendingMachine>();
        }

        [Test]
        public void InsertCoin_ValidEntries_ShowsTotalAmount()
        {
            // Arrange
            // Setting the initial amount to 0 in the system, amount property of mock machine will be updated as 0 using the Setup() method.
            var startAmount = new Money { Euros = 0, Cents = 0 };
            _machine.Setup(_vMachine => _vMachine.Amount).Returns(startAmount);

            // setting new coin insert using an example: 2 euro valid coin and making this reflect in the mock machine Amount property.
            var coinInsert = new Money { Euros = 2, Cents = 0 };
            _machine.Setup(_vMachine => _vMachine.InsertCoin(It.IsAny<Money>())).Returns(coinInsert);

            // Act
            // Actual action of inserting the valid coin, by calling InsertCoin() method.
            var updatedAmount = _machine.Object.InsertCoin(coinInsert);

            // Assert
            // Validating the expected results after the action is done.
            Assert.That(updatedAmount.Euros, Is.EqualTo(2));
            Assert.That(updatedAmount.Cents, Is.EqualTo(0));
        }

        // A test for validating the Amount property when multiple coins are inserted can be added on later stage.

        [Test]
        public void Buy_Product_SuccessCase()
        {
            // Arrange
            // Setting up the test data for an example product that can be found in the vending machine.
            var product = new Product
            {
                Available = 15,
                Price = new Money { Euros = 1, Cents = 50 },
                Name = "VitaminWell"
            };

            // Defining the stock list of product and adding the created VitaminWell product data into the Product array of mock machine.
            var stock = new Product[] { product };
            _machine.Setup(_vMachine => _vMachine.Products).Returns(stock);

            // Inserting 2 euros for buying this product, amount property of mock machine will reflect this value.
            var coinInsertForBuying = new Money { Euros = 2, Cents = 50 };
            _machine.Setup(_vMachine => _vMachine.Amount).Returns(coinInsertForBuying);

            // Defining what Buy() should do on the mock machine, which is to return the VitaminWell product added in index 0 of 'product'.
            _machine.Setup(_vmachine => _vmachine.Buy(It.IsAny<int>())).Returns(stock[0]);


            // Act
            // Buying action of VitaminWell which is stored in the product array at index 0 on mock machine.
            var boughtProduct = _machine.Object.Buy(0);

            // Assert
            // validating for the correct product name and price for the purchased item. Available count does not automatically get updated and so cant be tested here.
            // Testing for 'Available' requires additional setup for mock to udpate this when a successful purchase happens or need real implementation of the functionality.
            Assert.That(boughtProduct.Price.Euros, Is.EqualTo(1));
            Assert.That(boughtProduct.Price.Cents, Is.EqualTo(50));
            Assert.That(boughtProduct.Name, Is.EqualTo("VitaminWell"));
        }

        // Tests for buying a product and validating the balance amount can be added later.

        // The .NET garbage collector automatically cleans up unreferenced objects, so simple object references like _machine do not strictly require manual cleanup.
        // But its still a best practice to follow.
        [TearDown]
        public void TearDown()
        {
            _machine = null;
        }

    }

}