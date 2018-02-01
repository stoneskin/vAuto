using Microsoft.VisualStudio.TestTools.UnitTesting;
using VAuto.RestClient;
using VAuto.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace TestProject
{
    [TestClass]
    public class MyAnswerTest
    {

      


        [TestMethod]
        public void Test_BuildAnswer()
        {
            var myanswer = new MyAnswer();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var datasetId = myanswer.VAutoService.GetDataSetId().Result.DatasetId;
            var answer = myanswer.BuildAnswer(datasetId).Result;
            var answerResponse = myanswer.VAutoService.PostAnswer(datasetId, answer).Result;
            stopwatch.Stop();
            Console.Out.WriteLine($"TestBuildAnswer");
            Assert.IsNotNull(answer);
            Assert.IsTrue(answer.Dealers.Any());
            Assert.IsTrue(answer.Dealers[0].Vehicles.Any());
            Assert.IsTrue(answerResponse.Success == true);
        }

        [TestMethod]
        public void Test_BuildAnswerPerformance()
        {
            var myanswer = new MyAnswer();

            var stopwatch = new Stopwatch();
            var loop = 10;
            long totalElapsed = 0;
            for (var i = 0; i < loop; i++)
            {
                stopwatch.Restart();
                var datasetId = "2RJFYx1p1Qg";
                var answer = myanswer.BuildAnswer(datasetId).Result;
                stopwatch.Stop();
                totalElapsed += stopwatch.ElapsedMilliseconds;
                Console.Out.WriteLine($"Test-BuildAnswer-loop-{i}:{stopwatch.ElapsedMilliseconds} ");
            }
            Console.Out.WriteLine($"Test-BuildAnswer-Avg-Elapsed: {totalElapsed / loop}");


        }

        [TestMethod]
        public void Test_RetriveDataAndPostMyAnswer() {
            var myanswer = new MyAnswer();
            var answerResp= myanswer.RetriveDataAndPostMyAnswer();
            Assert.IsTrue(answerResp.Success.Value);
            Console.Out.WriteLine($"Test_RetriveDataAndPostMyAnswer: {answerResp}");
        }
    }
        
}
