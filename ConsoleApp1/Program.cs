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

        [Import]
        string message;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Compose()
        {
            AssemblyCatalog catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
            container.SatisfyImportsOnce(this);
        }
        void Run()
        {
            Compose();
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
