using NUnit.Framework;
using Optimization.Client.Runtime;
using Unity.PerformanceTesting;

namespace Optimization.Tests.Performance
{
    public sealed class NullCheck
    {
        private object TestObject = "Test";

        [Test, Performance]
        public void NullCheck_Operator_Test()
        {
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.IterationCount; i++)
                {
                    result = TestObject == null;
                }
            }).Run();
        }
        [Test, Performance]
        public void NullCheck_EqualsConstruction_Test()
        {
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.IterationCount; i++)
                {
                    result = TestObject.Equals(null);
                }
            }).Run();
        }
        [Test, Performance]
        public void NullCheck_ReferenceEqualsConstruction_Test()
        {
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.IterationCount; i++)
                {
                    result = System.Object.ReferenceEquals(TestObject, null);
                }
            }).Run();
        }
        [Test, Performance]
        public void NullCheck_IsConstruction_Test()
        {
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.IterationCount; i++)
                {
                    result = TestObject is null;
                }
            }).Run();
        }
    }
}