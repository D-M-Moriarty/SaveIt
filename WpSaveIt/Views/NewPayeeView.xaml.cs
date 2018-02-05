using System;
using System.Collections.Generic;
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
using SaveIt;
using System.ComponentModel;
using System.Globalization;
using SaveIt.Annotations;
using System.Runtime.CompilerServices;
using System.Threading;
using Controllers;

namespace WpSaveIt
{
    /// <summary>
    /// Interaction logic for NewPayeeView.xaml
    /// </summary>
    public partial class NewPayeeView : UserControl
    {
        private readonly Window _window;
        private readonly Expense _expense;
        private readonly Income _income;

        // Controller object
        private readonly NewPayeeController _newPayeeController = new NewPayeeController();

        public NewPayeeView()
        {
            InitializeComponent();
            DataContext = _newPayeeController;
        }

        public NewPayeeView(Window window, Object obj)
        {
            InitializeComponent();

            if (obj.GetType() == typeof(Expense))
                _expense = (Expense) obj;
            if (obj.GetType() == typeof(Income))
                _income = (Income)obj;
            // the object is being updated
            if (obj.GetType() == typeof(Payee))
            {
                _newPayeeController.Payee = (Payee)obj;
                _newPayeeController.IsUpdating = true;
            }
            
            DataContext = _newPayeeController;
            _window = window;

        }

        // Creating a Payee not a Payer - use the same Object in background
        public NewPayeeView(Window window, bool isPayee)
        {
            InitializeComponent();
            _newPayeeController.Payee.IsPayee = isPayee;
            DataContext = _newPayeeController;
            _window = window;
        }

        private void SavePayee_Click(object sender, RoutedEventArgs e)
        {
            // If the payee is not being updated
            if (!_newPayeeController.IsUpdating)
            {
                // Adding Payee or Payer from ViewPayeesPayersView and clicking add
                if (_expense == null && _income == null)
                {
                    _newPayeeController.SavePayee();
                    _window.DataContext = new ViewPayeesPayersView(_window);
                }
                else if (_income == null)
                {
                    // Add a payee from the add Expense view
                    _newPayeeController.Payee.IsPayee = true;
                    _expense.Payee = _newPayeeController.Payee;
                    _window.DataContext = new AddExpenseView(_window, _expense);
                }
                else
                {
                    _income.Payer = _newPayeeController.Payee;
                    _window.DataContext = new AddIncomeView(_window, _income);
                }

            }
            else // the payee is being updated
            {
                _newPayeeController.UpdatePayee();
                _window.DataContext = new ViewPayeesPayersView(_window);
            }

        }
    }
}
