using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using SaveIt;
using ListView = System.Windows.Controls.ListView;
using ListViewItem = System.Windows.Controls.ListViewItem;
using MessageBox = System.Windows.MessageBox;

namespace Controllers
{
    public class SaveItUtils
    {
        /// <summary>
        /// Helper method to retrieve the selected item from
        /// the dependency property system
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private static DependencyObject RetrieveSelectedItem(RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            return dep;
        }

        /// <summary>
        /// This method returns the type of the object
        /// that the list contains
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listView"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static T List_OnGotFocus<T>(ListView listView, RoutedEventArgs e)
        {
            DependencyObject dep = SaveItUtils.RetrieveSelectedItem(e);

            return (T)listView.ItemContainerGenerator.ItemFromContainer(dep);

        }
        
    }
}
