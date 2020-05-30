using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModule.Interface
{
    public abstract class AModule
    {
        protected readonly IModuleRepository _moduleRepository;

        public AModule(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }
        public abstract string GetModuleName();
        public abstract int GetModuleID();

        public abstract string TestRepo();
    }
}
