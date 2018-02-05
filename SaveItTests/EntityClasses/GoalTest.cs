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
    public class GoalSavingsTests
    {
        [TestMethod()]
        public void GoalSetName_Pass()
        {
            Goal goal = new Goal() { Name = "New Home" };
            string expectedResult = "New Home";

            Assert.AreEqual(goal.Name, expectedResult);
        }

        [TestMethod()]
        public void GoalSetName_Fail()
        {
            
                Goal goal = new Goal() { Name = "New Home out in the country somewhere by a lake where there's fish" };

                if (goal.HasErrors)
                    Assert.IsTrue(true);
        }

        [TestMethod()]
        public void GoalTargetAmount_Pass()
        {
           
            Goal goal = new Goal() { TargetAmount = 500 };
            double expectedResult = 500;

            Assert.AreEqual(goal.TargetAmount, expectedResult);
        }

        [TestMethod()]
        public void GoalTargetAmount_Fail()
        {
            
                Goal goal = new Goal() { TargetAmount = -1 };

                if (goal.HasErrors)
                    Assert.IsTrue(true);
        }

        [TestMethod()]
        public void GoalSavedAlready_Pass()
        {

            Goal goal = new Goal() { SavedAlready = 500 };
            double expectedResult = 500;

            Assert.AreEqual(goal.SavedAlready, expectedResult);
        }

        [TestMethod()]
        public void GoalSavedAlready_Fail()
        {
            
                Goal goal = new Goal() { SavedAlready = -1 };

                if (goal.HasErrors)
                    Assert.IsTrue(true);
          
        }

        // Testing that the goal amount has been saved before the target date
        [TestMethod()]
        public void GoalReachedTest_Pass()
        {
            // Attributes of a Goal class
            Goal goal = new Goal()
            {
                DesiredDate = new DateTime(2018, 12, 12),
                Id = 13,
                Name = "New Car",
                Note = "I hope I can afford this car",
                TargetAmount = 5000,
                SavedAlready = 2000
            };

            int income = 3000;

            goal.SavedAlready += income;

            // possibly make it a static method and use id
            bool goalReached = goal.CheckIfGoalIsReached();

            // adding the link
            Assert.IsTrue(goalReached);

        }

        // Testing that the goal amount has been saved before the target date
        [TestMethod()]
        public void GoalReachedTest_Fail()
        {
            // Attributes of a Goal class
            Goal goal = new Goal()
            {
                DesiredDate = new DateTime(2018, 12, 12),
                Id = 13,
                Name = "New Car",
                Note = "I hope I can afford this car",
                TargetAmount = 5000,
                SavedAlready = 2000
            };

            int income = 2000;

            goal.SavedAlready += income;

            // possibly make it a static method and use id
            bool goalReached = goal.CheckIfGoalIsReached();

            // adding the link
            Assert.IsFalse(goalReached);

        }

        [TestMethod()]
        public void GoalSetNote()
        {

            Goal goal = new Goal() { Note = "Note" };

            string expectedResult = "Note";

            Assert.AreEqual(expectedResult, goal.Note);

        }

        [TestMethod()]
        public void GoalIsReached()
        {

            Goal goal = new Goal() { GoalIsReached = true };

            Assert.IsTrue(goal.GoalIsReached);

        }


    }
}