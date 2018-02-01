using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VAuto.Core.Model;
using VAuto.Core.API;

namespace VAuto.RestClient
{
    public class VAutoApiServiceIml : IVAutoApiService
    {
        public IClient Client { get; set; }
        public VAutoApiServiceIml()
        {
            this.Client = RestEase.RestClient.For<IClient>("http://vautointerview.azurewebsites.net/api");
        }
        #region Begin DataSet Methods
        public async Task<DatasetIdResponse> GetDataSetId()
        {
            return await this.Client.DataSetGetDataSetId();
        }
        public async Task<AnswerResponse> PostAnswer(string datasetId, Answer answer)
        {
            return await this.Client.DataSetPostAnswer(datasetId, answer);
        }

        #endregion //End Data Set Methods

        #region Begin Vehicles methods
        public async Task<VehicleIdsResponse> GetVehicleIds(string datasetId)
        {
            return await this.Client.VehiclesGetIds(datasetId);
        }

        public async Task<VehicleResponse> GetVehicles(string datasetId, int? vehicleId)
        {
            return await this.Client.VehiclesGetVehicle(datasetId, vehicleId);
        }
        #endregion //End vehicle methods


        #region //Regin Begin Dealers Methods
        public async Task<DealersResponse> GetDealer(string datasetId, int? dealerId)
        {
            return await this.Client.DealersGetDealer(datasetId, dealerId);
        }


        #endregion //End Dealer methods

    }
}
