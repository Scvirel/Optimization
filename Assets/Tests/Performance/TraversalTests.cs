using NUnit.Framework;
using Optimization.Client.Runtime;
using System.Collections.Generic;
using System.Linq;
using Unity.PerformanceTesting;

namespace Optimization.Tests.Performance
{
    public sealed class TraversalTests
    {
        private List<int> _list = new List<int>();
        private int[] _array = new int[Constants.GeneralIterationCountMin];

        public TraversalTests()
        {
            for (int i = 0; i < Constants.GeneralIterationCountMin; i++)
            {
                _list.Add(0);
            }
        }

        [Test, Performance]
        public void ForTraversal_Array_Test()
        {
            Measure.Method(() =>
            {
                int result = 0;

                for (int i = 0; i < _array.Length; i++)
                {
                    result += _list[i];
                }
            }).Run();
        }

        [Test, Performance]
        public void ForEachTraversal_Array_Test()
        {
            Measure.Method(() =>
            {
                int result = 0;

                foreach (int item in _array)
                {
                    result += item;
                }
            }).Run();
        }
        [Test, Performance]
        public void ForTraversal_List_Test()
        {
            Measure.Method(() =>
            {
                int result = 0;

                for (int i = 0; i < _list.Count(); i++)
                {
                    result += _list[i];
                }
            }).Run();
        }

        [Test, Performance]
        public void ForEachTraversal_List_Test()
        {
            Measure.Method(() =>
            {
                int result = 0;

                foreach (int item in _list)
                {
                    result += item;
                }
            }).Run();
        }

        [Test, Performance]
        public void ForEachConstructionTraversal_List_Test()
        {
            Measure.Method(() =>
            {
                int result = 0;

                _list.ForEach(item => result += item);

            }).Run();
        }
    }
}