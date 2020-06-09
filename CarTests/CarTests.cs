using CarNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarTests
{
    [TestClass]
    public class CarTests
    {     
        Car test_car;

        [TestInitialize]
        public void CreateCarObject()
        {
            test_car = new Car("Toyota", "Prius", 10, 50);
        }

        [TestMethod]
        public void TestInitialGasTank()
        {
            Assert.AreEqual(10, test_car.GasTankLevel, .001);
        }

        //TODO: gasTankLevel is accurate after driving within tank range

        [TestMethod]
        public void GetTankLevelTest()
        {
            test_car.Drive(50);

            Assert.IsTrue(9 == test_car.GasTankLevel, "sample message");
        }
        //TODO: gasTankLevel is accurate after attempting to drive past tank range

        [TestMethod]
        public void GasLevelTestTooFar()
        {
            test_car.Drive(1000);
            Assert.IsTrue(0 == test_car.GasTankLevel, "Travel too far, gas is zero");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGasOverfillException()
        {
            test_car.AddGas(5);
            Assert.Fail("Shouldn't get here, car cannot have more gas in tank than the size of the tank");
        }
    }  
}
