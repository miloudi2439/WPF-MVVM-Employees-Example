using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguagePlugin
{
    public class English : ILanguage
    {
        public string GetContext()
        {
            return "English";
        }
    }
}
