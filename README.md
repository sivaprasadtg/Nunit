# Unit test case development

## Task 2 – Automation tests

Since the given vending machine code is in C#, it demands unit tests to be added and I decided to go with:  Nunit tests for creating automation tests.

### Observations:
```
1.IVendingMachine is an interface for the Vending Machine program, ie this is the contract explaining what the inheriting class should contain, while that class itself defines how the implementations over these are to be done.
2.The interface contains properties Manufacture, Amount and array of Products.
3.Interface also contains methods “InsertCoin(Money amount)”, “ReturnMoney()” and “Buy(int productNumber)”.
4.Struct Money and Product implements encapsulation.
5.Money and Product defines the currency to be used and details contained within Product.
```
Based on the test scenarios that I created in Task 1 and analyzing methods available in step #3 above, I select most critical functions as:

```
a) Insert valid coin and check amount shown in the machine is correct.
b) Buy product successfully using inserted coins.
```

The class implementing this interface will contain operation to accept inserted coins, display total amount, buy products with sufficient coins inserted etc. 

### Execute Tests
In order to run the tests, clone the repo to the local and use Visual studio - Test Explorer (ctrl+E+T), from Test menu.

### Reference materials used: 

1. [How to Add Unit Tests to C# ASP.Net Core Web App in Visual Studio + Complete Examples of Clean Tests - YouTube](https://www.youtube.com/watch?v=2grpPdVzMzA)
2. [Write Unit Tests Against the Interface, Not Implementation - YouTube](https://www.youtube.com/watch?v=po9ziMcnAWg)
3. [C# interfaces 🐟 - YouTube](https://www.youtube.com/watch?v=RuhGv81tpoU)
4. [How do you unit test an interface?](https://stackoverflow.com/questions/3121845/how-do-you-unit-test-an-interface)
