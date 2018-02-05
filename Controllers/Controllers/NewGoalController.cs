using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveIt;

namespace Controllers
{
    public class NewGoalController : ObservableObject
    {
        private Goal _goal;
        public Goal Goal
        {
            get => _goal;
            set
            {
                if (value != _goal)
                {
                    _goal = value;
                    OnPropertyChanged("Goal");
                }
                
            }
        
        }

        public bool IsUpdating { get; set; }

        public NewGoalController()
        {
            Goal = new Goal();
            Goal.DesiredDate = DateTime.Now;
        }

        // method to update an existing account
        public void UpdateGoal()
        {
            using (var db = new EntitySaveItContext())
            {
                var result = db.Goals.SingleOrDefault(b => b.Id == Goal.Id);
                if (result != null)
                {
                    result.Name = Goal.Name;
                    result.GoalIsReached = Goal.GoalIsReached;
                    result.DesiredDate = Goal.DesiredDate;
                    result.Note = Goal.Note;
                    result.SavedAlready = Goal.SavedAlready;
                    result.TargetAmount = Goal.TargetAmount;
                    db.SaveChanges();
                }
            }
        }

        public void SaveGoal()
        {
            if (IsUpdating)
            {
                UpdateGoal();
            }
            else
            {
                using (var db = new EntitySaveItContext())
                {
                    db.Goals.Add(Goal);
                    db.SaveChanges();
                }

            }
        }

    }
}
