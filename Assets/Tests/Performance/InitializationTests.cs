using NUnit.Framework;
using Optimization.Client.Runtime;
using Unity.PerformanceTesting;

namespace Optimization.Tests.Performance
{
    public sealed class InitializationTests
    {
        [Test, Performance]
        public void ExplicitType_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin * 10; i++)
                {
                    string reff = "Qwerty";
                    int value = 123;
                }
            }).Run();
        }
        [Test, Performance]
        public void VarType_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin * 10; i++)
                {
                    var reff = "Qwerty";
                    var value = 123;
                }
            }).Run();
        }
        [Test, Performance]
        public void ObjectType_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin * 10; i++)
                {
                    object reff = "Qwerty";
                    object value = 123;
                }
            }).Run();
        }
        [Test, Performance]
        public void DynamicType_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin * 10; i++)
                {
                    dynamic reff = "Qwerty";
                    dynamic value = 123;
                }
            }).Run();
        }
    }
}