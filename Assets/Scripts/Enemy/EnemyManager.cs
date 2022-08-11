using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Human;
using Manager;

namespace Enemy
{
    public enum EnemyState { Generate, Spawn }
    public class EnemyManager : MonoBehaviour
    {
        public EnemyState state;

        public ScoreManager scoreManager;
        public HumanManager humanManager;

        [Header("Enemy")]
        public List<GameObject> enemy;
        public List<GameObject> enemyList;
        public List<GameObject> enemyDestroyed;
        public int maxEnemy;

        [Header("Spawn")]
        public Transform spawnArea;
        private Vector2 spawnAreaMax = new Vector2(8, 6);
        private Vector2 spawnAreaMin = new Vector2(-8, 6);

        [Header("Timer")]
        public int spawnInterval = 1;
        private float timer;

        [Header("Wave")]
        public TMP_Text textWave;
        public int amountWave;

        public void Awake()
        {
            state = EnemyState.Generate;
        }
        void Start()
        {
            maxEnemy = Random.Range(3, 9);
            enemyList = new List<GameObject>();
            enemyDestroyed = new List<GameObject>();
        }

        void Update()
        {
            textWave.text = "Wave " + amountWave.ToString();

            if (enemyList.Count == 0 && state == EnemyState.Generate)
            {
                maxEnemy = Random.Range(3, 9);
                GenerateEnemy();

                state = EnemyState.Spawn;
            }

            if (enemyDestroyed.Count >= 0 && state == EnemyState.Generate)
            {

            }
            else
                GenerateEnemy();

            if (enemyDestroyed.Count == maxEnemy)
            {
                RemoveAllEnemy();
                humanManager.RemoveAllHuman();

                GenerateEnemy();
                state = EnemyState.Generate;
                amountWave += 1;
            }
        }
        public void GenerateEnemy()
        {
            timer += Time.deltaTime;
            if (timer > spawnInterval)
            {
                GenerateEnemy(new Vector2(Random.Range(spawnAreaMin.x, spawnAreaMax.x), Random.Range(spawnAreaMin.y, spawnAreaMax.y)));
                timer -= spawnInterval;
            }
        }

        public void GenerateEnemy(Vector2 position)
        {
            if (enemyList.Count >= maxEnemy)
            {
                return;
            }

            if (position.x < spawnAreaMin.x || position.x > spawnAreaMax.x || position.y < spawnAreaMin.y || position.y > spawnAreaMax.y)
            {
                return;
            }

            int randomEnemy = Random.Range(0, enemy.Count);

            GameObject enemySpawn = Instantiate(enemy[randomEnemy], new Vector3(position.x, position.y, enemy[randomEnemy].transform.position.z), Quaternion.identity, spawnArea);
            enemySpawn.SetActive(true);

            enemyList.Add(enemySpawn);
        }

        public void RemoveEnemyList(GameObject enemySpawn)
        {
            enemyList.Remove(enemySpawn);
            Debug.Log("Remove Enemy");
        }

        public void RemoveDestroyedList(GameObject enemyDestroy)
        {
            enemyDestroyed.Remove(enemyDestroy);
            Debug.Log("Remove Enemy");
        }

        public void RemoveAllEnemy()
        {
            while (enemyList.Count > 0)
            {
                RemoveEnemyList(enemyList[0]);
            }

            while (enemyDestroyed.Count > 0)
            {
                RemoveDestroyedList(enemyDestroyed[0]);
            }
        }
    }
}

