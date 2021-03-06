﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
using LiveCharts;
using LiveCharts.Wpf;
using SaveIt;
using Controllers;

namespace WpSaveIt.Views
{
    /// <summary>
    /// Interaction logic for Column.xaml
    /// </summary>
    public partial class Column : UserControl
    {
        private ColumnController _columnController = new ColumnController();

        public Column()
        {
            InitializeComponent();
            DataContext = _columnController;
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            _columnController.UpdateValues();
        }

    }
}
