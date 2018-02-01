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
        public void MyAnswerTest_BuildAnswer()
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
        public void MyAnswerTest_BuildAnswerPerformance()
        {
            var stopwatch = new Stopwatch();
            var myanswer = new MyAnswer();

            var loop = 5;
            long totalElapsed = 0;
            for (var i = 0; i < loop; i++)
            {
                stopwatch.Restart();
                var datasetId = "2RJFYx1p1Qg";
                var answer = myanswer.BuildAnswer(datasetId).Result;
                stopwatch.Stop();
                totalElapsed += stopwatch.ElapsedMilliseconds;
                Console.Out.WriteLine($"Test-BuildAnswer-loop-{i}:{stopwatch.ElapsedMilliseconds} ");
                Console.Out.WriteLine($"Test-BuildAnswer-loop-{i}-answer:{answer.ToJson()} ");
            }
            Console.Out.WriteLine($"Test-BuildAnswer-Avg-Elapsed: {totalElapsed / loop}");


        }

        [TestMethod]
        public void MyAnswerTest_RetriveDataAndPostMyAnswer()
        {
            var stopwatch = new Stopwatch();
            var myanswer = new MyAnswer();
            stopwatch.Start();
            var answerResp = myanswer.RetriveDataAndPostMyAnswer();
            stopwatch.Stop();
            Assert.IsTrue(answerResp.Success.Value);
            Console.Out.WriteLine($"Test_RetriveDataAndPostMyAnswer-Elapsed-[{stopwatch.ElapsedMilliseconds}]: {answerResp}");
        }

        [TestMethod]
        public void MyAnswerTest_MultipleRetriveDataAndPostMyAnswer()
        {
            var stopwatch = new Stopwatch();
            for (var i = 0; i < 15; i++)
            {
                try
                {
                    var myanswer = new MyAnswer();
                    stopwatch.Restart();
                    //var datasetId = myanswer.VAutoService.GetDataSetId().Result.DatasetId;
                    //var answer = myanswer.BuildAnswer(datasetId).Result;
                    //Console.Out.WriteLine($"Test_RetriveDataAndPostMyAnswer-Answer-{i}: {answer.ToJson()}");
                    //var answerResponse = myanswer.VAutoService.PostAnswer(datasetId, answer).Result;
                    var answerResponse = myanswer.RetriveDataAndPostMyAnswer();
             
                    stopwatch.Stop();
                    Assert.IsTrue(answerResponse.Success.Value);
                    Console.Out.WriteLine($"Test_RetriveDataAndPostMyAnswer-Elapsed-[{stopwatch.ElapsedMilliseconds}]: {answerResponse}");
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine($"Test_RetriveDataAndPostMyAnswer-Error: {ex}");

                }
            }
        }
    }

}
