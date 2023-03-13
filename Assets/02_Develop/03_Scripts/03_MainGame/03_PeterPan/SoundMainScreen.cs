using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;

public class SoundMainScreen : MonoBehaviour,IUpdateManager
{
    [SerializeField] AudioSource audioSource;
    bool check = true;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        if (audioSource.volume == 0f) 
        {
            check = false;
            SoundManager.Instance.PlayBGM(0, true);
            SoundManager.Instance.FadeOut_BGM(1f);
        } 
    }
}
    