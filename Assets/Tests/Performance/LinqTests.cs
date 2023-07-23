using NUnit.Framework;
using Optimization.Client.Runtime;
using System.Collections.Generic;
using System.Linq;
using Unity.PerformanceTesting;

namespace Optimization.Tests.Performance
{
    public sealed class LinqTests
    {
        private IEnumerable<string> _collection = new List<string>() { "S1", "S2", "S3", "S4", "S5", "S6", "S7" };

        [Test, Performance]
        public void FirstElementAt_Test()
        {
            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.IterationCount; i++)
                {
                    _collection.ElementAt(0);
                }
            }).Run();
        }
        [Test, Performance]
        public void FirstLinq_Test()
        {
            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.IterationCount; i++)
                {
                    _collection.First();
                }
            }).Run();
        }
    }
}