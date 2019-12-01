using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_FIRST.Model
{
    [DataContract]
    public class Employee : INotifyPropertyChanged
    {            
       
        //[Key()]
        [DataMember]
        public int Id { get; set; }

        private string _FirstName;
        [DataMember]
        public string FirstName {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _LastName;
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
