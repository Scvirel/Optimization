using NUnit.Framework;
using Optimization.Client.Runtime;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Optimization.Tests.Performance
{
    public sealed class FindObjectsTests
    {
        private const string Tag = "TestTag";

        public FindObjectsTests()
        {
            GameObject testObjectCollider1 = new GameObject("TestObjectCollider1");
            testObjectCollider1.AddComponent<Collider>();

            GameObject testObjectCollider2 = new GameObject("TestObjectCollider2");
            testObjectCollider2.AddComponent<Collider>();

            GameObject testObjectCollider3 = new GameObject("TestObjectCollider3");
            testObjectCollider3.AddComponent<Collider>();

            GameObject testObjectCollider4 = new GameObject("TestObjectCollider4");
            testObjectCollider4.AddComponent<Collider>();

            GameObject testObjectRigidbody1 = new GameObject("TestObjectRigidbody1");
            testObjectRigidbody1.AddComponent<Rigidbody>();
            testObjectRigidbody1.tag = Tag;

            GameObject testObjectRigidbody2 = new GameObject("TestObjectRigidbody2");
            testObjectRigidbody2.AddComponent<Rigidbody>();
            testObjectRigidbody2.tag = Tag;

            GameObject testObjectRigidbody3 = new GameObject("TestObjectRigidbody3");
            testObjectRigidbody3.AddComponent<Rigidbody>();
            testObjectRigidbody3.tag = Tag;
        }

        [Test, Performance]
        public void FindGameObjectsWithTag_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    GameObject[] values = GameObject.FindGameObjectsWithTag(Tag);
                }
            }).Run();
        }
        [Test, Performance]
        public void FindObjectsOfType_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    Rigidbody[] values = GameObject.FindObjectsOfType<Rigidbody>();
                }
            }).Run();
        }
        [Test, Performance]
        public void FindObjectsByType_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    Rigidbody[] values = (Rigidbody[])GameObject.FindObjectsByType(typeof(Rigidbody),FindObjectsSortMode.None);
                }
            }).Run();
        }
    }
}