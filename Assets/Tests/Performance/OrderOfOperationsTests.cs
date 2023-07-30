using NUnit.Framework;
using Optimization.Client.Runtime;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Optimization.Tests.Performance
{
    public sealed class OrderOfOperationsTests
    {
        private readonly Vector3 _vector3 = new(789, 123, 456);

        private const float _float = 2035.72f;

        [Test, Performance]
        public void FxFxV_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.IterationCountForLinqMin; i++)
                {
                    Vector3 result = _float * _float * _vector3;
                }
            }).Run();
        }
        [Test, Performance]
        public void FxVxF_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.IterationCountForLinqMin * 5; i++)
                {
                    Vector3 result = _float * _vector3 * _float;
                }
            }).Run();
        }
        [Test, Performance]
        public void VxFxF_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.IterationCountForLinqMin * 5; i++)
                {
                    Vector3 result = _vector3 * _float * _float;
                }
            }).Run();
        }
    }
}