using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private PlayerBehaviour _player;
    private CameraFollow _camFollow;

    private float delta;

    private void Start()
    {

        _player = GetComponent<PlayerBehaviour>();
        _player.Init();

        _camFollow = Camera.main.transform.parent.GetComponent<CameraFollow>();
        _camFollow.Init(_player.transform);
    }

    private void Update()
    {
        delta = Time.deltaTime;

        _player.Tick(delta);
        _camFollow.Tick(delta);
    }

}
