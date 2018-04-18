using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
namespace ProjectManagerApi.NBench
{
    public class ProjectManagerNBench
    {
        private Counter oCounter;
        public void Setup(BenchmarkContext context)
        {
            oCounter = context.GetCounter("PMCounter");

        }
        [PerfBenchmark(NumberOfIterations = 10,RunMode =RunMode.Throughput,RunTimeMilliseconds = 1000,TestMode = TestMode.Measurement)]
        [CounterMeasurement("PMCounter")]
        public void BenchmarkMethod(BenchmarkContext context)
        {
            var bytes =new byte[1024];
            oCounter.Increment();
        }
    }
}
