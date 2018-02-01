using Model;
using RestEase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.ClientApi
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDealersApi
    {
        /// <summary>
        /// Get information about a dealer 
        /// </summary>
        /// <param name="datasetId"></param>
        /// <param name="dealerid"></param>
        /// <returns>DealersResponse</returns>
        [Get("{datasetId}/dealers/{dealerid}")]
        Task<DealersResponse> DealersGetDealer([Path]string datasetId, [Path]int? dealerid);
    }
}
