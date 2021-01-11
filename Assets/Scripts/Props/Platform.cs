using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour,IItnteractable
{

    public float dampTime = 1f;
    public float animDelay = 1f;
    public AnimationCurve animCurve;

    public void PerformInteraction()
    {
        //StartCoroutine(DisappearAnimation(animDelay));
    }


    IEnumerator DisappearAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);

        while (true)
        {
            yield return null;
        }
    }

}
