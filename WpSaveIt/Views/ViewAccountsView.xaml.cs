using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    /// Interaction logic for ViewAccountsView.xaml
    /// </summary>
    public partial class ViewAccountsView : UserControl
    {
       
        private ViewAccountsController _accountsController = new ViewAccountsController();
        private readonly Window _window;

        public ViewAccountsView(Window window)
        {
            InitializeComponent();
            _window = window;
            DataContext = _accountsController;
        }

        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
           _window.DataContext = new AddAccountView(_window);
        }

        private void AccountList_GotFocus(object sender, RoutedEventArgs e)
        {
            _accountsController.SelectedItem = SaveItUtils.List_OnGotFocus<Account>(AccountList, e);
        }

        // opens addAccountView form
        private void UpdateAccount_Click(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new AddAccountView(_window, _accountsController.SelectedItem);
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {

            if (_accountsController.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to delete");
                return;
            }

            MessageBoxResult dialogResult = MessageBox.Show("Do you want to delete item " + _accountsController.SelectedItem.Name,
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Hand);

            if (dialogResult == MessageBoxResult.Yes)
            {
                _accountsController.DeleteAccount();
            }
            else if (dialogResult == MessageBoxResult.No)
            {
                System.Windows.Forms.MessageBox.Show("Ok");
            }
}
        

    }
}
