using VAuto.RestClient.ClientApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace VAuto.RestClient
{
    public interface IClient: IDataSetApi, IDealersApi,IVehiclesApi
    {
    }
}
