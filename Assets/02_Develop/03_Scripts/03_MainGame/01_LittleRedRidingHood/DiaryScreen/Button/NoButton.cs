using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;

public class NoButton : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    PlayableDirector diaryLoading_Close;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;
    }

    public void OnClick()
    {
        diaryLoading_Close.enabled = false;
        diaryLoading_Close.enabled = true;
    }
}
    