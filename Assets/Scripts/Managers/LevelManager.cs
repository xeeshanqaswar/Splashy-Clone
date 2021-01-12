using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region FIELDS DELCERATION

    [Header("== PROPERTIES ==")]
    public int preInstCount = 20;
    public float spawnDistanceV = 4f;
    public float spawnDistanceH = 2f;
    public GameObject platformPrefab;
    public GameObject levelCompletePrefab;

    private GameData _gameData;
    private Camera mainCamera;

    public static LevelManager Instance;

    #endregion

    private void Awake()
    {
        Instance = this;
    }

    public void Init(GameData data)
    {
        GameManager.Instance.LevelCompleteEvent += OnLevelComplete;
        GameManager.Instance.GameOverEvent += OnGameOver;

        _gameData = data;
        LevelGeneration();  
    }

    public void Tick( float delta)
    {

    }

    private void LevelGeneration()
    {
        GameObject platform;
        Vector3 spawnPoint = Vector3.zero;

        for (int i = 0; i < preInstCount - 1; i++)
        {
            platform = Instantiate(platformPrefab, spawnPoint, Quaternion.identity, transform);

            float randHorizontal = i > 0 && i != preInstCount - 1 ? UnityEngine.Random.Range(-spawnDistanceH, spawnDistanceH) : 0f;
            spawnPoint.z += spawnDistanceV;
            spawnPoint.x = randHorizontal;
        }

        // Spawning Endpoint
        spawnPoint.x = 0;
        platform = Instantiate(levelCompletePrefab, spawnPoint, Quaternion.identity, transform);

    }

    #region EVENT LISTNERS

    public void OnLevelComplete()
    {

    }

    public void OnGameOver()
    {

    }

    #endregion

    private void OnDisable()
    {
        GameManager.Instance.LevelCompleteEvent -= OnLevelComplete;
        GameManager.Instance.GameOverEvent -= OnGameOver;
    }

}