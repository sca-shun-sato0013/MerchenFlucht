using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Rendering;
using UnityEngine.Playables;

public class MainScreen_Little : MonoBehaviour, IUpdateManager
{
    [SerializeField, Header("フェードアウトの時間")]
    float timer;

    [SerializeField]
    Fade fade;

    [SerializeField]
    Volume volume;

    private void OnEnable()
    {
        volume.enabled = true;
        fade.FadeOut(timer);
    }


    void Start()
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {

    }
}
