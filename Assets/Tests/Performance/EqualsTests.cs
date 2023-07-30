using NUnit.Framework;
using Optimization.Client.Runtime;
using Unity.PerformanceTesting;

namespace Optimization.Tests.Performance
{
    public sealed class EqualsTests
    {
        private string _s1 = "S1";
        private string _s2 = "S2";

        private int _int1 = 1;
        private int _int2 = 2;

        [Test, Performance]
        public void ReferenceEquals_Operator_Test()
        {
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = _s1 == _s2;
                }
            }).Run();
        }
        [Test, Performance]
        public void ReferenceEquals_EqualsConstruction_Test()
        {
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = _s1.Equals(_s2);
                }
            }).Run();
        }
        [Test, Performance]
        public void ReferenceEquals_ReferenceEqualsConstruction_Test()
        {
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = System.Object.ReferenceEquals(_s1, _s2);
                }
            }).Run();
        }

        [Test, Performance]
        public void ValueEquals_Operator_Test()
        {
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = _int1 == _int2;
                }
            }).Run();
        }
        [Test, Performance]
        public void ValueEquals_EqualsConstruction_Test()
        {
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = _int1.Equals(_int2);
                }
            }).Run();
        }
        [Test, Performance]
        public void ValueEquals_ReferenceEqualsConstruction_Test()
        {
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = System.Object.ReferenceEquals(_int1, _int2);
                }
            }).Run();
        }

        [Test, Performance]
        public void MixedImplicitEquals_EqualsConstruction_Test()
        {
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = _int1.Equals(_s1);
                }
            }).Run();
        }
        [Test, Performance]
        public void MixedImplicitEquals_ReferenceEqualsConstruction_Test()
        {
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = System.Object.ReferenceEquals(_int1, _s1);
                }
            }).Run();
        }

        [Test, Performance]
        public void MixedExplicitEquals_Operator_Test()
        {
            object temp1 = _s1;
            object temp2 = _int1;
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = temp1 == temp2;
                }
            }).Run();
        }
        [Test, Performance]
        public void MixedExplicitEquals_EqualsConstruction_Test()
        {
            object temp1 = _s1;
            object temp2 = _int1;
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = temp1.Equals(temp2);
                }
            }).Run();
        }
        [Test, Performance]
        public void MixedExplicitEquals_ReferenceEqualsConstruction_Test()
        {
            object temp1 = _s1;
            object temp2 = _int1;
            bool result = default;

            Measure.Method(() =>
            {
                for (var i = 0; i < Constants.GeneralIterationCountMin; i++)
                {
                    result = System.Object.ReferenceEquals(temp1, temp2);
                }
            }).Run();
        }
    }
}