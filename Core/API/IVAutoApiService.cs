using System.Threading.Tasks;
using VAuto.Core.Model;

namespace VAuto.Core.API
{
    public interface IVAutoApiService
    {       

        Task<DatasetIdResponse> GetDataSetId();
        Task<DealersResponse> GetDealer(string datasetId, int? dealerId);
        Task<VehicleIdsResponse> GetVehicleIds(string datasetId);
        Task<VehicleResponse> GetVehicles(string datasetId, int? vehicleId);
        Task<AnswerResponse> PostAnswer(string datasetId, Answer answer);
    }
}