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

namespace WpSaveIt
{
    /// <summary>
    /// Interaction logic for NewGoalView.xaml
    /// </summary>
    public partial class NewGoalView : UserControl
    {
        private readonly Window _window;
        private readonly NewGoalController _goalController = new NewGoalController();

        public NewGoalView(Window window)
        {
            InitializeComponent();
            _window = window;
            DataContext = _goalController;
        }

        public NewGoalView(Window window, Object obj)
        {
            InitializeComponent();
            if (obj.GetType() == typeof(Goal))
            {
                _goalController.Goal = (Goal) obj;
            }
            _window = window;
            _goalController.IsUpdating = true;
            DataContext = _goalController;
        }
        
        private void NewGoal_Click(object sender, RoutedEventArgs e)
        {
            // if the data is being updated
            if (_goalController.IsUpdating)
            {
                _goalController.UpdateGoal();
                _window.DataContext = new ViewGoalsView(_window);
            }
            else
            {
                _goalController.SaveGoal();
                _window.DataContext = new NewGoalView(_window);
            }
            
        }
    }
}
