using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveIt;

namespace Controllers
{
#pragma warning disable CS0436 // The type 'ObservableObject' in 'C:\Users\darren\source\repos\SaveIt\SaveIt\Controllers\ObservableObject.cs' conflicts with the imported type 'ObservableObject' in 'SaveIt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Using the type defined in 'C:\Users\darren\source\repos\SaveIt\SaveIt\Controllers\ObservableObject.cs'.
    public class AddAccountController : ObservableObject
#pragma warning restore CS0436 // The type 'ObservableObject' in 'C:\Users\darren\source\repos\SaveIt\SaveIt\Controllers\ObservableObject.cs' conflicts with the imported type 'ObservableObject' in 'SaveIt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Using the type defined in 'C:\Users\darren\source\repos\SaveIt\SaveIt\Controllers\ObservableObject.cs'.
    {
        private Account _account;

        public Account Account
        {
            get { return _account; }
            set
            {
                if (value != _account)
                {
                    _account = value;
                    OnPropertyChanged("Account");
                }
            }
        }

        public bool IsUpdating { get; set; }

        public AddAccountController()
        {
            Account = new Account();
            Account.AsOfDate = DateTime.Now;
        }

        // method to update an existing account
        public void UpdateAccount()
        {
            using (var db = new EntitySaveItContext())
            {
                var result = db.Accounts.SingleOrDefault(b => b.Id == Account.Id);
                if (result != null)
                {
                    result.Type = Account.Type;
                    result.Name = Account.Name;
                    result.InitialBalance = Account.InitialBalance;
                    result.AsOfDate = Account.AsOfDate;
                    db.SaveChanges();

                }
            }
        }

        public void SaveAccount()
        {
            if (IsUpdating)
            {
                UpdateAccount();
            }
            else
            {
                using (var db = new EntitySaveItContext())
                {
                    db.Accounts.Add(Account);
                    db.SaveChanges();
                }

            }
        }
    }
}
