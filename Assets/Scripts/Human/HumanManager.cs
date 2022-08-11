using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HumanManager : MonoBehaviour
{
    public EnemyState state;

    public ScoreManager scoreManager;
    public EnemyManager enemyManager;

    [Header("Enemy")]
    public GameObject human;
    public List<GameObject> humanList;
    public List<GameObject> humanDestroyed;
    public int maxHuman;

    [Header("Spawn")]
    public Transform spawnArea;
    private Vector2 spawnAreaMax = new Vector2(8, 6);
    private Vector2 spawnAreaMin = new Vector2(-8, 6);

    [Header("Timer")]
    public float spawnInterval = 1.5f;
    private float timer;



    // Start is called before the first frame update
    void Start()
    {
        maxHuman = Random.Range(2, 4);
        humanList = new List<GameObject>();
        humanDestroyed = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyHuman();

        state = enemyManager.state;

        if (humanList.Count == 0 && state == EnemyState.Generate)
        {
            maxHuman = Random.Range(2, 4);
            GenerateHuman();
            //state = EnemyState.Spawn;
        }

        if (humanDestroyed.Count >= 0 && state == EnemyState.Generate)
        {

        }
        else
            GenerateHuman();
    }

    public void GenerateHuman()
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            GenerateHuman(new Vector2(Random.Range(spawnAreaMin.x, spawnAreaMax.x), Random.Range(spawnAreaMin.y, spawnAreaMax.y)));
            timer -= spawnInterval;
        }
    }

    public void GenerateHuman(Vector2 position)
    {
        if (humanList.Count >= maxHuman)
        {
            return;
        }

        if (position.x < spawnAreaMin.x || position.x > spawnAreaMax.x || position.y < spawnAreaMin.y || position.y > spawnAreaMax.y)
        {
            return;
        }

        GameObject humanSpawn = Instantiate(human, new Vector3(position.x, position.y, human.transform.position.z), Quaternion.identity, spawnArea);
        humanSpawn.SetActive(true);

        humanList.Add(humanSpawn);
    }

    public void DestroyHuman()
    {
        if (Input.GetMouseButtonDown(0) && scoreManager.isGameOver == false)
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit2D.collider != null)
            {
                if (hit2D.collider.tag == "Humans")
                {
                    scoreManager.GameOver();
                    Debug.Log("Dont Touch Me and You Lose");
                }
            }
        }
    }

    public void RemoveAllHuman()
    {
        while (humanList.Count > 0)
        {
            RemoveHumanList(humanList[0]);
        }

        while (humanDestroyed.Count > 0)
        {
            RemoveDestroyedList(humanDestroyed[0]);
        }
    }

    public void RemoveHumanList(GameObject enemySpawn)
    {
        humanList.Remove(enemySpawn);
        Debug.Log("Remove Human");
    }

    public void RemoveDestroyedList(GameObject enemyDestroy)
    {
        humanDestroyed.Remove(enemyDestroy);
        Debug.Log("Remove Human");
    }
}
