using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
namespace Live5.Xps.Framework.UnitTest
{
    /// <summary>
    /// Summary description for ExternalFrameworkTest
    /// </summary>
    [TestClass]
    public class ExternalFrameworkTest
    {
        public ExternalFrameworkTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ExceptionHandingTest()
        {
            try
            {
                throw new Exception("Test generated exception");
            }
            catch (Exception ex)
            {
                
                Logger.Write("logger loged test data","Debug",-1);
                bool rethrow = ExceptionPolicy.HandleException(ex, "Log Only Policy");
                if (rethrow)
                {
                    throw;
                }

            }
        }
    }
}
