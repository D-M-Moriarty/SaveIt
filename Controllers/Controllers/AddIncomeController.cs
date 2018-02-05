using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveIt;

namespace Controllers
{
    public class AddIncomeController : ObservableObject
    {
        private Income _income;
        public Income Income
        {
            get { return _income; }
            set
            {
                if (value != _income)
                {
                    _income = value;
                    OnPropertyChanged("Income");
                }
            }
        }

        public bool IsUpdating { get; set; }

        public AddIncomeController()
        {
            Income = new Income();
            Income.Date = DateTime.Now;
        }


        public void SaveIncome()
        {
            using (var db = new EntitySaveItContext())
            {
                if (!IsUpdating)
                {
                    db.Incomes.Add(Income);
                    db.SaveChanges();
                }
                else
                {
                    UpdateIncome();
                }
            }
        }

        public void UpdateIncome()
        {
            using (var db = new EntitySaveItContext())
            {
                var result = db.Incomes.SingleOrDefault(b => b.Id == _income.Id);
                if (result != null)
                {
                    result.Description = Income.Description;
                    result.Amount = Income.Amount;
                    result.Payer = Income.Payer;
                    result.Date = Income.Date;
                    result.Account = Income.Account;
                    result.Comment = Income.Comment;
                    db.SaveChanges();

                }
            }
        }
    }
}
