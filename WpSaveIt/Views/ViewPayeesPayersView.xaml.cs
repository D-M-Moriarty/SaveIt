using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controllers;
using SaveIt;
using WpSaveIt.Annotations;
using ListViewItem = System.Windows.Controls.ListViewItem;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace WpSaveIt
{
    /// <summary>
    /// Interaction logic for ViewPayeesPayersView.xaml
    /// </summary>
    public partial class ViewPayeesPayersView : UserControl
    { 

        private readonly Window _window;
        private readonly ViewPayeesPayersController _payeesPayersController = new ViewPayeesPayersController();
        

        public ViewPayeesPayersView(Window window)
        {
            _window = window;
            InitializeComponent();
            DataContext = _payeesPayersController;
        }
        

        private void AddPayee_Click(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new NewPayeeView(_window, true);
        }

        private void AddPayer_Click(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new NewPayeeView(_window, false);
        }
        

        private void UpdateItem_Click(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new NewPayeeView(_window, _payeesPayersController.SelectedItem);
        }

        // TODO possibly make this a generic method
        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (_payeesPayersController.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to delete");
                return;
            }

            DialogResult dialogResult = (DialogResult)MessageBox.Show("Do you want to delete item " + _payeesPayersController.SelectedItem.Name,
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Hand);

            if (dialogResult == DialogResult.Yes)
            {
                _payeesPayersController.DeleteItem();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Ok");
            }
        }

        private void PayeeList_OnGotFocus(object sender, RoutedEventArgs e)
        {
            _payeesPayersController.SelectedItem = SaveItUtils.List_OnGotFocus<Payee>(PayeeList, e);
        }

        private void PayerList_OnGotFocus(object sender, RoutedEventArgs e)
        {
            _payeesPayersController.SelectedItem = SaveItUtils.List_OnGotFocus<Payee>(PayerList, e);
        }
    }
}