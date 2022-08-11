using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanFactory : MonoBehaviour, IHumanFactory
{
    public List<GameObject> humanObj;
    [Header("Spawn")]
    public Transform spawnArea;
    private Vector2 spawnAreaMax = new Vector2(8, 6);
    private Vector2 spawnAreaMin = new Vector2(-8, 6);

    public GameObject HumanFactoryMethod(int tag)
    {
        GameObject humanSpawn = Instantiate(humanObj[tag]);
        return humanSpawn;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
