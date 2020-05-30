using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModule.Interface;

namespace MyModule1.Test
{
    public class MyModule1TestRepository : IModuleRepository
    {
        string IModuleRepository.TestMethodeA()
        {
            return "MyTestName";
        }
    }
}
