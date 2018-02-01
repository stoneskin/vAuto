using Microsoft.VisualStudio.TestTools.UnitTesting;
using VAuto.RestClient;
using VAuto.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace TestProject
{
    [TestClass]
    public class RestClientTest
    {

        VAutoApiServiceIml vAutoService { get; set; }
        public RestClientTest()
        {
            vAutoService = new VAutoApiServiceIml();
        }

        [TestMethod]
        public void Test_GetDataSetId_ReceivedDataSetId_Successfully()
        {
            var datasetIdResp = vAutoService.GetDataSetId().Result;
            Assert.IsNotNull(datasetIdResp);
            Assert.IsFalse(string.IsNullOrEmpty(datasetIdResp.DatasetId));
        }

        [TestMethod]
        public void Test_Given_DataSetId_Call_GetVehicleIds_ReceivedVehicleIdsResponse_Success()
        {

            var datasetId = "2RJFYx1p1Qg";
            var vehicleIdsResp = vAutoService.GetVehicleIds(datasetId).Result;
            Assert.IsNotNull(vehicleIdsResp);
            Assert.IsNotNull(vehicleIdsResp.VehicleIds);
            Assert.IsTrue(vehicleIdsResp.VehicleIds.Any());
        }

     
    }
        
}
