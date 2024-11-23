namespace VendingMachine
{
    // simply added to see how the class will look with the implementation for properties in the interface.
    class VendingMachine : IVendingMachine
    {
        public string Manufacturer => throw new NotImplementedException();

        public Money Amount => throw new NotImplementedException();

        public Product[] Products { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Product Buy(int productNumber)
        {
            throw new NotImplementedException();
        }

        public Money InsertCoin(Money amount)
        {
            throw new NotImplementedException();
        }

        public Money ReturnMoney()
        {
            throw new NotImplementedException();
        }
    }
    public interface IVendingMachine
    {
        /// <summary>
        /// Vending machine manufacturer.
        /// </summary>
        string Manufacturer { get; }
        /// <summary>
        /// Amount of money inserted into the vending machine. 
        /// </summary>
        Money Amount { get; }
        /// <summary>
        /// Products that are sold.
        /// </summary>
        Product[] Products { get; set; }
        /// <summary>
        /// Insert a coin into vending machine.
        /// </summary>
        /// <param name="amount">Coin amount.</param>
        Money InsertCoin(Money amount);
        /// <summary>
        /// Returns all inserted coins back to the user.
        /// </summary>
        Money ReturnMoney();
        /// <summary>
        /// Buys a product from list of products.
        /// </summary>
        /// <param name="productNumber">
        /// Product number in the vending machine product list.
        /// </param>
        Product Buy(int productNumber);
    }
    public struct Money
    {
        public int Euros { get; set; }
        public int Cents { get; set; }
    }
    public struct Product
    {
        /// <summary>
        /// Gets or sets the available amount of product.
        /// </summary>
        public int Available { get; set; }
        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        public Money Price { get; set; }
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; }

    }
}