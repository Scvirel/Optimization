using NUnit.Framework;
using Optimization.Client.Runtime;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Optimization.Tests.Performance
{
    public sealed class GetComponentTests
    {
        private GameObject m_testObject = default;

        public GetComponentTests()
        {
            m_testObject = new GameObject("TestObject");
        }

        [Test, Performance]
        public void GetComponent_GenericType_Test()
        {
            Transform result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.IterationCount; i++)
                {
                    result = m_testObject.GetComponent<Transform>();
                }
            }).Run();
        }
        [Test, Performance]
        public void GetComponent_ParameterNameAndImplicitCast_Test()
        {
            Transform result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.IterationCount; i++)
                {
                    result = (Transform)m_testObject.GetComponent("Transform");
                }
            }).Run();
        }
        [Test, Performance]
        public void GetComponent_ParameterNameAndProperty_Test()
        {
            Transform result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.IterationCount; i++)
                {
                    result = m_testObject.GetComponent("Transform").transform;
                }
            }).Run();
        }
        [Test, Performance]
        public void GetComponent_ParameterTypeofAndImplicitCast_Test()
        {
            Transform result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.IterationCount; i++)
                {
                    result = (Transform)m_testObject.GetComponent(typeof(Transform));
                }
            }).Run();
        }
    }
}