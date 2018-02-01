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
    [Header("User-Agent", "vAutoAPI")]
    public interface IDataSetApi
    {
        /// <summary>
        /// Get correct answer for dataset (cheat) 
        /// </summary>
        /// <param name="datasetId"></param>
        /// <returns>Answer</returns>
        [Get("/{datasetId}/cheat")]
        Task<Answer> DataSetGetCheat([Path]string datasetId);
        /// <summary>
        /// Creates new dataset and returns its ID 
        /// </summary>
        /// <returns>DatasetIdResponse</returns>
        [Get("/datasetId")]
        Task<DatasetIdResponse> DataSetGetDataSetId();
        /// <summary>
        /// Submit answer for dataset 
        /// </summary>
        /// <param name="datasetId"></param>
        /// <param name="answer"></param>
        /// <returns>AnswerResponse</returns>
        [Post("/{datasetId}/answer")]
        Task<AnswerResponse> DataSetPostAnswer([Path]string datasetId, Answer answer);
    }
}
