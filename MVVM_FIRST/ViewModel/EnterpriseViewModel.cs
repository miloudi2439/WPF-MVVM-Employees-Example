using MVVM_FIRST.Model;
using SDK.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_FIRST.ViewModel
{
    class EnterpriseViewModel : INotifyPropertyChanged
    {
        ChannelFactory<IService> channelFactory = new ChannelFactory<IService>(new BasicHttpBinding(), "http://localhost:8090/SDK/Service/Service");
        IService Client;
        public EnterpriseViewModel()
        {
            Client = channelFactory.CreateChannel();
            Enterprises = new ObservableCollection<Enterprise>(Client.GetEnterprises());
        }
       

        private ObservableCollection<Enterprise> _Enterprises;
        public ObservableCollection<Enterprise> Enterprises
        {
            get
            {
                return _Enterprises;
            }
            set
            {
                _Enterprises = value;
                OnPropertyChanged("Enterprises");
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
