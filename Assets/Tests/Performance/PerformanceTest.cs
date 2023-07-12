using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Optimization.Tests.Performance
{
    public sealed class PerformanceTest
    {
        [Test, Performance]
        public void Sum_Count_Test()
        {
            Measure.Method(() =>
            {
                var sum = 0;
                for (var i = 0; i < 10000000; i++)
                {
                    sum += i * 3 / 3;
                }
            }).Run();
        }
    }
}