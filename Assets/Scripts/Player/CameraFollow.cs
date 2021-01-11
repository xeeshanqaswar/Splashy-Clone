using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraFollow : MonoBehaviour
{
    public float camSpeed;

    private Transform _player;

    public void Init(Transform player)
    {
        _player = player;
    }

    public void Tick( float delta )
    {
        Vector3 moveVector = new Vector3(0f, 0f, _player.position.z);
        transform.position = Vector3.Lerp(transform.position, moveVector, camSpeed * delta); ;
    }

}
