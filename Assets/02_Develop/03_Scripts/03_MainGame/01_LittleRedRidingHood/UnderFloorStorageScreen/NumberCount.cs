using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;

public class NumberCount : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    Text numberCount;

    int count;

    public int Count => count;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;
    }

    public void OnClickCountUp()
    {
        count++;

        if(count >= 10) count = 0;

        numberCount.text = count.ToString();
    }

    public void OnClickCountDown()
    {
        count--;

        if(count < 0) count = 9;

        numberCount.text = count.ToString();
    }
}
    