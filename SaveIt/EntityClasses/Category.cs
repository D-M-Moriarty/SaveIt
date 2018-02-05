using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

/**
 * this class represents
 * a category for an expense
 */

namespace SaveIt
{
    public class Category : ObservableObject
    {

        public const string BudgetIsLessThanZero = "The Budget cannot be less than 0";

        public Category()
        {

        }

        public int Id { get; set; }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private double _budget;
        public double Budget
        {
            get { return _budget; }
            set
            {
                if (_budget != value)
                {
                    if (value < 0)
                        base.AddError("Budget", BudgetIsLessThanZero);
                    else
                        base.RemoveError("Budget");
                    _budget = value;
                }
                
            }
        }

    }
}
