using NUnit.Framework;
using Optimization.Client.Runtime;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Optimization.Tests.Performance
{
    public sealed class DistanceTests
    {
        private Vector3 _vectorZero = Vector3.zero;
        private Vector3 _vectorOne = Vector3.one;

        [Test, Performance]
        public void DistanceConstruction_Test()
        {
            Measure.Method(() =>
            {
                float result = 0f;

                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result += Vector3.Distance(_vectorOne, _vectorZero);
                }
            }).Run();
        }
        [Test, Performance]
        public void sqrMagnitude_Test()
        {
            Measure.Method(() =>
            {
                float result = 0f;

                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result += (_vectorZero - _vectorOne).sqrMagnitude;
                }
            }).Run();
        }
    }
}