using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public int preInstCount = 10;

    public GameObject normalPlatforms;
    public GameObject gameCompletePlatform;

    private List<GameObject> platformList = new List<GameObject>();

    public void Init()
    {
        for (int i = 0; i < preInstCount; i++)
        {
            platformList.Add(CreatePlatform());
        }
    }

    private GameObject CreatePlatform()
    {
        GameObject obj = Instantiate(normalPlatforms, transform.position, Quaternion.identity, transform);
        obj.SetActive(false);
        return obj;
    }

    public GameObject GetPlatform()
    {
        foreach (GameObject item in platformList)
        {
            if (!item.activeInHierarchy)
            {
                return item;
            }
        }

        GameObject obj = CreatePlatform();
        platformList.Add(obj);
        return obj;
    }

}
