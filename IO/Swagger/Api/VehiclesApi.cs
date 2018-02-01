using System;
using System.Collections.Generic;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
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
        VehicleIdsResponse VehiclesGetIds (string datasetId);
        /// <summary>
        /// Get information about a vehicle 
        /// </summary>
        /// <param name="datasetId"></param>
        /// <param name="vehicleid"></param>
        /// <returns>VehicleResponse</returns>
        VehicleResponse VehiclesGetVehicle (string datasetId, int? vehicleid);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class VehiclesApi : IVehiclesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehiclesApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public VehiclesApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="VehiclesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public VehiclesApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        /// Get a list of all vehicleids in dataset 
        /// </summary>
        /// <param name="datasetId"></param> 
        /// <returns>VehicleIdsResponse</returns>            
        public VehicleIdsResponse VehiclesGetIds (string datasetId)
        {
            
            // verify the required parameter 'datasetId' is set
            if (datasetId == null) throw new ApiException(400, "Missing required parameter 'datasetId' when calling VehiclesGetIds");
            
    
            var path = "/api/{datasetId}/vehicles";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "datasetId" + "}", ApiClient.ParameterToString(datasetId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling VehiclesGetIds: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling VehiclesGetIds: " + response.ErrorMessage, response.ErrorMessage);
    
            return (VehicleIdsResponse) ApiClient.Deserialize(response.Content, typeof(VehicleIdsResponse), response.Headers);
        }
    
        /// <summary>
        /// Get information about a vehicle 
        /// </summary>
        /// <param name="datasetId"></param> 
        /// <param name="vehicleid"></param> 
        /// <returns>VehicleResponse</returns>            
        public VehicleResponse VehiclesGetVehicle (string datasetId, int? vehicleid)
        {
            
            // verify the required parameter 'datasetId' is set
            if (datasetId == null) throw new ApiException(400, "Missing required parameter 'datasetId' when calling VehiclesGetVehicle");
            
            // verify the required parameter 'vehicleid' is set
            if (vehicleid == null) throw new ApiException(400, "Missing required parameter 'vehicleid' when calling VehiclesGetVehicle");
            
    
            var path = "/api/{datasetId}/vehicles/{vehicleid}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "datasetId" + "}", ApiClient.ParameterToString(datasetId));
path = path.Replace("{" + "vehicleid" + "}", ApiClient.ParameterToString(vehicleid));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling VehiclesGetVehicle: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling VehiclesGetVehicle: " + response.ErrorMessage, response.ErrorMessage);
    
            return (VehicleResponse) ApiClient.Deserialize(response.Content, typeof(VehicleResponse), response.Headers);
        }
    
    }
}
