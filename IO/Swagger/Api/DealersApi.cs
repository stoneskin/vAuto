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
    public interface IDealersApi
    {
        /// <summary>
        /// Get information about a dealer 
        /// </summary>
        /// <param name="datasetId"></param>
        /// <param name="dealerid"></param>
        /// <returns>DealersResponse</returns>
        DealersResponse DealersGetDealer (string datasetId, int? dealerid);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DealersApi : IDealersApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DealersApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DealersApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DealersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DealersApi(String basePath)
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
        /// Get information about a dealer 
        /// </summary>
        /// <param name="datasetId"></param> 
        /// <param name="dealerid"></param> 
        /// <returns>DealersResponse</returns>            
        public DealersResponse DealersGetDealer (string datasetId, int? dealerid)
        {
            
            // verify the required parameter 'datasetId' is set
            if (datasetId == null) throw new ApiException(400, "Missing required parameter 'datasetId' when calling DealersGetDealer");
            
            // verify the required parameter 'dealerid' is set
            if (dealerid == null) throw new ApiException(400, "Missing required parameter 'dealerid' when calling DealersGetDealer");
            
    
            var path = "/api/{datasetId}/dealers/{dealerid}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "datasetId" + "}", ApiClient.ParameterToString(datasetId));
path = path.Replace("{" + "dealerid" + "}", ApiClient.ParameterToString(dealerid));
    
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
                throw new ApiException ((int)response.StatusCode, "Error calling DealersGetDealer: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DealersGetDealer: " + response.ErrorMessage, response.ErrorMessage);
    
            return (DealersResponse) ApiClient.Deserialize(response.Content, typeof(DealersResponse), response.Headers);
        }
    
    }
}
