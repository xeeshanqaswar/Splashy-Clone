using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    #region FIELDS DECLERATION

    public GameObject mainMenu;
    public GameObject gameOver;
    public GameObject gameComplete;

    private GameData _gameData;

    public static UIManager Instance;

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
    }

    public void Tick(float delta)
    {

    }

    public void OnGameStartPress()
    {
        GameManager.Instance.GameStartEventCall();
        mainMenu.SetActive(false);
    }


    #region EVENT LISTNERS

    public void OnLevelComplete()
    {
        gameComplete.SetActive(true);
    }

    public void OnGameOver()
    {
        gameOver.SetActive(true);
    }

    #endregion

    private void OnDisable()
    {
        GameManager.Instance.LevelCompleteEvent -= OnLevelComplete;
        GameManager.Instance.GameOverEvent -= OnGameOver;
    }

}
