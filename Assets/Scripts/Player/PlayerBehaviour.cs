using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBehaviour : MonoBehaviour
{

    #region FIELDS DECLERATION

    public GameObject splashPrefab;

    [Header("== PROERPTIES ==")]
    public float moveSpeed = 5f;
    public float horizontalConst;
    public float detectionDist = 2f;
    public LayerMask interactionLayers;

    [Header("== STATE ==")]
    public bool canRun = false;
    public bool gameComplete = false;

    private DOTweenAnimation _animControl;
    private Transform _myTranform;
    private Transform _ballHolder;
    private Transform _childBall;
    private bool _splashBuffer;

    #endregion

    private void OnEnable()
    {
        GameManager.Instance.GameOverEvent += OnGameFail;
        GameManager.Instance.GameStartEvent += OnGameStart;
        GameManager.Instance.LevelCompleteEvent += OnLevelComplete;
    }

    public void Init()
    {
        _ballHolder = transform.GetChild(0);
        _childBall = _ballHolder.GetChild(0);
        _animControl = _childBall.GetComponent<DOTweenAnimation>();
        _myTranform = GetComponent<Transform>();
    }

    public void Tick(float delta)
    {
        ForwardMovement(delta);
        ChildBallMovement();
        DetectionLogic();
    }

    private void ForwardMovement(float delta)
    {
        if (!canRun && !gameComplete)
        {
            _animControl.DOPause();
        }
        else
        {
            _animControl.DOPlay();
        }
        
        if (canRun)
        {
            _myTranform.Translate(transform.forward * moveSpeed * delta);
        }
    }

    private void ChildBallMovement()
    {
        Vector3 constPosition = new Vector3(_ballHolder.localPosition.x, 0f, 0f);
        constPosition.x = Mathf.Clamp(constPosition.x , -horizontalConst , horizontalConst);
        _ballHolder.localPosition = constPosition;
    }

    /// <summary>
    /// Surface detection logic
    /// </summary>
    private void DetectionLogic()
    {
        if (!canRun)
            return;

        Debug.DrawRay(_childBall.position, -_childBall.transform.up * detectionDist, Color.red);

        if (Physics.Raycast(_childBall.position, -_childBall.transform.up, out RaycastHit hit, detectionDist, interactionLayers))
        {
            //Debug.Log("GameObject " + hit.collider.gameObject.name);
            GameObject collidedObject = hit.collider.gameObject;

            if (collidedObject.TryGetComponent<IInteractable>(out IInteractable Iobj))
            {
                if (!_splashBuffer)
                {
                    _splashBuffer = true;
                    GameObject splashMark = Instantiate(splashPrefab, hit.point + (Vector3.up * 0.01f), 
                                                        splashPrefab.transform.rotation, collidedObject.transform);
                }

                Iobj.Interaction();
            }
            else if (collidedObject.CompareTag("GameOverObj"))
            {
                GameManager.Instance.GameOverEventCall();
            }
        }
        else
        {
            _splashBuffer = false;
        }

    }

    #region CALLBACKS RECEIVERS

    private void OnGameStart()
    {
        canRun = true;
    }

    private void OnGameFail()
    {
        canRun = false;
    }

    private void OnLevelComplete()
    {
        gameComplete = true;
        canRun = false;
    }

    #endregion

    private void OnDisable()
    {
        GameManager.Instance.GameOverEvent -= OnGameFail;
        GameManager.Instance.GameStartEvent -= OnGameStart;
        GameManager.Instance.LevelCompleteEvent -= OnLevelComplete;
    }

}
