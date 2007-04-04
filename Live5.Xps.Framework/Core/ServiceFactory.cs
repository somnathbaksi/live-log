using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Live5.Xps.Framework.Utils;

namespace Live5.Xps.Framework.Core
{
    public class ServiceFactory
    {
        private static ServiceFactory m_Instance;
        private static object m_Lock = new object();

        private ServiceFactory()
        {

        }
        public static ServiceFactory Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (m_Lock)
                    {
                        if (m_Instance == null)
                        {
                            m_Instance = new ServiceFactory();
                        }
                    }

                }
                return m_Instance;
            }
        }
        public IService GetService(string serviceType)
        {
            AddInController addIn = new AddInController();
            return addIn.GetNamedService(serviceType);
        }
      
    }
}
