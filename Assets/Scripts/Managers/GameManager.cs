using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    #region FIELDS DECLERATION

    public GameData gameData;

    private float delta;

    private LevelManager _levelManager;
    private UIManager _uiManager;

    public static GameManager Instance;

    #endregion

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _levelManager = LevelManager.Instance;
        _levelManager.Init(gameData);

        _uiManager = UIManager.Instance;
        _uiManager.Init(gameData);
    }

    void Update()
    {
        delta = Time.deltaTime;

        _levelManager.Tick(delta);
        _uiManager.Tick(delta);
    }


    #region ACTION & EVENTS DECLERATION

    public event Action LevelCompleteEvent;
    public void LevelCompleteEventCall()
    {
        LevelCompleteEvent?.Invoke();
    }

    public event Action GameOverEvent;
    public void GameOverEventCall()
    {
        GameOverEvent?.Invoke();
    }

    public event Action GameStartEvent;
    public void GameStartEventCall()
    {
        GameStartEvent?.Invoke();
    }

    #endregion

}
