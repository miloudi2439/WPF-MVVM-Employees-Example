using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_FIRST.Model
{
    public class Employee : INotifyPropertyChanged
    {            
       
        [Key()]
        public int Id { get; set; }
        private string _FirstName;
        public string FirstName {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        private string _Salary;
        public string Salary
        {
            get { return _Salary; }
            set
            {
                _Salary = value;
                OnPropertyChanged("Salary");
            }
        }
        private int _Age;
        public int Age
        {
            get { return _Age; }
            set
            {
                _Age = value;
                OnPropertyChanged("Age");
            }
        }
        private string _City;
        public string City
        {
            get { return _City; }
            set
            {
                _City = value;
                OnPropertyChanged("City");
            }
        }

        [ForeignKey(nameof(_Enterprise))]
        private int _EnterpriseId;
        public int EnterpriseId
        {
            get { return _EnterpriseId; }
            set
            {
                _EnterpriseId = value;
                OnPropertyChanged("EnterpriseId");
            }
        }
        private Enterprise _Enterprise;
        public virtual Enterprise Enterprise
        {
            get { return _Enterprise; }
            set
            {
                _Enterprise = value;
                OnPropertyChanged("Enterprise");
            }
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
