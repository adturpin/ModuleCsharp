using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestModule.Interface;

namespace MyModule1.Test
{
    [TestClass]
    public class UnitTest1
    {
        private Module1 _module;
        private IModuleRepository _repository;

        [TestInitialize]
        public void Init()
        {
            _repository = new MyModule1TestRepository();
            _module = new Module1(_repository);
        }


        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(_module.GetModuleID(),5);
            Assert.AreEqual(_module.GetModuleName(), "Module5");
            Assert.AreEqual(_module.TestRepo(), "MyTestName5");
        }
    }
}
