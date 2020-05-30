using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestModule.Interface;
using TestModule.Repository;
using Unity;
using Unity.Builder;
using Unity.Injection;
using Unity.Lifetime;

namespace TestModule
{
    public class IOContainer
    {
        private readonly IUnityContainer _unitycontainer;

        public IOContainer()
        {
            _unitycontainer = new UnityContainer();
            var dataAccess = GetAssemblys();
            RegisterRepositories();
            RegisterModules(dataAccess);
        }

        private void RegisterModules(List<Assembly> dataAccess)
        {
            foreach (Assembly assembly in dataAccess)
            {
                List<Type> moduleTypes = assembly
                    .GetTypes()
                    .Where(x => x.IsSubclassOf(typeof(AModule)))
                    .ToList();

                foreach (Type type in moduleTypes)
                {
                    _unitycontainer.RegisterType(typeof(AModule), type, type.FullName);
                }
            }
        }

        private void RegisterRepositories()
        {
            _unitycontainer.RegisterType<IModuleRepository, ConsoleRepository>();
        }

        private List<Assembly> GetAssemblys()
        {
            List<Assembly> result = new List<Assembly>();
            string appSetting = ConfigurationManager.AppSettings["ModulePath"];
            if (appSetting == null)
                appSetting = Directory.GetCurrentDirectory();

            DirectoryInfo directoryInfo = new DirectoryInfo(appSetting);
            if (!directoryInfo.Exists)
            {
                throw new ArgumentException("Wrong Module folder path");
            }

            string[] assemblyModules = directoryInfo.GetFiles("*.dll").Select(file => file.FullName).ToArray();
            foreach (string assemblyModule in assemblyModules)
            {
                result.Add(Assembly.Load(File.ReadAllBytes(assemblyModule)));
            }

            result.Add(Assembly.GetExecutingAssembly());
            return result;
        }

        public IEnumerable<AModule> GetModules()
        {
           return _unitycontainer.Resolve<IEnumerable<AModule>>();
        }
    }
}
