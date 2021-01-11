using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraFollow : MonoBehaviour
{

    public float distance;
    public float height = 5.5f;
    public Transform camTarget;

    private void Update()
    {
        transform.position = camTarget.position + camTarget.forward * distance + Vector3.up * height;
    }

}
