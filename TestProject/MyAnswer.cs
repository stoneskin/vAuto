using System;
using System.Collections.Generic;
using System.Text;
using VAuto.RestClient;
using VAuto.Core.Model;
using VAuto.Core.API;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject
{
    public class MyAnswer
    {
        public IVAutoApiService VAutoService { get; set; }
        public MyAnswer()
        {
            VAutoService = new VAutoApiServiceIml();
        }
        /// <summary>
        /// my answwer process
        /// </summary>
        public AnswerResponse RetriveDataAndPostMyAnswer() {

            var datasetId = VAutoService.GetDataSetId().Result.DatasetId;
            var answer =   BuildAnswer(datasetId).Result;
            var answerResponse =VAutoService.PostAnswer(datasetId, answer).Result;
            return answerResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<Answer> BuildAnswer(string datasetId)
        {
            var answer = new Answer() { Dealers = new List<DealerAnswer>() };

            var vehicleIdsResp = await VAutoService.GetVehicleIds(datasetId);


            var vehicleTasks = vehicleIdsResp.VehicleIds.Select(async vid =>
            {
                var vehicleResp = await VAutoService.GetVehicles(datasetId, vid);
                await UpdateAnswer(answer, datasetId, vehicleResp);

            });

            await Task.WhenAll(vehicleTasks).ContinueWith((task) =>
            {
                //todo
                //check duplicat item in dealers
                Console.Out.WriteLine($"Dealers count:{answer.Dealers.Count()}");

            });


            return answer;

        }

        private async Task UpdateAnswer(Answer answer, string datasetId, VehicleResponse vehicleResp)
        {
            var dealer = answer.Dealers.SingleOrDefault(d => d.DealerId == vehicleResp.DealerId);
            if (dealer == null)
            {
                dealer = new DealerAnswer()
                {
                    DealerId = vehicleResp.DealerId
                };
                answer.Dealers.Add(dealer);
            }

            if (dealer.Vehicles == null) dealer.Vehicles = new List<VehicleAnswer>();
            dealer.Vehicles.Add(BuildVehicle(vehicleResp));

            var dealerRes = await VAutoService.GetDealer(datasetId, vehicleResp.DealerId);
            dealer.Name = dealerRes.Name;
        }

        private static VehicleAnswer BuildVehicle(VehicleResponse vehicleResp)
        {
            return new VehicleAnswer()
            {
                Make = vehicleResp.Make,
                Model = vehicleResp.Model,
                Year = vehicleResp.Year,
                VehicleId = vehicleResp.VehicleId
            };
        }
    }
}

