using MVVM_FIRST.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_FIRST.ViewModel
{
    class EnterpriseViewModel
    {

        public EnterpriseViewModel()
        {
            Enterprises = new ObservableCollection<Enterprise>(new WorkDbContext().GetEnterprises());
        }
        public static ObservableCollection<Enterprise> Enterprises { get; set; }
    }
}
