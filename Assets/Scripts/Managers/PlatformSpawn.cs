using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public int spawnCount = 50;
    public float spawnDistanceV = 4f;
    public float spawnDistanceH = 2f;
    public GameObject platformPrefab;

    private GameObject platformsParent;
    private GameObject[] platformsContainer;
    private Vector3 spawnPosition;

    void Start()
    {
        platformsParent = new GameObject("Platforms");
        platformsParent.transform.parent = transform;

        SpawnPlatforms();
    }

    private void SpawnPlatforms()
    {
        platformsContainer = new GameObject[spawnCount];
        for (int i=0; i<spawnCount; i++ )
        {
            float horizontalPosition = i>0 && i!=spawnCount-1? UnityEngine.Random.Range(-spawnDistanceH, spawnDistanceH) :0f;
            spawnPosition = new Vector3(horizontalPosition, 0f, spawnDistanceV * i);

            GameObject obj = Instantiate(platformPrefab, spawnPosition, Quaternion.identity, platformsParent.transform);
            platformsContainer[i] = obj;
        }
    }

}
