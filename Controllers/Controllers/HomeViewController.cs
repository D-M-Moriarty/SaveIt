using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SaveIt;

namespace Controllers
{
    public class HomeViewController : ObservableObject
    {

        public Double TotalIncomes { get; set; }
        public Double TotalExpenses { get; set; }
        public Income SelectedIncome { get; set; }
        public Expense SelectedExpense { get; set; }
        
        public ObservableCollection<Income> IncomeList { get; set; }
        public ObservableCollection<Expense> ExpenseList { get; set; }

        public HomeViewController()
        {
            IncomeList = GetIncomes();
            ExpenseList = GetExpenses();
        }

        private ObservableCollection<Income> GetIncomes()
        {

            ObservableCollection<Income> myIncomes = new ObservableCollection<Income>();

            using (var db = new EntitySaveItContext())
            {

                var query = from b in db.Incomes
                    orderby b.Id
                    select b;

                Debug.WriteLine("All incomes in the database:");
                foreach (var item in query)
                {
                    myIncomes.Add(item);
                    TotalIncomes += Convert.ToDouble(item.Amount);
                }
            }
            return myIncomes;
        }

        private ObservableCollection<Expense> GetExpenses()
        {

            ObservableCollection<Expense> myExpenses = new ObservableCollection<Expense>();

            using (var db = new EntitySaveItContext())
            {
                // Display all Blogs from the database 
                var query = from b in db.Expenses
                    orderby b.Id
                    select b;

                Debug.WriteLine("All Expenses in the database:");
                foreach (var item in query)
                {
                    myExpenses.Add(item);
                    TotalExpenses += Convert.ToDouble(item.Amount);
                }
            }

            return myExpenses;
        }

        public void DeleteIncome()
        {
            Income itemToDelete;
            //1. Get Account from DB
            using (var ctx = new EntitySaveItContext())
            {
                itemToDelete =
                    ctx.Incomes.FirstOrDefault(s => s.Id == SelectedIncome.Id);
            }

            //Create new context for disconnected scenario
            using (var newContext = new EntitySaveItContext())
            {
                newContext.Entry(itemToDelete).State = System.Data.Entity.EntityState.Deleted;

                try
                {
                    newContext.SaveChanges();

                    // remove the item to be deleted from the list
                    IncomeList.Remove(SelectedIncome);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }

        public void DeleteExpense()
        {
            Expense itemToDelete;
            //1. Get Account from DB
            using (var ctx = new EntitySaveItContext())
            {
                itemToDelete =
                    ctx.Expenses.FirstOrDefault(s => s.Id == SelectedExpense.Id);
            }

            //Create new context for disconnected scenario
            using (var newContext = new EntitySaveItContext())
            {
                newContext.Entry(itemToDelete).State = System.Data.Entity.EntityState.Deleted;

                try
                {
                    newContext.SaveChanges();
                    // remove the item to be deleted from the list
                    ExpenseList.Remove(SelectedExpense);
                    // TODO the exception is thrown when the item with the button click is deleted

                }

                catch (Exception ex)
                {
                    // TODO review this exception
                    Console.WriteLine(ex);
                }

            }
        }
    }
}
