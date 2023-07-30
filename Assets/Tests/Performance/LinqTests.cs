using NUnit.Framework;
using Optimization.Client.Runtime;
using System.Collections.Generic;
using System.Linq;
using Unity.PerformanceTesting;

namespace Optimization.Tests.Performance
{
    public sealed class LinqTests
    {
        private List<Player> _collection = new List<Player>();

        private sealed class Player
        {
            public string Id { get; }
            public int GamesCount { get; }

            public Player(string id, int gamesCount)
            {
                Id = id;
                GamesCount = gamesCount;
            }
        }

        public LinqTests()
        {
            for (int i = 0; i < Constants.IterationCountForLinqMin; i++)
            {
                _collection.Add(new Player($"{i}", i));
            }
        }

        [Test, Performance]
        public void FirstElementAt_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin * 9; i++)
                {
                    _collection.ElementAt(0);
                }
            }).Run();
        }
        [Test, Performance]
        public void FirstLinq_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.GeneralIterationCountMin * 9; i++)
                {
                    _collection.First();
                }
            }).Run();
        }
        [Test, Performance]
        public void AnyLinq_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.IterationCountForLinqMin * 9; i++)
                {
                    bool result = _collection.Any();
                }
            }).Run();
        }
        [Test, Performance]
        public void Count_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.IterationCountForLinqMin * 9; i++)
                {
                    bool result = _collection.Count != 0;
                }
            }).Run();
        }
        [Test, Performance]
        public void CountLinq_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.IterationCountForLinqMin * 9; i++)
                {
                    bool result = _collection.Count() != 0;
                }
            }).Run();
        }
        [Test, Performance]
        public void ForeachWhere_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.IterationCountForLinqMin * 2; i++)
                {
                    List<Player> result = new List<Player>();

                    foreach (Player item in _collection)
                    {
                        if (item.GamesCount >= 0)
                        {
                            result.Add(item);
                        }
                    }
                }
            }).Run();
        }
        [Test, Performance]
        public void WhereLinq_Test()
        {
            Measure.Method(() =>
            {
                for (int i = 0; i < Constants.IterationCountForLinqMin * 2; i++)
                {
                    List<Player> result = _collection.Where(item => item.GamesCount >= 0).ToList();
                }
            }).Run();
        }
    }

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