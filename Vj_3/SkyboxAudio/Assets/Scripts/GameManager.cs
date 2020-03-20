using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // This should also be a sigleton just like AudioManger


    void Start()
    {
        AudioManager.Instance.Play(SoundType.BackgroundTheme);
    }

}
