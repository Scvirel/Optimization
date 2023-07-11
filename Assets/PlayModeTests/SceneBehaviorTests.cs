using NUnit.Framework;
using Optimization.Client.Runtime;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Optimization.Tests.Runtime
{
    public sealed class SceneBehaviorTests
    {
        private const float LoadingTimeout = 5f;

        [UnityTest]
        public IEnumerator SceneLoad_Additive_Loaded()
        {
            Scene resultScene = default;

            SceneManager.LoadScene(GameScenes.Sandbox, LoadSceneMode.Additive);

            yield return Wait.Until(() =>
            {
                resultScene = SceneManager.GetSceneByName(GameScenes.Sandbox);

                return resultScene.isLoaded;
            }, 
            LoadingTimeout);

            Assert.IsTrue(resultScene.isLoaded);
        }

        [UnityTest]
        public IEnumerator SceneLoad_AdditiveAsync_Loaded()
        {
            Scene resultScene = default;

            SceneManager.LoadSceneAsync(GameScenes.Sandbox, LoadSceneMode.Additive);

            yield return Wait.Until(() =>
            {
                resultScene = SceneManager.GetSceneByName(GameScenes.Sandbox);

                return resultScene.isLoaded;
            }, 
            LoadingTimeout);

            Assert.IsTrue(resultScene.isLoaded);
        }

        [UnityTest]
        public IEnumerator SceneLoad_Single_Loaded()
        {
            Scene resultScene = default;

            SceneManager.LoadScene(GameScenes.TestBox, LoadSceneMode.Single);

            yield return Wait.Until(() =>
            {
                resultScene = SceneManager.GetSceneByName(GameScenes.TestBox);

                return resultScene.isLoaded;
            },
            LoadingTimeout);

            Assert.IsTrue(resultScene.isLoaded);
        }

        [UnityTest]
        public IEnumerator SceneLoad_SingleAsync_Loaded()
        {
            Scene resultScene = default;

            SceneManager.LoadSceneAsync(GameScenes.TestBox, LoadSceneMode.Single);

            yield return Wait.Until(() =>
            {
                resultScene = SceneManager.GetSceneByName(GameScenes.TestBox);

                return resultScene.isLoaded;
            },
            LoadingTimeout);

            Assert.IsTrue(resultScene.isLoaded);
        }
    }
}