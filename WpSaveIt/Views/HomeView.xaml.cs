using System.Windows;
using System.Windows.Forms;
using Controllers;
using SaveIt;
using static Controllers.SaveItUtils;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace WpSaveIt
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private HomeViewController _homeViewController = new HomeViewController();
        private readonly Window _window;

        public HomeView(Window window)
        {
            InitializeComponent();
            DataContext = _homeViewController;
            _window = window;
        }
        
        private void IncomeListView_OnGotFocus(object sender, RoutedEventArgs e)
        {
            _homeViewController.SelectedIncome = SaveItUtils.List_OnGotFocus<Income>(IncomeListView, e);
        }

        private void DeleteIncomeItem_Click(object sender, RoutedEventArgs e)
        {
            if (_homeViewController.SelectedIncome == null)
            {
                MessageBox.Show("Please select an item to delete");
                return;
            }

            DialogResult dialogResult = 
                (DialogResult)MessageBox.Show("Do you want to delete item " + _homeViewController.SelectedIncome.Description,
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Hand);

            if (dialogResult == DialogResult.Yes)
            {
                _homeViewController.DeleteIncome();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Ok");
            }

        }
        
        private void UpdateIncome_ListItem_Click(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new AddIncomeView(_window, _homeViewController.SelectedIncome, true);
        }

        private void ExpenseListView_OnGotFocus(object sender, RoutedEventArgs e)
        {
            _homeViewController.SelectedExpense = SaveItUtils.List_OnGotFocus<Expense>(ExpenseListView, e);
        }

        private void UpdateExpense_ListItem_Click(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new AddExpenseView(_window, _homeViewController.SelectedExpense, true);
        }

        private void DeleteExpense_ListItem_Click(object sender, RoutedEventArgs e)
        {
            if (_homeViewController.SelectedExpense == null)
            {
                MessageBox.Show("Please select an item to delete");
                return;
            }

            DialogResult dialogResult =
                (DialogResult)MessageBox.Show("Do you want to delete item " + _homeViewController.SelectedExpense.Category,
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Hand);

            if (dialogResult == DialogResult.Yes)
            {
                _homeViewController.DeleteExpense();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Ok");
            }
        }

    }
}