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

    private DOTweenAnimation _animControl;
    private Transform _myTranform;
    private Transform _ballHolder;
    private Transform _childBall;

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
        if (!canRun)
            return;

        _animControl.DOPlay();
        _myTranform.Translate(transform.forward * moveSpeed * delta);
    }

    private void ChildBallMovement()
    {
        Vector3 constPosition = new Vector3(_ballHolder.localPosition.x, 0f, 0f);
        constPosition.x = Mathf.Clamp(constPosition.x , -horizontalConst , horizontalConst);
        _ballHolder.localPosition = constPosition;
    }

    private void DetectionLogic()
    {
        if (!canRun)
            return;

        Ray ray = new Ray(_childBall.position, _childBall.transform.up);
        Debug.DrawRay(_childBall.position, _childBall.transform.up * detectionDist, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit, detectionDist, interactionLayers))
        {
            GameObject collided = hit.collider.gameObject;

            if (collided.TryGetComponent<IInteractable>(out IInteractable Iobj))
            {
                GameObject splashMark = Instantiate(splashPrefab, hit.point, Quaternion.identity);
                splashMark.transform.position = hit.point;

                Iobj.Interaction();
            }
            else if (collided.CompareTag("GameOverObj"))
            {
                GameManager.Instance.GameOverEventCall();
            }
        }

    }

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
        canRun = false;
    }

    private void OnDisable()
    {
        GameManager.Instance.GameOverEvent -= OnGameFail;
        GameManager.Instance.GameStartEvent -= OnGameStart;
        GameManager.Instance.LevelCompleteEvent -= OnLevelComplete;
    }

}
