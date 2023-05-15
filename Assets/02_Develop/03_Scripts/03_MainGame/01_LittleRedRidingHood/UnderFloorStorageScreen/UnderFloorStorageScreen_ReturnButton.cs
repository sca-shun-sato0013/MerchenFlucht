using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;

public class UnderFloorStorageScreen_ReturnButton : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    PlayableDirector underFloorStorageScreen_close;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;
    }

    public void ReturnButton()
    {
        underFloorStorageScreen_close.enabled = false;
        underFloorStorageScreen_close.enabled = true;
    }
}
    