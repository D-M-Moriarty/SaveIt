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
    public class ExpenseTests
    {
        // CATEGORY TESTS
        [TestMethod()] // link comment
        public void ExpenseTestCategoryValid()
        {
            Expense expense = new Expense()
            {
                Category = "Daily Living"
            };

            string expectedResult = "Daily Living";

            Assert.AreEqual(expectedResult, expense.Category);
        }

        [TestMethod()] // link comment
        public void ExpenseTestCategoryInvalid()
        {
           
                Expense expense = new Expense
                {
                    Category = "monkey"
                };

                if (expense.HasErrors)
                    Assert.IsTrue(true);
        }

        // DESCRIPTION TESTS
        [TestMethod()] // link comment
        public void ExpenseTestDescriptionSetPass()
        {
            Expense expense = new Expense
            {
                Description = "Hello"
            };

            string expectedResult = "Hello";


            Assert.AreEqual(expectedResult, expense.Description);
        }

        [TestMethod()] // link comment
        public void ExpenseTestDescriptionSetFail()
        {
            
                Expense expense = new Expense
                {
                    Description = "Hello I think this is a way too long for a description"
                };

            if (expense.HasErrors)
                Assert.IsTrue(true);

        }

        // AMOUNT TESTS
        [TestMethod()] // link comment
        public void ExpenseTestAmountPass()
        {
            Expense expense = new Expense()
            {
                Amount = 250.04
            };

            double expectedResult = 250.04;

            Assert.AreEqual(expectedResult, expense.Amount);
        }

        [TestMethod()] // link comment
        public void ExpenseTestAmount_Fail_When_Amount_Is_Minus_Value()
        {
            
            Expense expense = new Expense()
            {
                Amount = -45.45
            };


            if (expense.HasErrors)
                Assert.IsTrue(true);

        }

        // DATE TESTS
        [TestMethod()] // link comment
        public void ExpenseTest_Date_Valid()
        {
            Expense expense = new Expense()
            {
                TransactionDate = DateTime.Today
            };

            int expectedDate = DateTime.Now.Month;

            Assert.AreEqual(expectedDate, expense.TransactionDate.Month);
        }

        // DATE TESTS
        [TestMethod()] // link comment
        public void ExpenseTest_SetAccount()
        {
            Expense expense = new Expense()
            {
                Account = new Account()
                {
                    Name = "Account"
                }
            };

            string expectedResult = "Account";

            Assert.AreEqual(expectedResult, expense.Account.Name);
        }

        [TestMethod()] // link comment
        public void ExpenseTest_SetPayee()
        {
            Expense expense = new Expense()
            {
                Payee = new Payee() { Name = "Payee"}
            };

            string expectedResult = "Payee";

            Assert.AreEqual(expectedResult, expense.Payee.Name);
        }

    }
}