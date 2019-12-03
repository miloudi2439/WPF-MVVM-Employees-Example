using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguagePlugin
{

    [InheritedExport(typeof(ILanguage))]
    public interface ILanguage
    {
        string GetContext();
    }
}
