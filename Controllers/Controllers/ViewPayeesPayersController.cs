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
    public class ViewPayeesPayersController
    {

        public Payee SelectedItem;

        public ObservableCollection<Payee> Payees { get; set; }
        private ObservableCollection<Payee> _payers = new ObservableCollection<Payee>();
        public ObservableCollection<Payee> Payers { get; set; }

        public ViewPayeesPayersController()
        {

            Payees = GetPayees();
            Payers = GetPayers();
        }

        private ObservableCollection<Payee> GetPayees()
        {

            ObservableCollection<Payee> myPayees = new ObservableCollection<Payee>();

            using (var db = new EntitySaveItContext())
            {
                var query = from b in db.Payees
                            where b.Name != null
                            orderby b.Id
                            select b;

                Debug.WriteLine("All Payees in the database:");
                foreach (var item in query)
                {
                    if (item.IsPayee)
                        myPayees.Add(item);
                }
            }
            
            return myPayees;
        }

        // TODO change this method to return the entire Payee object
        public static List<string> GetPayeeNames()
        {

            List<string> myPayees = new List<string>();

            using (var db = new EntitySaveItContext())
            {
                var query = from b in db.Payees
                            where b.Name != null
                            orderby b.Id
                            select b;


                Debug.WriteLine("All Payees in the database:");
                foreach (var item in query)
                {
                    if (item.IsPayee)
                        myPayees.Add(item.Name);
                }
            }
               
            return myPayees;
        }


        private ObservableCollection<Payee> GetPayers()
        {

            ObservableCollection<Payee> myPayers = new ObservableCollection<Payee>();

            using (var db = new EntitySaveItContext())
            {
                var query = from b in db.Payees
                    where b.Name != null
                    orderby b.Id
                    select b;



                Debug.WriteLine("All Payers in the database:");
                foreach (var item in query)
                {
                    if (!item.IsPayee)
                    {
                        myPayers.Add(item);
                    }

                }
            }

            return myPayers;
        }

        public void DeleteItem()
        {
            Payee itemToDelete;
            //1. Get Account from DB
            using (var ctx = new EntitySaveItContext())
            {
                itemToDelete =
                    ctx.Payees.FirstOrDefault(s => s.Id == SelectedItem.Id);
            }

            //Create new context for disconnected scenario
            using (var newContext = new EntitySaveItContext())
            {
                newContext.Entry(itemToDelete).State = System.Data.Entity.EntityState.Deleted;

                try
                {
                    newContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    // TODO review this exception
                    Console.WriteLine(ex);
                    MessageBox.Show("Cannot delete this item");
                }

            }

            // remove the item to be deleted from the list
            if (SelectedItem.IsPayee)
                Payees.Remove(SelectedItem);
            else
                Payers.Remove(SelectedItem);
        }
    }
}
