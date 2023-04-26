using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;

public class CipherScreen_ReturnButton : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    PlayableDirector CipherScreenReDoor;

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
        CipherScreenReDoor.enabled = false;
        CipherScreenReDoor.enabled = true;
    }
}
    