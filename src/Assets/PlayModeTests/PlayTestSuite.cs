using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class PlayTestSuite
    {
        // // A Test behaves as an ordinary method
        // [Test]
        // public void PlayTestSuiteSimplePasses()
        // {
        //     // Use the Assert class to test conditions
        // }

        // // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // // `yield return null;` to skip a frame.
        // [UnityTest]
        // public IEnumerator PlayTestSuiteWithEnumeratorPasses()
        // {
        //     // Use the Assert class to test conditions.
        //     // Use yield to skip a frame.
        //     yield return null;
        // }

        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene("Scenes/AustinsTestingScene");
        }

        [UnityTest]
        public IEnumerator _Instantiates_EnemyObject_From_Prefab()
        {
            var enemyPrefab = Resources.Load("Prefabs/enemy");
            var spawnedEnemy = GameObject.FindWithTag("Enemy");

            yield return new WaitForSeconds(0.0f);

            var prefabOfSpawnedEnemy = PrefabUtility.GetPrefabParent(spawnedEnemy);

            Assert.AreEqual(enemyPrefab, prefabOfSpawnedEnemy); 
        }

        [UnityTest]
        public IEnumerator _Instantiates_ItemObject_From_Prefab()
        {
            var item1Prefab = Resources.Load("Prefabs/PickPocket");
            var item2Prefab = Resources.Load("Prefabs/ItemDefault");
            var item3Prefab = Resources.Load("Prefabs/SpeedBoost");
            var spawnedItem = GameObject.FindWithTag("Item");

            yield return new WaitForSeconds(0.0f);

            var prefabOfSpawnedItem = PrefabUtility.GetPrefabParent(spawnedItem);

            Assert.AreEqual(item1Prefab, prefabOfSpawnedItem); 
            Assert.AreEqual(item2Prefab, prefabOfSpawnedItem); 
            Assert.AreEqual(item3Prefab, prefabOfSpawnedItem); 
        }
    }
}
