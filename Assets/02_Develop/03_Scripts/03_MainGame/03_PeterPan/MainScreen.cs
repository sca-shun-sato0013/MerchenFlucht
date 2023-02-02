using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;

public class MainScreen : MonoBehaviour,IUpdateManager
{
    [SerializeField, Header("フェードアウトの時間")]
    float timer;

    [SerializeField]
    Fade fade;

    [SerializeField]
    GameObject fadeCanvas;

    [SerializeField]
    GameObject scenarioManager;


    private void OnEnable()
    {
        fade.FadeOut(timer);
    }
    
    void Start() 
    {
        
        UpdateManager.Instance.Bind(this,FrameControl.ON);  
    }

    public void OnUpdate(double deltaTime)
    {

    }
}
    