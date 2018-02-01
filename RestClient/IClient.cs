using RestClient.ClientApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestClient
{
    public interface IClient: IDataSetApi, IDealersApi,IVehiclesApi
    {
    }
}
