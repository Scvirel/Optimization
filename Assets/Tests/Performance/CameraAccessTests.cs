using NUnit.Framework;
using Optimization.Client.Runtime;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Optimization.Tests.Performance
{
    public sealed class CameraAccessTests
    {
        private Camera _cameraCache = default;

        public CameraAccessTests()
        {
            GameObject camera = new GameObject("Camera");
            camera.AddComponent<Camera>();
            camera.tag = "MainCamera";

            _cameraCache = Camera.main;
        }

        [Test, Performance]
        public void GlobalCache_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    Color backgroundColor = _cameraCache.backgroundColor;
                }
            }).Run();
        }

        [Test, Performance]
        public void CameraMainRuntime_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    Color backgroundColor = Camera.main.backgroundColor;
                }
            }).Run();
        }

        [Test, Performance]
        public void FindObjectOfType_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    Color backgroundColor = GameObject.FindObjectOfType<Camera>().backgroundColor;
                }
            }).Run();
        }
        [Test, Performance]
        public void FindAnyObjectByType_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    Color backgroundColor = ((Camera)GameObject.FindAnyObjectByType(typeof(Camera))).backgroundColor;
                }
            }).Run();
        }
        [Test, Performance]
        public void FindFirstObjectByType_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    Color backgroundColor = ((Camera)GameObject.FindFirstObjectByType(typeof(Camera))).backgroundColor;
                }
            }).Run();
        }
        [Test, Performance]
        public void FindWithTag_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    Color backgroundColor = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().backgroundColor;
                }
            }).Run();
        }
    }
}