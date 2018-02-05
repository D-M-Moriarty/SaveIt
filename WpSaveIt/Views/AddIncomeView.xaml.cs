using System;
using System.Collections.Generic;
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
using SaveIt.Migrations;

namespace WpSaveIt
{
    /// <summary>
    /// Interaction logic for AddIncomeView.xaml
    /// </summary>
    public partial class AddIncomeView : UserControl
    {
        private AddIncomeController _addIncome = new AddIncomeController();
        private readonly Window _window;
        private Income _income;
        private Account _account;
        private Payee _payer;
        public bool IsUpdating { get; set; }

        public AddIncomeView(Window window)
        {
            InitializeComponent();
            _window = window;
            DataContext = _addIncome;
            AccountComboBox.ItemsSource = ViewAccountsController.GetAccountNames();
            PayerComboBox.ItemsSource = ViewPayeesPayersController.GetPayeeNames();
        }

        public AddIncomeView(Window window, Income income, bool update) : this(window, income)
        {
            _addIncome.IsUpdating = update;
        }

        // From Another View Constructor
        public AddIncomeView(Window window, Income income)
        {
            InitializeComponent();
            _window = window;
            _addIncome.Income = income;
            DataContext = _addIncome;
            AccountComboBox.ItemsSource = ViewAccountsController.GetAccountNames();
            PayerComboBox.ItemsSource = ViewPayeesPayersController.GetPayeeNames();

        }

        private void SaveIncome_Click(object sender, RoutedEventArgs e)
        {
            if (!IsUpdating)
            {
                _addIncome.SaveIncome();
                _window.DataContext = new AddIncomeView(_window);
            }
            else
            {
                _addIncome.UpdateIncome();
                _window.DataContext = new HomeView(_window);
            }

        }


        private void Account_OnGotFocus(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new AddAccountView(_window, _addIncome.Income);
        }

        private void Payer_OnGotFocus(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new NewPayeeView(_window, _addIncome.Income);
        }
        
    }
}
