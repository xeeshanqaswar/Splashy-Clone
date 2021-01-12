using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Platform : MonoBehaviour, IInteractable
{
    public Type platformType;

    private Transform parentObj;

    private void OnEnable()
    {
        parentObj = transform.parent;
    }

    public void Interaction()
    {
        if (platformType == Type.LevelComplete)
        {
            GameManager.Instance.LevelCompleteEventCall();
        }
        else
        {
            Invoke("Animate", 1f);
        }
    }

    private void Animate()
    {
        parentObj.gameObject.SetActive(true);
    }

    public enum Type
    {
        NormalPlatform, LevelComplete
    }
}
