using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;

public class Timer_Hansel : MonoBehaviour, IUpdateManager
{
    [SerializeField, Header("§ŒÀŽžŠÔ")]
    float timeLimit;

    [SerializeField]
    Text timerText;

    float timer;
    [SerializeField]
    bool timerFlag = false;

    bool timeOut = false;

    public bool TimerFlag
    {
        get => timerFlag;
        set => timerFlag = value;
    }

    public bool TimeOut => timeOut;

    void Start()
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        if (!timeOut)
        {
            if (timerFlag)
            {
                timer += (float)deltaTime;
                float timeStack = timeLimit - timer;

                if (timeStack <= 0f) timeOut = true;
                timerText.text = StringComponent.AddString("Žc‚èŽžŠÔ‚Ü‚Å‚ ‚Æ ", timeStack.ToString("n1"), "•b");
            }
        }
    }
}