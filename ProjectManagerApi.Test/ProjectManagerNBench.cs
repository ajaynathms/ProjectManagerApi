using NBench;
using ProjectManagerApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApi.Test
{
    class ProjectManagerNBench
    {
        private const string AddCounterName = "AddCounter";
        private Counter addCounter;
        private int key;

        private const int AcceptableMinAddThroughput = 100;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            addCounter = context.GetCounter(AddCounterName);
            key = 0;
        }
        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 600000, TestMode = TestMode.Measurement)]
        [CounterMeasurement(AddCounterName)]
        [CounterThroughputAssertion(AddCounterName, MustBe.GreaterThan, AcceptableMinAddThroughput)]
        public void GetAllUsersCounterThroughputBenchMark(BenchmarkContext context)
        {
            UserController oController = new UserController();
            oController.Get();
            addCounter.Increment();
        }
        //[PerfBenchmark(Description = "You can write your description here.",
        //    NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 10000000, TestMode = TestMode.Measurement)]
        //[MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        //public void GetAllUsersMemoryBenchMark()
        //{
        //    UserController oController = new UserController();
        //    oController.Get();
        //    addCounter.Increment();
        //}
    }
}
