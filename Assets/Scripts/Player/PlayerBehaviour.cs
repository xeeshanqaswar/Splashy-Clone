using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    #region FIELDS DECLERATION

    [Header("== REFERNCES ==")]
    public GameData database;
    private Rigidbody myRigibody;

    #endregion


    private void Start()
    {
        myRigibody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IItnteractable interactable = collision.gameObject.GetComponent<IItnteractable>();
    }


}
