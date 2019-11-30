using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_FIRST.Model
{



    [DataContract]
    public class Enterprise : INotifyPropertyChanged
    {
        private int _Id;
        [DataMember]
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _Name;
        [DataMember]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        private string _Location;
        [DataMember]
        public string Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
                OnPropertyChanged("Location");
            }
        }
        private string _Domaine;
        [DataMember]
        public string Domaine
        {
            get { return _Domaine; }
            set
            {
                _Domaine = value;
                OnPropertyChanged("Domaine");
            }
        }
        private List<Employee> _Employees;
        public List<Employee> Employees
        {
            get { return _Employees; }
            set
            {
                _Employees = value;
                OnPropertyChanged("Employees");
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
