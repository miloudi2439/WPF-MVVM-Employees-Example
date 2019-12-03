using LanguagePlugin;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

       
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        [ImportMany(typeof(ILanguage))]
        List<ILanguage> _rules;


        private void Compose()
        {
            //AssemblyCatalog catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            DirectoryCatalog catalog = new DirectoryCatalog("Plugins", "*.dll");

            CompositionContainer container = new CompositionContainer(catalog);
            container.SatisfyImportsOnce(this);
        }
        void Run()
        {
            Compose();
            foreach (var item in _rules)
            {

                Console.WriteLine(item.GetContext());
            }
            Console.ReadKey();
        }
    }
}
