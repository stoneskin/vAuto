using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestClient;

namespace TestProject
{
    [TestClass]
    public class RestClientTest
    {
        VAutoService vAutoService { get; set; }
        public RestClientTest()
        {
            vAutoService = new VAutoService();
        }

        [TestMethod]
        public void Test_Get_DatasetId()
        {
            var datasetId = vAutoService.GetDataSetId().Result;
            Assert.IsNotNull(datasetId);
            Assert.IsFalse(string.IsNullOrEmpty(datasetId.DatasetId));

        }
    }
}
