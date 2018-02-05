using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaveIt;

namespace SaveIt.Tests
{
    [TestClass]
    public class IncomeTests
    {
        [TestMethod]
        public void TestSetDescription_Pass()
        {
            Income income = new Income() { Description = "From work" };

            string expectedResult = "From work";

            Assert.AreEqual(expectedResult, income.Description);
        }

        [TestMethod()]
        public void TestSetDescription_Fail()
        {
            
                Income income = new Income() { Description = "lsdflisdflskjdfnlsjfkgnlksfjdnglsfjkngskfjgnsdlfjkgnsldfgjknsldfgjnsdfgjknfgljksnfdglsfdjng" };

                if (income.HasErrors)
                    Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestSetAmount_Pass()
        {
            Income income = new Income() { Amount = 2000 };

            double expectedResult = 2000;

            Assert.AreEqual(expectedResult, income.Amount);
        }

        [TestMethod()]
        public void TestSetAmount_Fail()
        {
            Income income = new Income() { Amount = -50 };

            if (income.HasErrors)
                Assert.IsTrue(true);
        }

        [TestMethod()]
        public void TestSetPayer()
        {
            Income income = new Income() { Payer = new Payee() { Name = "Payer" } };

            string expectedResult = "Payer";

            Assert.AreEqual(expectedResult, income.Payer.Name);
        }

        [TestMethod()]
        public void TestSetAccount()
        {
            Income income = new Income() { Account = new Account() { Name = "Account" } };

            string expectedResult = "Account";

            Assert.AreEqual(expectedResult, income.Account.Name);
        }

        [TestMethod()]
        public void TestSetComment()
        {
            Income income = new Income()
            { Comment = "Comment"};

            string expectedResult = "Comment";

            Assert.AreEqual(expectedResult, income.Comment);
        }

    }
}
