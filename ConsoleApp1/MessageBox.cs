using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MessageBox
    {
        [Export()]
        public string MyMessage
        {
            get { return "This is my example message."; }
        }
      
    }
}
