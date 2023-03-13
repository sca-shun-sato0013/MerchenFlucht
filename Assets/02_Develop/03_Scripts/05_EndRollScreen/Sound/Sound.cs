using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;

public class Sound : MonoBehaviour,IUpdateManager
{
    

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);

        SoundManager.Instance.PlayBGM(0,true);
        SoundManager.Instance.FadeOut_BGM(1);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

    }
}
    