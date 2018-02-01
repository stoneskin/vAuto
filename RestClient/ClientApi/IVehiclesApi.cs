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
    public interface IVehiclesApi
    {
        /// <summary>
        /// Get a list of all vehicleids in dataset 
        /// </summary>
        /// <param name="datasetId"></param>
        /// <returns>VehicleIdsResponse</returns>
        [Get("/{datasetId}/vehicles")]
        Task<VehicleIdsResponse> VehiclesGetIds([Path]string datasetId);
        /// <summary>
        /// Get information about a vehicle 
        /// </summary>
        /// <param name="datasetId"></param>
        /// <param name="vehicleid"></param>
        /// <returns>VehicleResponse</returns>
        [Get("/{datasetId}/vehicles/{vehicleid}")]
        Task<VehicleResponse> VehiclesGetVehicle([Path]string datasetId, [Path] int? vehicleid);
    }   


}
