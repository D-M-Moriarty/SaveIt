using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveIt.Annotations;

/**
 * this class represents the
 * users expenses
 */

namespace SaveIt
{
    public class Expense : ObservableObject
    {
        // Exception String constants
        public const string DescriptionIsNotTheCorrectLength = "Description is the incorrect length";
        public const string CategoryIsNotPredefined = "Not a valid category";
        public const string AmountIsNotEnough = "Amount is less than 0.01";
        public const string DateInWrongMonth = "The date is not iin this month";

        // Category Array
        public string[] CategoryListing =
        {
            "Daily Living",
            "Dues/subscriptions",
            "Entertainment",
            "Finacial savings",
            "Health Care",
            "Home/Rent",
            "Loan",
            "MISC. Payment",
            "Transportation"
        };

        public Expense() { }


        public int Id { get; set; }

        // TODO make this method extract categories from database
        public string[] Categories { get; set; }

        private string _category;
        public string Category
        {
            get { return _category; }
            set
            {
                if (_category != value)
                {
                    if (!CategoryListing.Contains(value))
                    {
                        base.AddError("Category", CategoryIsNotPredefined);
                    }
                    else
                        base.RemoveError("Category");

                    _category = value;
                }
            }
        }


        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    if (value.Length < 2 || value.Length > 20) 
                        base.AddError("Description", DescriptionIsNotTheCorrectLength);
                    else
                        base.RemoveError("Description");
                    _description = value;
                }
                
            }
        }

        private double _amount;
        public double Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    if (value < 0.01)
                        base.AddError("Amount", AmountIsNotEnough);
                    else
                        base.RemoveError("Amount");
                    _amount = value;
                }
            }
        }

#pragma warning disable CS0169 // The field 'Expense._transactionDate' is never used
        private DateTime _transactionDate;
#pragma warning restore CS0169 // The field 'Expense._transactionDate' is never used
        public DateTime TransactionDate { get; set; }

        // TODO complete these few methods and test them in test class
        
        [CanBeNull]
        public Account Account { get; set; }
        [CanBeNull]
        public Payee Payee { get; set; }

    }
}
