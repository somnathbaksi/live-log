using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Live5.Xps.Framework.Core;
namespace Live5.Xps.Framework.Utils
{
    public class AddInController
    {
        private CacheManager cache;
        public AddInController()
        {
            cache= CacheFactory.GetCacheManager();
            BuiltIn.BuiltInService builtInService = new Live5.Xps.Framework.BuiltIn.BuiltInService();
            cache.Add(builtInService.GetType().FullName, builtInService);
            External.ExternalService externalService = new Live5.Xps.Framework.External.ExternalService();
            cache.Add(externalService.GetType().FullName, externalService);
            
        }
        private Dictionary<string, Assembly> m_AddInAssemblyDictionary;

        public Dictionary<string, Assembly> AddInAssemblyDictionary
        {
            get { return m_AddInAssemblyDictionary; }
            set { m_AddInAssemblyDictionary = value; }
        }
        public Assembly GetAddInAssembly(string assemblyName)
        {
            if (m_AddInAssemblyDictionary==null)
            {
                m_AddInAssemblyDictionary = cache.GetData("AddInAssemblyCacheKey") as Dictionary<string,Assembly>;
                if (m_AddInAssemblyDictionary==null)
                {
                    LoadAddIn();
                }
              
            }
            return m_AddInAssemblyDictionary[assemblyName];
        }
        private void LoadAddIn()
        {
            if (Directory.Exists(AppRuntimeEnv.AddInPath))
            {
                DirectoryInfo addInDir = new DirectoryInfo(AppRuntimeEnv.AddInPath);
                FileInfo[] files = addInDir.GetFiles("*.dll");
                Assembly assembly=null;
                m_AddInAssemblyDictionary = new Dictionary<string, Assembly>();
                foreach (FileInfo file in files)
                {
                    try
                    {
                        assembly = Assembly.LoadFrom(file.FullName);
                    }
                    catch (FileLoadException ex)
                    {
                        Console.WriteLine("File load Error." + ex.ToString());
                    }
                    catch (BadImageFormatException ex)
                    {
                        Console.WriteLine("BadImageFormatException"+ex.ToString());
                    }
                    m_AddInAssemblyDictionary.Add(assembly.FullName,assembly);
                    
                    Logger.Write(assembly.FullName + " loaded.");
                    
                }
                cache.Add("AddInAssemblyCacheKey", m_AddInAssemblyDictionary);
            }
        }
        public IService GetNamedService(string serviceType)
        {
           
            //switch (serviceType)
            //{
            //    case "Live5.Xps.Framework.BuiltIn.BuiltInService":
            //        service = new BuiltIn.BuiltInService();
                   
            //        break;
            //    case "Live5.Xps.ArticleComponent.ArticleService":
            //        service = new ArticleComponent.ArticleService();
            //        break;
            //    case "Live5.Xps.Framework.External.ExternalService":
            //        service = new External.ExternalService();
            //        break;

            //}

            IService service = cache.GetData(serviceType)as IService;
            if (service != null)
            {
                return service;
            }
            Type type = Assembly.GetExecutingAssembly().GetType(serviceType);
            service =Activator.CreateInstance(type) as IService;
            cache.Add(serviceType, service);

            //if (m_AddInAssemblyDictionary == null)
            //{
            //    LoadAddIn();
            //}

           
            //foreach (KeyValuePair<string, Assembly> keyValuePair in m_AddInAssemblyDictionary)
            //{
            //    type = keyValuePair.Value.GetType(serviceType);
            //    if (type != null)
            //    {
            //        service = Activator.CreateInstance(type) as IService;
            //        cache.Add(serviceType, service);
            //        break;
            //    }

            //}
            return service;
        }
    }
}
