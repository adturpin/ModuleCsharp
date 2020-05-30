using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModule.Interface;

namespace MyModule1
{
    public class Module1 : AModule
    {
        public Module1(IModuleRepository moduleRepository)
            : base(moduleRepository)
        {
        }

        public override int GetModuleID()
        {
            return 5;
        }

        public override string GetModuleName()
        {
            return "Module5";
        }

        public override string TestRepo()
        {
            return _moduleRepository.TestMethodeA() + "5";
        }
    }
}
