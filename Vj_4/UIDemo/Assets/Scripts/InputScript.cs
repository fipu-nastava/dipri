using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{

    public void ValueChanged(string newValue)
    {
        Debug.Log("Change: " + newValue);
    }
    public void EditFinish(string finalValue)
    {
        Debug.Log("Final: " + finalValue);
    }
}
