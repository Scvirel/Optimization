using NUnit.Framework;
using Optimization.Client.Runtime;
using UnityEngine.SceneManagement;

namespace Optimization.Tests.Editor
{
    public class BuildSettingsTests
    {
        [Test]
        public void BuildInAndLocalConfigScenes_Count_Same()
        {
            int buildInCount = SceneManager.sceneCountInBuildSettings;
            int localConfigCount = typeof(GameScenes).GetFields().Length;

            Assert.AreEqual(buildInCount, localConfigCount);
        }
    }
}