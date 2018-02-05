using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using SaveIt;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Controllers
{
    public class ViewAccountsController : ObservableObject
    {
        public ObservableCollection<Account> Accounts { get; set; }
        public Account SelectedItem { get; set; }

        public ViewAccountsController()
        {
            Accounts = GetAccounts();
        }

        private ObservableCollection<Account> GetAccounts()
        {

            ObservableCollection<Account> myAccounts = new ObservableCollection<Account>();

            using (var db = new EntitySaveItContext())
            {
                var query = from b in db.Accounts
                    where b.Name != null
                    orderby b.Id
                    select b;

                Debug.WriteLine("All Accounts in the database:");
                foreach (var item in query)
                {
                    myAccounts.Add(item);
                }
            }
            return myAccounts;
        }

        // TODO change this method to return the entire account objects
        public static List<string> GetAccountNames()
        {
            List<string> myAccounts = new List<string>();

            using (var db = new EntitySaveItContext())
            {
                var query = from b in db.Accounts
                    where b.Name != null
                    orderby b.Id
                    select b;

                Debug.WriteLine("All Accounts in the database:");
                foreach (var item in query)
                {
                    myAccounts.Add(item.Name);
                }
            }

            return myAccounts;
        }

        public void DeleteAccount()
        {
            Account accountToDelete;
            //1. Get Account from DB
            using (var ctx = new EntitySaveItContext())
            {
                accountToDelete =
                    ctx.Accounts.FirstOrDefault(s => s.Id == SelectedItem.Id);
            }

            //Create new context for disconnected scenario
            using (var newContext = new EntitySaveItContext())
            {
                newContext.Entry(accountToDelete).State = System.Data.Entity.EntityState.Deleted;

                newContext.SaveChanges();
            }

            // remove the item to be deleted from the list
            Accounts.Remove(SelectedItem);

        }
    }
}
