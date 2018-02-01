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
    public interface IDataSetApi
    {
        /// <summary>
        /// Get correct answer for dataset (cheat) 
        /// </summary>
        /// <param name="datasetId"></param>
        /// <returns>Answer</returns>
        Answer DataSetGetCheat (string datasetId);
        /// <summary>
        /// Creates new dataset and returns its ID 
        /// </summary>
        /// <returns>DatasetIdResponse</returns>
        DatasetIdResponse DataSetGetDataSetId ();
        /// <summary>
        /// Submit answer for dataset 
        /// </summary>
        /// <param name="datasetId"></param>
        /// <param name="answer"></param>
        /// <returns>AnswerResponse</returns>
        AnswerResponse DataSetPostAnswer (string datasetId, Answer answer);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DataSetApi : IDataSetApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataSetApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DataSetApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DataSetApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DataSetApi(String basePath)
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
        /// Get correct answer for dataset (cheat) 
        /// </summary>
        /// <param name="datasetId"></param> 
        /// <returns>Answer</returns>            
        public Answer DataSetGetCheat (string datasetId)
        {
            
            // verify the required parameter 'datasetId' is set
            if (datasetId == null) throw new ApiException(400, "Missing required parameter 'datasetId' when calling DataSetGetCheat");
            
    
            var path = "/api/{datasetId}/cheat";
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
                throw new ApiException ((int)response.StatusCode, "Error calling DataSetGetCheat: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DataSetGetCheat: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Answer) ApiClient.Deserialize(response.Content, typeof(Answer), response.Headers);
        }
    
        /// <summary>
        /// Creates new dataset and returns its ID 
        /// </summary>
        /// <returns>DatasetIdResponse</returns>            
        public DatasetIdResponse DataSetGetDataSetId ()
        {
            
    
            var path = "/api/datasetId";
            path = path.Replace("{format}", "json");
                
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
                throw new ApiException ((int)response.StatusCode, "Error calling DataSetGetDataSetId: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DataSetGetDataSetId: " + response.ErrorMessage, response.ErrorMessage);
    
            return (DatasetIdResponse) ApiClient.Deserialize(response.Content, typeof(DatasetIdResponse), response.Headers);
        }
    
        /// <summary>
        /// Submit answer for dataset 
        /// </summary>
        /// <param name="datasetId"></param> 
        /// <param name="answer"></param> 
        /// <returns>AnswerResponse</returns>            
        public AnswerResponse DataSetPostAnswer (string datasetId, Answer answer)
        {
            
            // verify the required parameter 'datasetId' is set
            if (datasetId == null) throw new ApiException(400, "Missing required parameter 'datasetId' when calling DataSetPostAnswer");
            
            // verify the required parameter 'answer' is set
            if (answer == null) throw new ApiException(400, "Missing required parameter 'answer' when calling DataSetPostAnswer");
            
    
            var path = "/api/{datasetId}/answer";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "datasetId" + "}", ApiClient.ParameterToString(datasetId));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(answer); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling DataSetPostAnswer: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling DataSetPostAnswer: " + response.ErrorMessage, response.ErrorMessage);
    
            return (AnswerResponse) ApiClient.Deserialize(response.Content, typeof(AnswerResponse), response.Headers);
        }
    
    }
}
