using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region FIELDS DELCERATION

    [Header("== REFERENCES ==")]
    public Transform player;

    [Header("== PROPERTIES ==")]
    public LevelData[] levelProperties;

    private GameData _gameData;
    private Camera mainCamera;

    public static LevelManager Instance;

    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        GameManager.Instance.LevelCompleteEvent += OnLevelComplete;
        GameManager.Instance.GameOverEvent += OnGameOver;
    }

    public void Init(GameData data)
    {
        _gameData = data;
        LevelGeneration();  
    }

    public void Tick( float delta)
    {

    }

    private void LevelGeneration()
    {
        for (int i = 0; i < levelProperties.Length; i++)
        {
            if(i == _gameData.currentLevel)
            {
                mainCamera.backgroundColor = levelProperties[i].levelColor;
                levelProperties[i].sceneObject.SetActive(true);
                player.position = levelProperties[i].spawnPoint.position;
                player.gameObject.SetActive(true);
            }
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

[Serializable]
public class LevelData
{
    public string name = "Level";
    public Transform spawnPoint;
    public Color levelColor;
    public GameObject sceneObject;
    public Color splashColor;
}
