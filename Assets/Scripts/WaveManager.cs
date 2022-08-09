using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Wave[] waves;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Wave
{
    public string waveName;
    public int enemyCount;
    public GameObject[] enemyPrefab;
    public float spawnInterval;
}
