using MVVM_FIRST.Model;
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

namespace MVVM_FIRST.View
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        public EmployeeView()
        {
            InitializeComponent();
            this.DataContext = new EmployeeViewModel();

           
        /*WorkDbContext context = new WorkDbContext();
        IList<string> Enterprises_Names = context.Enterprises.Select(l => l.Name).ToList();
        Enterprise.ItemsSource = Enterprises_Names;*/
        }

        private void DataGrid_SelectedCellsChanged_Employee(object sender, SelectedCellsChangedEventArgs e)
        {
           /* if (Data_Grid_Employee.SelectedItems.Count >= 1)
            {


                var row = Data_Grid_Employee.SelectedItems[0];
                WorkDbContext context = new WorkDbContext();



                Employee emp_selected = (Employee)row;
                Enterprise Selected_Enterprise = context.Enterprises.First(i => i.Id == emp_selected.Entreprise.Id);

                if (row is Employee)
                {
                    Employee emp = (Employee)row;
                    FirstName.Text = emp.FirstName;
                    LastName.Text = emp.LastName;
                    Salary.Text = emp.Salary;
                    Age.Text = emp.Age.ToString();
                    City.Text = emp.City; 
                    

                }

                Enterprise.SelectedItem = Selected_Enterprise.Name;
            }*/
        }

        void Create_Employee(object sender, RoutedEventArgs e)
        {
/*
            try
            {
                WorkDbContext context = new WorkDbContext();
                Enterprise Selected_Enterprise = context.Enterprises.First(i => i.Name == Enterprise.SelectedItem.ToString() );
                Employee emp = new Employee
                {
                    FirstName = FirstName.Text.ToString(),
                    LastName = LastName.Text.ToString(),
                    Salary = Salary.Text.ToString(),
                    Age = Int32.Parse(Age.Text.ToString()),
                    City = City.Text.ToString(),
                    EnterpriseId = Selected_Enterprise.Id

                };

                context.Employees.Add(emp);
                context.SaveChanges();
                MessageBox.Show("Record Inserted successfully.");
                this.DataContext = new EmployeeViewModel();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.ToString());
            }*/
        }


        private void Delete_Employee(object sender, RoutedEventArgs e)
        {
           /* if (Data_Grid_Employee.SelectedItems.Count == 1)
            {
                WorkDbContext context = new WorkDbContext();
                var row = Data_Grid_Employee.SelectedItems[0];
                Employee emp_selected = (Employee)row;
                Employee emp = context.Employees.First(i => i.Id == emp_selected.Id);
  
                context.Employees.Remove(emp);
                context.SaveChanges();
                MessageBox.Show("Record Deleted successfully.");
                this.DataContext = new EmployeeViewModel();
            }
            else MessageBox.Show("Select an Employee please !");*/
        }

        private void Update_Employee(object sender, RoutedEventArgs e)
        {
        /*
            if (!FirstName.Text.Equals("") && !LastName.Text.Equals("") && !Salary.Text.Equals("")
                && !Age.Text.Equals("") && !City.Text.Equals(""))
            {
                if (Data_Grid_Employee.SelectedItems.Count == 1)
                {
                    WorkDbContext context = new WorkDbContext();
                    var row = Data_Grid_Employee.SelectedItems[0];
                    Employee emp_selected = (Employee)row;
                    Employee emp = context.Employees.First(i => i.Id == emp_selected.Id);
                    {
                        emp.FirstName = FirstName.Text;
                        emp.LastName = LastName.Text;
                        emp.Salary = Salary.Text;
                        emp.Age = Int32.Parse(Age.Text);
                        emp.City = City.Text; 
                        context.SaveChanges();
                        MessageBox.Show("Record Updated successfully.");
                        this.DataContext = new EmployeeViewModel();
                    }
                }
                else MessageBox.Show("Select an Employee please !");

            }
            else MessageBox.Show("the value of FirstName or LastName is vide !");

    */


        }

        private void Data_Grid_Employee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
         
    }
}
