using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using SaveIt;

namespace Controllers
{
    public class ViewGoalsController : ObservableObject
    {
        private ObservableCollection<Goal> _goals;

        public ObservableCollection<Goal> GoalsList
        {
            get { return _goals; }
            set
            {
                _goals = value;
                OnPropertyChanged("GoalsList");

            }
        }

        public Goal SelectedItem { get; set; }

        private double _addAmount;

        public double AddAmounts
        {
            get => _addAmount;
            set
            {
                _addAmount = value;
                OnPropertyChanged("AddAmounts");

            }
        }

        public ViewGoalsController()
        {
            GoalsList = GetGoals();
            Time();
        }

        private ObservableCollection<Goal> GetGoals()
        {
            ObservableCollection<Goal> myGoals = new ObservableCollection<Goal>();
            using (var db = new EntitySaveItContext())
            {
                var query = from b in db.Goals
                    orderby b.Id
                    select b;

                Debug.WriteLine("All incomes in the database:");
                foreach (var item in query)
                {
                    myGoals.Add(item);
                }
            }

            return myGoals;
        }


        public void DeleteItem()
        {
            Goal itemToDelete;
            //1. Get Goal from DB
            using (var ctx = new EntitySaveItContext())
            {
                itemToDelete =
                    ctx.Goals.FirstOrDefault(s => s.Id == SelectedItem.Id);
            }

            //Create new context for disconnected scenario
            using (var newContext = new EntitySaveItContext())
            {
                newContext.Entry(itemToDelete).State = System.Data.Entity.EntityState.Deleted;

                try
                {
                    newContext.SaveChanges();
                    // remove the item to be deleted from the list
                    GoalsList.Remove(SelectedItem);
                }
                catch (Exception ex)
                {
                    // TODO review this exception
                    Console.WriteLine(ex);
                    MessageBox.Show("Cannot delete this item");
                }

            }
        }

        public void UpdateSavedAmount()
        {
            using (var db = new EntitySaveItContext())
            {
                var result = db.Goals.SingleOrDefault(b => b.Id == SelectedItem.Id);
                if (result != null)
                {
                    result.SavedAlready += AddAmounts;
                    db.SaveChanges();
                    GoalsList = GetGoals();
                }
            }

            myTimer.Start();
        }

        public Timer myTimer = new Timer();

        private void Time()
        {
            
            myTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
            myTimer.Interval = 1000; // 1000 ms is one second
            myTimer.Start();
        }

        public void DisplayTimeEvent(object source, ElapsedEventArgs e)
        {
            GoalsList = GetGoals();
        }
    }
}
