using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawner : MonoBehaviour
{
    public bool allowSpawn;
    public GameObject zombiePrefab;
    public float maxDelay;

    private float jerkUnit;
    private Vector3 spawnPos;

    private void Start()
    {
        jerkUnit = maxDelay;
        spawnPos = transform.position;
    }

    private void Update()
    {
        if (allowSpawn)
        {
            if (jerkUnit > 0.0f)
            {
                jerkUnit -= Time.deltaTime;
            }
            else if (jerkUnit <= 0.0f)
            {
                jerkUnit = maxDelay;
                forceSpawn();
            }
        }
    }

    private void forceSpawn()
    {
        if (zombiePrefab)
        {
            Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
        }
    }
}
