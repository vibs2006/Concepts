using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace UnitTestProjectDemo
{
    [TestClass]
    public class UnitTest1
    {

        private TestContext _testContext;
        public TestContext TestContext
        {
            get
            {
                return _testContext;
            }
            set
            {
                _testContext = value;
            }
        }
        [TestMethod]
        [DeploymentItem(@"C:\demo\data.xls")]
        [DataSource("MyExcelDataSource")]
        public void TestMethod1()
        {
            System.Diagnostics.Trace.WriteLine(_testContext.DataRow["param1"].ToString());


        }
    }
}
