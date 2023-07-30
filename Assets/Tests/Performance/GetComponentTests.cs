using NUnit.Framework;
using Optimization.Client.Runtime;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Optimization.Tests.Performance
{
    public sealed class GetComponentTests
    {
        private GameObject _testObject = default;

        public GetComponentTests()
        {
            _testObject = new GameObject("TestObject");
        }

        [Test, Performance]
        public void GetComponent_GenericType_Test()
        {
            Transform result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = _testObject.GetComponent<Transform>();
                }
            }).Run();
        }
        [Test, Performance]
        public void GetComponent_ParameterNameAndImplicitCast_Test()
        {
            Transform result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = (Transform)_testObject.GetComponent("Transform");
                }
            }).Run();
        }
        [Test, Performance]
        public void GetComponent_ParameterNameAndProperty_Test()
        {
            Transform result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = _testObject.GetComponent("Transform").transform;
                }
            }).Run();
        }
        [Test, Performance]
        public void GetComponent_ParameterTypeofAndImplicitCast_Test()
        {
            Transform result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = (Transform)_testObject.GetComponent(typeof(Transform));
                }
            }).Run();
        }
    }
}