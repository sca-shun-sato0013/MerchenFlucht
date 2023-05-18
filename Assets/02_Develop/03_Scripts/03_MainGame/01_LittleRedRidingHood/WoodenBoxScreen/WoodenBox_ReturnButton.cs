using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;
using UnityEngine.Playables;

public class WoodenBox_ReturnButton : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    PlayableDirector woodenBoxScreen_Close;

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
        woodenBoxScreen_Close.enabled = false;
        woodenBoxScreen_Close.enabled = true;
    }
}
    