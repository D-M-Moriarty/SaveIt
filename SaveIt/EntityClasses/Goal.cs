using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * this class represents a goal
 * that the user has created
 * this may be something that they are saving for
 */

namespace SaveIt
{
    public class Goal : ObservableObject
    {
        public const string DateIsNotInTheFuture = "The date is not in the future";
        public const string NameIsTooLong = "The goal name is too long";
        public const string TargetAmountLessThanZero = "The target amount cannot be less than zero";
        public const string SavedAlreadyLessThanZero = "Saved already cannot be less than zero";

        // ATTRIBUTES
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    if (value.Length > 40)
                        base.AddError("Name", NameIsTooLong);
                    else
                        base.RemoveError("Name");
                    _name = value;
                    OnPropertyChanged("Name");
                }
                
            }
        }

        private double _targetAmount;
        public double TargetAmount
        {
            get { return _targetAmount; }
            set
            {
                if (_targetAmount != value)
                {
                    if (value < 0)
                        base.AddError("TargetAmount", TargetAmountLessThanZero);
                    else
                        base.RemoveError("Name");
                    _targetAmount = value;
                    OnPropertyChanged("TargetAmount");
                }
            }
        }

        private double _savedAlready;
        public double SavedAlready
        {
            get { return _savedAlready; }
            set
            {
                if (_savedAlready != value)
                {
                    if (value < 0)
                        base.AddError("SavedAlready", SavedAlreadyLessThanZero);
                    else
                        base.RemoveError("SavedAlready");
                    _savedAlready = value;
                    OnPropertyChanged("SavedAlready");
                }
            }
        }

        private DateTime _desiredDate;
        public DateTime DesiredDate
        {
            get { return _desiredDate; }
            set
            {
                _desiredDate = value;
            }
        }

        public string Note { get; set; }

        private bool _goalIsReached;
        public bool GoalIsReached
        {
            get { return CheckIfGoalIsReached(); }
            set
            {
                if (CheckIfGoalIsReached())
                    _goalIsReached = value;
                OnPropertyChanged("GoalIsReached");
            }
        }

        // METHODS
        public bool CheckIfGoalIsReached()
        {
            return (SavedAlready >= TargetAmount);
        }
    }
}
