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
            Console.Out.WriteLine($"Test_RetriveDataAndPostMyAnswer-Answer: {answer.ToJson()}");
            var answerResponse =VAutoService.PostAnswer(datasetId, answer).Result;
            return answerResponse;
        }

        /// <summary>
        /// BuildAnswer
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<Answer> BuildAnswer(string datasetId)
        {
            var answer = new Answer() { Dealers = new List<DealerAnswer>() };

            var vehicleIdsResp = await VAutoService.GetVehicleIds(datasetId);
            Console.Out.WriteLine($"VehicleIdsResp:{vehicleIdsResp.ToJson()}");

            var vehicleTasks = vehicleIdsResp.VehicleIds.Select(async vid =>
            {
                var vehicleResp = await VAutoService.GetVehicles(datasetId, vid);
                Console.Out.WriteLine($"VehicleResp:{vehicleResp.ToJson()}");
                await UpdateAnswer(answer, datasetId, vehicleResp);

            });

            await Task.WhenAll(vehicleTasks).ContinueWith((task) =>
            {         
                //todo:something  
                Console.Out.WriteLine($"Answer build completed:{answer.ToJson()}");

            });


            return answer;

        }

        private async Task UpdateAnswer(Answer answer, string datasetId, VehicleResponse vehicleResp)
        {
            bool needLoadDealerName = false;
            DealerAnswer dealer = null;
            lock (answer)
            {
                dealer = answer.Dealers.SingleOrDefault(d => d.DealerId == vehicleResp.DealerId);
                if (dealer == null)
                {
                    dealer = new DealerAnswer()
                    {
                        DealerId = vehicleResp.DealerId
                    };

                    answer.Dealers.Add(dealer);

                    needLoadDealerName = true;
                }

                if (dealer.Vehicles == null)
                {
                    dealer.Vehicles = new List<VehicleAnswer>();

                }
                var vehicle = BuildVehicle(vehicleResp);
                Console.Out.WriteLine($"UpdateAnswer: AddVeicleToDealer-{dealer.DealerId} :{vehicle.ToJson()}");
                dealer.Vehicles.Add(vehicle);
            }
          
            if (needLoadDealerName)
            {
                var dealerRes = await VAutoService.GetDealer(datasetId, vehicleResp.DealerId);
                Console.Out.WriteLine($"UpdateAnswer: updateDealerName:{dealerRes.ToJson()}");
                dealer.Name = dealerRes.Name;
            }
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

