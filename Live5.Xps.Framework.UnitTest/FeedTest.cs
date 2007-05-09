﻿// The following code was generated by Microsoft Visual Studio 2005.
// The test owner should check each test for validity.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using Live5.Xps.Framework.Model;
namespace Live5.Xps.Framework.UnitTest
{
    /// <summary>
    ///This is a test class for Live5.Xps.Framework.Atom.Feed and is intended
    ///to contain all Live5.Xps.Framework.Atom.Feed Unit Tests
    ///</summary>
    [TestClass()]
    public class FeedTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            Tool.CopyAddIn(testContext);
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ToString ()
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Feed target = new Feed();
            Entry e = new Entry();
            e.Content = "kk";
            target.EntryList.Add(e);
            e.Content = "dd";
            target.EntryList.Add(e);
            string expected = null;
            string actual;

            actual = target.ToString();

            Assert.IsNotNull(actual);
        }

    }


}