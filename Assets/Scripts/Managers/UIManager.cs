using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    #region FIELDS DECLERATION

    private GameData _gameData;

    public static UIManager Instance;

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
    }

    public void Tick(float delta)
    {

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
