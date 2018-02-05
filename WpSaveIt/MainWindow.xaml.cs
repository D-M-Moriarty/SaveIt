using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Security.RightsManagement;
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
using SaveIt;
using WpSaveIt.Views;

namespace WpSaveIt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            DataContext = new HomeView(this);            

        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeView(this);
        }

        private void NewGoal_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new NewGoalView(this);
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
           DataContext = new AddExpenseView(this);
        }

        private void AddIncome_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddIncomeView(this);
        }

        private void ViewGoals_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ViewGoalsView(this);
        }

        private void AddCategoryView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddCategoryView(this);
        }

        private void ViewPayees_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ViewPayeesPayersView(this);
        }

        private void ViewAccounts_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ViewAccountsView(this);
        }
        
        private void ViewColumn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Column();
        }
    }
}
