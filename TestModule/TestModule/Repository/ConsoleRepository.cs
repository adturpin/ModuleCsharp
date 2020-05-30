using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModule.Interface;

namespace TestModule.Repository
{
    public class ConsoleRepository : IModuleRepository
    {
        public string TestMethodeA()
        {
            return "Mon repo";
        }
    }
}
