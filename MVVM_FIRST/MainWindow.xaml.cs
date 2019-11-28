using MVVM_FIRST.ViewModel;
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

namespace MVVM_FIRST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /*
        private void EmployeeViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeViewModel employeeViewModelObject =
               new EmployeeViewModel();
             
            EmployeeViewControl.DataContext = employeeViewModelObject;
        }
        */

        private void EnterpriseViewControl_Loaded(object sender, RoutedEventArgs e)
        {/*
            EnterpriseViewModel enterpriseViewModelObject =
               new EnterpriseViewModel();

            EnterpriseViewControl.DataContext = enterpriseViewModelObject;*/
        }
        


    }
}
