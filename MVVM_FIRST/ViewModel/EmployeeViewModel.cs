
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
using MVVM_FIRST.Model;
using SDK.Model;
using System.ServiceModel;
using SDK.Service;

namespace MVVM_FIRST.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        //private ServiceReference1.ServiceClient Client = new ServiceReference1.ServiceClient();
        ChannelFactory<IService> channelFactory = new ChannelFactory<IService>(new BasicHttpBinding(), "http://localhost:8090/SDK/Service/Service");
        IService Client;


        public EmployeeViewModel()
        {

            Client = channelFactory.CreateChannel();
            CurrentPage = 0;
            SizeOfPage = 2;
            NumberOfPages = GetNumberOfPages(Client.NumberOfEmployees(), SizeOfPage);
            PaginationInView = (CurrentPage + 1).ToString() + "/" + NumberOfPages;

            Enterprises = new ObservableCollection<Enterprise>(Client.GetEnterprises());
            ObservableCollection<User> Users = new ObservableCollection<User>(Client.GetUsers());
            Employees = new ObservableCollection<Employee>(Client.GetEmployeesIncludeEnterprise(CurrentPage, SizeOfPage));

            DeleteCommand = new RelayCommand(Delete, CanDelete);
            SaveCommand = new RelayCommand(Save, CanSave);
            NewCommand = new RelayCommand(New);
            CreateCommand = new RelayCommand(Create);
            UpdateCommand = new RelayCommand(Update, CanUpdate);
            CancelCommand = new RelayCommand(Cancel);
            NextPageCommand = new RelayCommand(NextPage, CanNextPage);
            PreviousPageCommand = new RelayCommand(PreviousPage, CanPreviousPage);
            FirstPageCommand = new RelayCommand(FirstPage, CanFirstPage);
            LastPageCommand = new RelayCommand(LastPage, CanLasttPage);

            FirstNameFilter = true;
        }

        private bool CanLasttPage(object obj)
        {
            return (CurrentPage + 1) < NumberOfPages;
        }

        private void LastPage(object obj)
        {
            CurrentPage = NumberOfPages - 1;
            if (SearchText != "")
            {
                Employees = new ObservableCollection<Employee>(Client.SearchEmployee(SearchText, SelectedFilters(), CurrentPage, SizeOfPage));
            }
            else
            {
                Employees = new ObservableCollection<Employee>(Client.GetEmployeesIncludeEnterprise(CurrentPage, SizeOfPage));
            }

            PaginationInView = (CurrentPage + 1).ToString() + "/" + NumberOfPages;
        }

        private void FirstPage(object obj)
        {
            CurrentPage = 0;
            if (SearchText != "")
            {
                Employees = new ObservableCollection<Employee>(Client.SearchEmployee(SearchText, SelectedFilters(), CurrentPage, SizeOfPage));
            }
            else
            {
                Employees = new ObservableCollection<Employee>(Client.GetEmployeesIncludeEnterprise(CurrentPage, SizeOfPage));
            }
            PaginationInView = (CurrentPage + 1).ToString() + "/" + NumberOfPages;
        }

        private bool CanFirstPage(object obj)
        {

            return CurrentPage > 0;
        }

        private bool CanPreviousPage(object obj)
        {
            return CurrentPage > 0;
        }

        private void PreviousPage(object obj)
        {
            CurrentPage--;
            if (SearchText != "")
            {
                Employees = new ObservableCollection<Employee>(Client.SearchEmployee(SearchText, SelectedFilters(), CurrentPage, SizeOfPage));
            }
            else
            {
                Employees = new ObservableCollection<Employee>(Client.GetEmployeesIncludeEnterprise(CurrentPage, SizeOfPage));
            }
            PaginationInView = (CurrentPage + 1).ToString() + "/" + NumberOfPages;
        }

        private int _SizeOfPage;

        public int SizeOfPage
        {
            get { return _SizeOfPage; }
            set { _SizeOfPage = value; }
        }


        private void NextPage(object obj)
        {
            CurrentPage++;
            if (SearchText != "")
            {
                Employees = new ObservableCollection<Employee>(Client.SearchEmployee(SearchText, SelectedFilters(), CurrentPage, SizeOfPage));
            }
            else
            {
                Employees = new ObservableCollection<Employee>(Client.GetEmployeesIncludeEnterprise(CurrentPage, SizeOfPage));
            }
            PaginationInView = (CurrentPage + 1).ToString() + "/" + NumberOfPages;
        }

        private bool CanNextPage(object obj)
        {
            return (CurrentPage + 1) < NumberOfPages;
        }

        public int GetNumberOfPages(int numberOfRows, int sizeOfpage)
        {
            int N = numberOfRows / sizeOfpage;
            if (numberOfRows % sizeOfpage > 0)
            {
                N++;
            }
            return N;

        }

        private string _PaginationInView;

        public string PaginationInView
        {
            get { return _PaginationInView; }
            set
            {
                _PaginationInView = value;
                OnPropertyChanged("PaginationInView");
            }
        }

        private int _CurrentPage;

        public int CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; }
        }

        private int _NumberOfPages;

        public int NumberOfPages
        {
            get { return _NumberOfPages; }
            set { _NumberOfPages = value; }
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
            objPopupwindow.DataContext = this;
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
        public RelayCommand NextPageCommand { get; set; }
        public RelayCommand PreviousPageCommand { get; set; }
        public RelayCommand FirstPageCommand { get; set; }
        public RelayCommand LastPageCommand { get; set; }

        private bool _AllFilter;

        public bool AllFilter
        {
            get { return _AllFilter; }
            set
            {
                _AllFilter = value;
                if (value == true)
                {
                    FirstNameFilter = true;
                    LastNameFilter = true;
                }
                else
                {
                    FirstNameFilter = false;
                    LastNameFilter = false;
                }
                OnPropertyChanged("AllFilter");
            }
        }

        private bool _LastNameFilter;

        public bool LastNameFilter
        {
            get { return _LastNameFilter; }
            set
            {
                _LastNameFilter = value;
                OnPropertyChanged("LastNameFilter");
            }
        }
        private bool _FirstNameFilter;

        public bool FirstNameFilter
        {
            get { return _FirstNameFilter; }
            set
            {   
                _FirstNameFilter = value;
                OnPropertyChanged("FirstNameFilter");
            }
        }

        public List<string> SelectedFilters()
        {
            List<string> filters = new List<string>();
            if (AllFilter) filters.Add("AllFilter");
            if (FirstNameFilter) filters.Add("FirstNameFilter");
            if (LastNameFilter) filters.Add("LastNameFilter");

            return filters;
        }


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
                if (value != "")
                {
                    CurrentPage = 0;
                    Employees = new ObservableCollection<Employee>(Client.SearchEmployee(value, SelectedFilters(), CurrentPage, SizeOfPage));
                    NumberOfPages = GetNumberOfPages(Client.NumberofSearchEmployee(value, SelectedFilters(), CurrentPage, SizeOfPage), SizeOfPage);
                    PaginationInView = (CurrentPage + 1).ToString() + "/" + NumberOfPages;
                }
                else
                {
                    Employees = new ObservableCollection<Employee>(Client.GetEmployeesIncludeEnterprise(0, SizeOfPage));
                    CurrentPage = 0;
                    NumberOfPages = GetNumberOfPages(Client.NumberOfEmployees(), SizeOfPage);
                    PaginationInView = (CurrentPage + 1).ToString() + "/" + NumberOfPages;
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
                OnPropertyChanged("SelectedEnterprise");
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

            Client.RemoveEmployee(SelectedEmployee);
            Employees = new ObservableCollection<Employee>(Client.GetEmployeesIncludeEnterprise(0, 2));
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

                Client.UpdateEmployee(emp, emp.Id);

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

                Client.AddEmployee(emp);


            }
            Employees = new ObservableCollection<Employee>(Client.GetEmployeesIncludeEnterprise(0, 2));
            Window.GetWindow(((System.Windows.Controls.Button)obj)).Close();
            SelectedEmployee = null;
        }

        private bool CanSave(object o)
        {
            return SelectedEmployee != null || isNew;
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
