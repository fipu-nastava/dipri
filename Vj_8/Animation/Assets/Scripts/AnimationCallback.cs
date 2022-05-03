using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCallback : MonoBehaviour
{
    void AnimationEvent(string ev)
    {
        Debug.Log(ev);
    }
    void PrintValue(float val)
    {
        Debug.Log(val);
    }
}
