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
using SaveIt.Annotations;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;
using UserControl = System.Windows.Controls.UserControl;

namespace WpSaveIt
{
    /// <summary>
    /// Interaction logic for ViewGoalsView.xaml
    /// </summary>
    public partial class ViewGoalsView : UserControl
    {
        
        private readonly Window _window;
        private readonly ViewGoalsController _goalsController = new ViewGoalsController();

        public ViewGoalsView(Window window)
        {
            InitializeComponent();
            DataContext = _goalsController;
            _window = window;
        }

        private void Goal_ListView_OnGotFocus(object sender, RoutedEventArgs e)
        {
            _goalsController.myTimer.Stop();
            _goalsController.SelectedItem = SaveItUtils.List_OnGotFocus<Goal>(Goal_ListView, e);
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (_goalsController.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to delete");
                return;
            }

            DialogResult dialogResult = 
                (DialogResult)MessageBox.Show("Do you want to delete item " + _goalsController.SelectedItem.Name,
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Hand);

            if (dialogResult == DialogResult.Yes)
            {
                _goalsController.DeleteItem();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Ok");
            }
        }

        private void UpdateItem_Click(object sender, RoutedEventArgs e)
        {
            _window.DataContext = new NewGoalView(_window, _goalsController.SelectedItem);
        }

        private void AddSavedAmount_Click(object sender, RoutedEventArgs e)
        {
            UpdateSavedAmount(_goalsController.SelectedItem, _goalsController.AddAmounts);
        }

        private void UpdateSavedAmount(Goal selectedItem, double addAmount)
        {
            _goalsController.UpdateSavedAmount();
        }

    }
}
