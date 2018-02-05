using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using WpSaveIt.Annotations;

namespace WpSaveIt
{
    /// <summary>
    /// Interaction logic for AddExpenseView.xaml
    /// </summary>
    public partial class AddExpenseView : UserControl
    {
        // Controller object
        private readonly AddExpenseController _addExpenseController = new AddExpenseController();
        private readonly Window _window;

        // Default Constructor
        public AddExpenseView(Window window)
        {
            InitializeComponent();
            _window = window;
            DataContext = _addExpenseController;
           
            AccountComboBox.ItemsSource = ViewAccountsController.GetAccountNames();
            PayeeComboBox.ItemsSource = ViewPayeesPayersController.GetPayeeNames();
            CategoryComboBox.ItemsSource = new Expense().CategoryListing;
        }

        public AddExpenseView(Window window, Expense expense, bool update) : this(window, expense)
        {
            _addExpenseController.IsUpdating = update;
            DataContext = _addExpenseController;
        }
       

        // From Another View Constructor
        public AddExpenseView(Window window, Expense expense)
        {
            InitializeComponent();
            _window = window;

            _addExpenseController.Expense = expense;
            DataContext = _addExpenseController;

            AccountComboBox.ItemsSource = ViewAccountsController.GetAccountNames();
            PayeeComboBox.ItemsSource = ViewPayeesPayersController.GetPayeeNames();
            CategoryComboBox.ItemsSource = new Expense().CategoryListing;

        }

        private void SaveExpense_Click(object sender, RoutedEventArgs e)
        { 
           
            if (!_addExpenseController.IsUpdating)
            {
                _addExpenseController.SaveExpense();
                _window.DataContext = new AddExpenseView(_window);
            }
            else
            {
                _addExpenseController.UpdateExpense();
            }
            
        }

        private void Account_Focus(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new AddAccountView(_window, _addExpenseController.Expense);
        }

        private void Payee_OnGotFocus(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new NewPayeeView(_window, _addExpenseController.Expense);
        }

        private void Category_OnGotFocus(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new AddCategoryView(_window, _addExpenseController.Expense);
        }

        private void CategoryComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string content = CategoryComboBox.SelectedItem.ToString();
            Category.Text = content;;
        }

        private void AccountComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Account.Text = AccountComboBox.SelectedItem.ToString();
        }

        private void PayeeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Payee.Text = PayeeComboBox.SelectedItem.ToString();
        }
    }
}
