using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModule.Interface;
using TestModule.Repository;
using Unity;

namespace TestModule
{
    class Program
    {
        static void Main(string[] args)
        {
            IOContainer ioc = new IOContainer();
            IEnumerable<AModule> modules = ioc.GetModules();
            foreach (AModule module in modules)
            {
                Console.WriteLine($"Id : {module.GetModuleID()} - ModuleName : {module.GetModuleName()} - Repo : {module.TestRepo()}"); 
            }
            Console.ReadKey();
        }

        
    }
}
