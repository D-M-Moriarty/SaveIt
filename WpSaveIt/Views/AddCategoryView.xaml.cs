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
using Controllers;
using SaveIt;

namespace WpSaveIt
{
    /// <summary>
    /// Interaction logic for AddCategoryView.xaml
    /// </summary>
    public partial class AddCategoryView : UserControl
    {
        // Controller object
        private readonly AddCategoryController _categoryController = new AddCategoryController();

        private readonly Expense _expense;
        private readonly Window _window;

        public AddCategoryView(Window window)
        {
            InitializeComponent();
            DataContext = _categoryController;
            _window = window;
        }

        public AddCategoryView(Window window, Object obj)
        {
            InitializeComponent();
            DataContext = _categoryController;
            _window = window;
            if (obj.GetType() == typeof(Expense))
                _expense = (Expense) obj;
        }

        private void SaveCategory_Click(object sender, RoutedEventArgs e)
        {

            if (_expense == null)
            {
                _categoryController.SaveCategory();
                _window.DataContext = new AddCategoryView(_window);
            }
            else
            {
                // TODO Make it accept the whole object
                _expense.Category = _categoryController.Category.Description;
                _window.DataContext = new AddExpenseView(_window, _expense);
            }
            
        }
    }
}
