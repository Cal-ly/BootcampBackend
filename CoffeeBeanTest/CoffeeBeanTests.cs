using CoffeeBeanLib;

namespace CoffeeBeanTest;

[TestClass]
public class CoffeeBeanTests
{
    [TestMethod]
    [DataRow("A", false)]
    [DataRow("AB", true)]
    [DataRow("", false)]
    [DataRow(" ", false)]
    [DataRow(null, false)]
    public void ValidateName_Test(string name, bool isValid)
    {
        var coffeeBean = new CoffeeBean { Name = name };

        if (isValid)
        {
            coffeeBean.ValidateName();
        }
        else
        {
            Assert.ThrowsException<ArgumentException>(() => coffeeBean.ValidateName());
        }
    }

    [TestMethod]
    [DataRow(0, false)]
    [DataRow(1, true)]
    [DataRow(9, true)]
    [DataRow(10, false)]
    public void ValidateRoasting_Test(int roasting, bool isValid)
    {
        var coffeeBean = new CoffeeBean { Roasting = roasting };

        if (isValid)
        {
            coffeeBean.ValidateRoasting();
        }
        else
        {
            Assert.ThrowsException<ArgumentException>(() => coffeeBean.ValidateRoasting());
        }
    }
}
