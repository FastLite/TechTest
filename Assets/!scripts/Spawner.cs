using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public List<GameObject> fishes;
    public Transform[] spawnSpots;
    private float SpawnCountdown;
    public int defaultTime;

    [SerializeField]
    private GameObject target;
    

    private void Start()
    {
        SpawnCountdown = defaultTime;
    }

    void Update()
    {
        if (SpawnCountdown <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length);
            GameObject obj = Instantiate(fishes[Random.Range(0, fishes.Count)], new Vector2(spawnSpots[randPos].position.x, spawnSpots[randPos].position.y), quaternion.identity);
            
            
            SpawnCountdown = defaultTime + Random.Range(-3,3);
        }
        else
            SpawnCountdown -= Time.deltaTime;
    }
}
