using NUnit.Framework;
using Optimization.Client.Runtime;
using System.Text;
using Unity.PerformanceTesting;

namespace Optimization.Tests.Performance
{
    public sealed class StringTests
    {
        private const string Phrase = "Temp";

        [Test, Performance]
        public void Concatenation_Test()
        {
            Measure.Method(() =>
            {
                string result = default;
                for (int i = 0; i < Constants.IterationCountForLinqMin; i++)
                {
                    result += Phrase;
                }
            }).Run();
        }

        [Test, Performance]
        public void StringBuilder_Test()
        {
            Measure.Method(() =>
            {
                StringBuilder builder = new StringBuilder();
                string result = default;

                for (int i = 0; i < Constants.IterationCountForLinqMin; i++)
                {
                    builder.Append(Phrase);
                }

                result = builder.ToString();
            }).Run();
        }

        [Test, Performance]
        public void Interpolation_Test()
        {
            Measure.Method(() =>
            {
                string result = default;

                for (int i = 0; i < Constants.IterationCountForLinqMin; i++)
                {
                    result = $"{Phrase}";
                }
            }).Run();
        }
        [Test, Performance]
        public void StringFormat_Test()
        {
            Measure.Method(() =>
            {
                string result = default;

                for (int i = 0; i < Constants.IterationCountForLinqMin; i++)
                {
                    result = string.Format($"{0}", Phrase);
                }
            }).Run();
        }
    }
}