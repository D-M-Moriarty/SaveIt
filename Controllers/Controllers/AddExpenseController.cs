using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveIt;

namespace Controllers
{
    public class AddExpenseController : ObservableObject
    {
        private Expense _expense;
        public Expense Expense
        {
            get { return _expense; }
            set
            {
                if (value != _expense)
                {
                    _expense = value;
                    OnPropertyChanged("Expense");
                }
            }
        }

        public bool IsUpdating { get; set; }

        public AddExpenseController()
        {
            Expense = new Expense();
            Expense.TransactionDate = DateTime.Now;
        }

        // method to update an existing expense
        public void UpdateExpense()
        {
            using (var db = new EntitySaveItContext())
            {
                var result = db.Expenses.SingleOrDefault(b => b.Id == Expense.Id);
                if (result != null)
                {
                    result.Category = Expense.Category;
                    result.Description = Expense.Description;
                    result.Amount = Expense.Amount;
                    result.TransactionDate = Expense.TransactionDate;
                    result.Account = Expense.Account;
                    result.Payee = Expense.Payee;
                    db.SaveChanges();

                }
            }
        }

        public void SaveExpense()
        {
            if (IsUpdating)
            {
                UpdateExpense();
            }
            else
            {
                using (var db = new EntitySaveItContext())
                {
                    db.Expenses.Add(Expense);
                    db.SaveChanges();
                }

            }
        }
    }
}
