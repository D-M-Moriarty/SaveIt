using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SaveIt;
using SaveIt.Annotations;

namespace Controllers
{
#pragma warning disable CS0436 // The type 'ObservableObject' in 'C:\Users\darren\source\repos\SaveIt\SaveIt\Controllers\ObservableObject.cs' conflicts with the imported type 'ObservableObject' in 'SaveIt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Using the type defined in 'C:\Users\darren\source\repos\SaveIt\SaveIt\Controllers\ObservableObject.cs'.
    public class NewPayeeController : ObservableObject
#pragma warning restore CS0436 // The type 'ObservableObject' in 'C:\Users\darren\source\repos\SaveIt\SaveIt\Controllers\ObservableObject.cs' conflicts with the imported type 'ObservableObject' in 'SaveIt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Using the type defined in 'C:\Users\darren\source\repos\SaveIt\SaveIt\Controllers\ObservableObject.cs'.
    {

        private Payee _payeeField;
        public Payee Payee
        {
            get => _payeeField;
            set
            {
                if (value != _payeeField)
                {
                    _payeeField = value;
                    OnPropertyChanged("Payee");
                }
            }
        }

        public bool IsUpdating { get; set; }

        public NewPayeeController()
        {
            Payee = new Payee();
            Payee.AsOfDate = DateTime.Now;
        }

        // method to update an existing payee
        public void UpdatePayee()
        {
            using (var db = new EntitySaveItContext())
            {
                var result = db.Payees.SingleOrDefault(b => b.Id == Payee.Id);
                if (result != null)
                {
                    result.Name = Payee.Name;
                    result.Telephone = Payee.Telephone;
                    result.Address = Payee.Address;
                    result.AsOfDate = Payee.AsOfDate;
                    db.SaveChanges();

                }
            }
        }

        // saving a new Payee 
        public void SavePayee()
        {
            if (IsUpdating)
            {
                UpdatePayee();
            }
            else
            {
                using (var db = new EntitySaveItContext())
                {
                    db.Payees.Add(Payee);
                    db.SaveChanges();
                }
                    
            }

        }
    }
}
