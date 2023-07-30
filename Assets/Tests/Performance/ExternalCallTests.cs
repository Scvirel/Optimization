using NUnit.Framework;
using Optimization.Client.Runtime;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Optimization.Tests.Performance
{
    public sealed class ExternalCallTests
    {
        private GameObject _testObject = default;
        private Transform _testTransform = default;

        public ExternalCallTests()
        {
            _testObject = new GameObject("TestObject");
            _testTransform = _testObject.transform;
        }

        [Test, Performance]
        public void ExternalCall_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    Vector3 position = _testObject.transform.position;
                    Quaternion rotation = _testObject.transform.rotation;
                    Vector3 scale = _testObject.transform.localScale;
                }
            }).Run();
        }
        [Test, Performance]
        public void LocalCachePerIteration_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    Transform transform = _testObject.transform;
                    Vector3 position = transform.position;
                    Quaternion rotation = transform.rotation;
                    Vector3 scale = transform.localScale;
                }
            }).Run();
        }
        [Test, Performance]
        public void GlobalCache_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    Vector3 position = _testTransform.position;
                    Quaternion rotation = _testTransform.rotation;
                    Vector3 scale = _testTransform.localScale;
                }
            }).Run();
        }
    }
}