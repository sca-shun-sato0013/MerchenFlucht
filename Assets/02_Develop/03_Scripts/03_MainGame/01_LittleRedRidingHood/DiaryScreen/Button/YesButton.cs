using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;

public class YesButton : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    RayCastScript_Little rayCastScript_Little;

    bool diaryLoadCheck = false;

    public bool DiaryLoadCheck => diaryLoadCheck;

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
        diaryLoadCheck = true;
        rayCastScript_Little.ScenarioLoad(ScenarioSceneLittle.grandMatherDiary_Loading);
    }
}
    