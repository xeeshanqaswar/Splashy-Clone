using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBehaviour : MonoBehaviour
{

    #region FIELDS DECLERATION

    [Header("== PROERPTIES ==")]
    public float moveSpeed = 5f;
    public float horizontalConst;

    [Header("== STATE ==")]
    public bool canRun = false;

    private DOTweenAnimation _animControl;
    private Transform _myTranform;
    private Rigidbody _myRigibody;
    private Transform _childBall;

    #endregion

    public void Init()
    {
        _childBall = transform.GetChild(0);
        _animControl = _childBall.GetChild(0).GetComponent<DOTweenAnimation>();
        _myTranform = GetComponent<Transform>();
        _myRigibody = transform.GetComponent<Rigidbody>();
    }

    public void Tick(float delta)
    {
        ForwardMovement(delta);
        ChildBallMovement();
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
        Vector3 constPosition = new Vector3(_childBall.localPosition.x, 0f, 0f);
        constPosition.x = Mathf.Clamp(constPosition.x , -horizontalConst , horizontalConst);
        _childBall.localPosition = constPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.TryGetComponent<IInteractable>(out IInteractable IObj)
        Debug.Log(collision.gameObject.name);
    }


}
