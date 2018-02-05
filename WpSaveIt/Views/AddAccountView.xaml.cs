using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controllers;
using SaveIt;

namespace WpSaveIt
{
    /// <summary>
    /// Interaction logic for AddAccountView.xaml
    /// </summary>
    public partial class AddAccountView : UserControl
    {
        // Controller object
        private readonly AddAccountController _accountController = new AddAccountController();

        private readonly Window _window;
        private  Expense _expense;
        private  Income _income;
        private  Account _account;
        

        public AddAccountView(Window window)
        {
            InitializeComponent();
            DataContext = _accountController;
            _window = window;
        }

        public AddAccountView(Window window, Object obj)
        {
            InitializeComponent();
            
            _window = window;
            if (obj.GetType() == typeof(Expense))
                this._expense = (Expense) obj;
            if (obj.GetType() == typeof(Income))
                this._income = (Income)obj;
            if (obj.GetType() == typeof(Account))
            {
                _accountController.Account = (Account)obj;   
                TypeBox.SelectedIndex = TypeBox.Items.IndexOf(_accountController.Account.Type);
                _accountController.IsUpdating = true;
            }
            
            DataContext = _accountController;

        }

        private void SaveAccount_Click(object sender, RoutedEventArgs e)
        {
           
            // if the data is being updated
            if (_accountController.IsUpdating)
            {
                _accountController.UpdateAccount();
                _window.DataContext = new ViewAccountsView(_window);

            }
            else
            {
                // Adding an account from view account view
                if (_expense == null && _income == null)
                {
                    _accountController.SaveAccount();
                    _window.DataContext = new ViewAccountsView(_window);
                }
                else if (_income == null)
                {
                    _expense.Account = _accountController.Account;
                    _window.DataContext = new AddExpenseView(_window, _expense);
                }
                else
                {
                    _income.Account = _accountController.Account; 
                    _window.DataContext = new AddIncomeView(_window, _income);
                }
            }
            
                
        }
    }
}
