using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcCursus;
using System;

namespace MvcCursusTest
{
    [TestClass]
    public class CalculatorTest
    {
        Calculator c = new Calculator();

        [TestInitialize]
        public void Init()
        {
            // Maak een nieuwe calculator aan het begin van iedere afzonderlijke test
            // Handig voor wanneer een object een historie in zich kan hebben
            // Een test voer je dan uit op een clean nieuw object
            c = new Calculator();
        }


        [TestMethod]
        public void AddTest()
        {
            int antwoord = c.Add(10, 30);
            Assert.AreEqual(40, antwoord);
        }

        [TestMethod]
        public void SubtractTest()
        {
            int antwoord = c.Subtract(10, 30);
            Assert.AreEqual(-20, antwoord);
        }

        [TestMethod]
        [DataRow(2, 2, 4)]
        [DataRow(10, 2, 20)]
        [DataRow(500, 3, 1500)]
        [DataRow(3, 7, 21)]
        public void MultiplyTest(int x, int y, int z)
        {
            int antwoord = c.Multiply(x, y);
            Assert.AreEqual(z, antwoord);
        }

        [TestMethod]
        public void DivideTest()
        {
            int antwoord = c.Divide(360, 30);
            Assert.AreEqual(12, antwoord);

            
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideTest2()
        {
            c.Divide(360, 0);
        }

    }
}
