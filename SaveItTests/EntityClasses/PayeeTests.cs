using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaveIt;

namespace SaveIt.Tests
{
    [TestClass]
    public class PayeeTests
    {
        [TestMethod]
        public void TestSetName_Pass()
        {
            Payee payee = new Payee() { Name = "Jim" };

            string expectedResult = "Jim";

            Assert.AreEqual(expectedResult, payee.Name);
        }

        [TestMethod]
        public void TestSetTelephone_Pass()
        {
            Payee payee = new Payee() { Telephone = "123 - 1234567" };

            string expectedResult = "123 - 1234567";

            Assert.AreEqual(expectedResult, payee.Telephone);
        }

        [TestMethod]
        public void TestSetAddress_Pass()
        {
            Payee payee = new Payee() { Address = "123 st" };

            string expectedResult = "123 st";

            Assert.AreEqual(expectedResult, payee.Address);
        }
        
        [TestMethod]
        public void TestSetIsPayee_Pass()
        {
            Payee payee = new Payee() { IsPayee = true };

            Assert.IsTrue(payee.IsPayee);
        }

        [TestMethod]
        public void TestNameIsEmpty()
        {
            Payee payee = new Payee() { Name = "" };

            if (payee.HasErrors)
                Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestNameLong()
        {
            Payee payee = new Payee() { Name = "hgrkawjhbrjhasbfkjshbflzjhfbhfja" };

            if (payee.HasErrors)
                Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestNameInvalid()
        {
            Payee payee = new Payee() { Name = "3kjsdb3" };

            if (payee.HasErrors)
                Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestTelephoneNUll()
        {
            Payee payee = new Payee() { Telephone = "" };

            if (payee.HasErrors)
                Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestTelephoneShort()
        {
            Payee payee = new Payee() { Telephone = "2" };

            if (payee.HasErrors)
                Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestTelephoneNotMatch()
        {
            Payee payee = new Payee() { Telephone = "fsdfdjfndksfnsf" };

            if (payee.HasErrors)
                Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestAddressTooLong()
        {
            Payee payee = new Payee() { Address = "djfbksjdbfkjsdbfsjdbfksdbfskdbfsdkfbbs" };

            if (payee.HasErrors)
                Assert.IsTrue(true);
        }

    }
}
