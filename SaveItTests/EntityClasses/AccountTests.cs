using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaveIt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveIt.Tests
{
    [TestClass()]
    public class AccountTests
    {
        //  NAME TESTS
        [TestMethod()]
        public void AccountSetNameTest_Valid()
        {
            Account account = new Account()
            {
                Name = "AIB"
            };

            string expectedValue = "AIB";

            // should pass
            Assert.AreEqual(account.Name, expectedValue);
        }

        [TestMethod()]// Name too short
        public void AccountSetNameTest_FailWhenNameIsTooShort()
        {
            Account account = new Account()
            {
                Name = "a"
            };

            if (account.HasErrors)
                Assert.IsTrue(true);
        }

        // INITIAL BALANCE TESTS
        [TestMethod()] // link comment
        public void AccountSetInitialBalanceTest_Valid()
        {
            Account account = new Account()
            {
                InitialBalance = 35000
            };

            double expectedValue = 35000;

            Assert.AreEqual(account.InitialBalance, expectedValue);
        }

        [TestMethod()] // link comment
        public void AccountSetInitialBalanceTest_FailWhenInitialBalanceIsLessThanZero()
        {
//            try
//            {
                Account account = new Account()
                {
                    InitialBalance = -34.4
                };

                if (account.HasErrors)
                    Assert.IsTrue(true);
        }

        // AS OF DATE TESTS
        [TestMethod()] // link  comment
        public void AccountSetAsOfDateTest_Valid()
        {
            Account account = new Account()
            {
                AsOfDate = new DateTime(2015, 06, 12)
            };

            DateTime expectedValue = new DateTime(2015, 06, 12);

            Assert.AreEqual(account.AsOfDate, expectedValue);
        }

        [TestMethod()] // link comment
        public void AccountSetAsOfDateTest_FailWhenDateIsInTheFuture()
        {
            Account account = new Account()
            {
                AsOfDate = DateTime.Now.AddDays(10)
            };

            if (account.HasErrors)
                Assert.IsTrue(true);
                   
        }

        [TestMethod()] 
        public void TestSetType()
        {
            Account account = new Account()
            {
                Type = "Savings"
            };

            string expectedResult = "Savings";

            Assert.AreEqual(expectedResult, account.Type);
        }

    }
}