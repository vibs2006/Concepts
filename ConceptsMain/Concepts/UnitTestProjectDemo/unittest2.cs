using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Diagnostics;

namespace UnitTestProjectDataDriven
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext _testContext;

        public  TestContext TestContext {

            get { return _testContext; }

            set { _testContext = value; }
        }

        [TestMethod]
        [DeploymentItem("c:\\demo\\data.xls")]
        [DataSource("MyExcelDataSource")]
        public void TestMethod1()
        {
            int variable1 = Convert.ToInt32(_testContext.DataRow["param1"].ToString());
            Trace.WriteLine(_testContext.DataRow["param1"].ToString());

            int variable2 = Convert.ToInt32(_testContext.DataRow["param2"].ToString());
            Trace.WriteLine(_testContext.DataRow["param2"].ToString());

            Assert.AreEqual(variable1, variable2);
        }
    }
}
