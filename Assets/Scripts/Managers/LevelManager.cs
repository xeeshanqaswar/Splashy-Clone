using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region FIELDS DELCERATION

    [Header("== PROPERTIES ==")]
    public int preInstCount = 50;
    public float spawnDistanceV = 4f;
    public float spawnDistanceH = 2f;
    public GameObject platformPrefab;

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
        for (int i = 0; i < preInstCount; i++)
        {
            float horizontalPos = i > 0 && i != preInstCount - 1 ? UnityEngine.Random.Range(-spawnDistanceH, spawnDistanceH) : 0f;
            Vector3 spawnPoint = new Vector3(horizontalPos, 0f, spawnDistanceV * i);

            GameObject obj = Instantiate(platformPrefab, spawnPoint, Quaternion.identity, transform);
        }
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