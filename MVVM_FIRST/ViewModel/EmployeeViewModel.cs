using MVVM_FIRST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using MVVM_FIRST.View;
using SDK.Model;

namespace MVVM_FIRST.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    { 
        private UnitOfWork _UnitOfWork = new UnitOfWork();
        public EmployeeViewModel()
        {
            Enterprises = new ObservableCollection<Enterprise>(_UnitOfWork.EnterprisesRepository.GetAll());
            Employees = new ObservableCollection<Employee>(_UnitOfWork.EmployeesRepository.GetEmployeesIncludeEnterprise());
             
            DeleteCommand = new RelayCommand(Delete, CanDelete);
            SaveCommand = new RelayCommand(Save, CanSave);
            NewCommand = new RelayCommand(New);
            CreateCommand = new RelayCommand(Create);
            UpdateCommand = new RelayCommand(Update , CanUpdate);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Cancel(object obj)
        {
            Window.GetWindow(((System.Windows.Controls.Button)obj)).Close();
            SelectedEmployee = null;
        }

        private bool isNew = false;

        private void Create(object obj)
        {
            isNew = true;
            FirstName = null;
            LastName = null;
            Salary = null;
            Age = 0;
            City = null;
            isNew = true;
            SelectedEnterprise = null;
            Window objPopupwindow = new CreateOrUpdateEmployeeView();
            objPopupwindow.Show();
        }

        private bool CanUpdate(object obj)
        {
            return SelectedEmployee != null;
        }

        private void Update(object obj)
        {
            isNew = false;
            FirstName = SelectedEmployee.FirstName;
            LastName = SelectedEmployee.LastName;
            Salary = SelectedEmployee.Salary;
            Age = SelectedEmployee.Age;
            City = SelectedEmployee.City;
            SelectedEnterprise = SelectedEmployee.Enterprise;
            Window objPopupwindow = new CreateOrUpdateEmployeeView();
            objPopupwindow.DataContext = this;
            objPopupwindow.Show();            
        }

        private ObservableCollection<Employee> _Employees;
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _Employees;
            }
            set
            {
                _Employees = value;
                OnPropertyChanged("Employees");
            }
        }
        public ObservableCollection<Enterprise> Enterprises { get; set; }

        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand NewCommand { get; set; }
        public RelayCommand CreateCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }



        private String _SearchText;

        public String SearchText
        {
            get
            {
                return _SearchText;
            }
            set
            {
                _SearchText = value;
                SelectedEmployee = null;
                OnPropertyChanged("SearchText");
                if (value != null)
                {
                    Employees = new ObservableCollection<Employee>(
                        new ObservableCollection<Employee>(_UnitOfWork.EmployeesRepository.GetEmployeesIncludeEnterprise())
                        .Where(l => l.FirstName.ToLower().Contains(value.ToLower())
                        || l.LastName.ToLower().Contains(value.ToLower())
                        )
                        );
                }
                else
                {
                    Employees = new ObservableCollection<Employee>(_UnitOfWork.EmployeesRepository.GetEmployeesIncludeEnterprise());
                }
            }
        }
        private Enterprise _SelectedEnterprise;
        public Enterprise SelectedEnterprise
        {
            get
            {
                return _SelectedEnterprise;
            }
            set
            {
                _SelectedEnterprise = value;
            }
        }

        private Employee _SelectedEmployee;

        public Employee SelectedEmployee
        {
            get
            {
                return _SelectedEmployee;
            }

            set
            {
                _SelectedEmployee = value;
                if (value != null)
                {
                    isNew = false;
                    FirstName = value.FirstName;
                    LastName = value.LastName;
                    Salary = value.Salary;
                    Age = value.Age;
                    City = value.City;
                }
            }
        }

        private String _FirstName;
        public String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
                OnPropertyChanged("FirstName");

            }
        }
        private String _LastName;
        public String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
                OnPropertyChanged("LastName");

            }
        }
        private String _Salary;
        public String Salary
        {
            get
            {
                return _Salary;
            }
            set
            {
                _Salary = value;
                OnPropertyChanged("Salary");
            }
        }
        private int _Age;
        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
                OnPropertyChanged("Age");
            }
        }
        private String _City;
        public String City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
                OnPropertyChanged("City");
            }
        }


        private void Delete(object o)
        {

            _UnitOfWork.EmployeesRepository.Remove(SelectedEmployee);
            _UnitOfWork.Save();

            Employees = new ObservableCollection<Employee>(_UnitOfWork.EmployeesRepository.GetEmployeesIncludeEnterprise());
        }

        private bool CanDelete(object o)
        {
            return SelectedEmployee != null;
        }

        private void Save(object obj)
        {
            if (!isNew)
            {
                Employee emp = new Employee();
                emp.Id = SelectedEmployee.Id;
                emp.FirstName = FirstName;
                emp.LastName = LastName;
                emp.Salary = Salary;
                emp.Age = Age;
                emp.City = City;
                emp.EnterpriseId = SelectedEnterprise.Id;
                emp.Enterprise = SelectedEnterprise;

                _UnitOfWork.EmployeesRepository.Update(emp,emp.Id);
                _UnitOfWork.Save();
              
            }
            else
            {
                Employee emp = new Employee();
                {
                    emp.FirstName = FirstName;
                    emp.LastName = LastName;
                    emp.Salary = Salary;
                    emp.Age = Age;
                    emp.City = City;
                    emp.EnterpriseId = SelectedEnterprise.Id;
                    emp.Enterprise = SelectedEnterprise;
                }

                _UnitOfWork.EmployeesRepository.Add(emp);
                _UnitOfWork.Save();
               

            }
            Employees = new ObservableCollection<Employee>(_UnitOfWork.EmployeesRepository.GetEmployeesIncludeEnterprise());
            Window.GetWindow(((System.Windows.Controls.Button)obj)).Close();
            SelectedEmployee = null;
        }

        private bool CanSave(object o)
        {
            return SelectedEmployee != null || isNew ;
        }
   
        private void New(object o)
        {
            FirstName = null;
            LastName = null;
            Salary = null;
            Age = 0;
            City = null;
            isNew = true;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
