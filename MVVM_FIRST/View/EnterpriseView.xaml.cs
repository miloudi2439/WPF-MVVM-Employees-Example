﻿using MVVM_FIRST.ViewModel;
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

namespace MVVM_FIRST.View
{
    /// <summary>
    /// Interaction logic for EnterpriseView.xaml
    /// </summary>
    public partial class EnterpriseView : UserControl
    {
        public EnterpriseView()
        {
            InitializeComponent();
            this.DataContext = new EnterpriseViewModel();
        }

        private void DataGrid_SelectedCellsChanged_Enterprise(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}
