using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
   public class VAutoService
    {
        public IClient Client { get; set; }
        public VAutoService()
        {
            //http://vautointerview.azurewebsites.net/api/datasetId

            this.Client = RestEase.RestClient.For<IClient>("http://vautointerview.azurewebsites.net/api");
        }

        public async  Task<DatasetIdResponse> GetDataSetId() {
          return await this.Client.DataSetGetDataSetId();
        }
    }
}
