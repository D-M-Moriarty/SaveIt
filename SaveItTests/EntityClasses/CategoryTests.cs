using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaveIt;

namespace SaveIt.Tests
{
    [TestClass()]
    public class CategoryTests
    {
        [TestMethod()]
        public void TestSetBudget_Pass()
        {
            Category category = new Category()
            {
                Budget = 200
            };

            int expectedResult = 200;

            Assert.AreEqual(category.Budget, expectedResult);
        }

        [TestMethod()]
        public void TestSetBudget_Fail()
        {

            Category category = new Category()
            {
                Budget = -200
            };

            if (category.HasErrors)
                Assert.IsTrue(true);
        }

        [TestMethod()]
        public void TestSetDescription()
        {

            Category category = new Category()
            {
                Description = "chicken"
            };

            string expectedResult = "chicken";

            Assert.AreEqual(expectedResult, category.Description);
        }
    }
}
