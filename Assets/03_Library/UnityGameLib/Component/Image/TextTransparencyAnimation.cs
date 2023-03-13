using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;

public class TextTransparencyAnimation : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    Text text;

    [SerializeField,Range(0f,0.25f),Header("•Ï‰»‚Ì‘¬‚³")]
    float speed;

    const float alphaColor = 1f;
    const float reAlphaColor = 0f;

    float count;
    float reCount;

    float timer;

    public float Speed => speed;

    private void OnEnable()
    {
        //UpdateManager.Instance.Bind(this, FrameControl.ON);
        reCount = 0;
        count = 0;
    }

    private void OnDisable()
    {
        //UpdateManager.Instance.UnBind(this, FrameControl.ON);
        reCount = 1f;
    }

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
        count = 0;
        reCount = 0;
    }

    public void OnUpdate(double deltaTime)
    {
        timer += (float)deltaTime;
        
        if (count > 1f)count = 1f;
        if(reCount < 0)reCount = 0f;


        if(count != alphaColor)
        {
            if(timer > speed)
            {
                //Invoke("AlphaCount",speed);
                AlphaCount();
                timer = 0f;
            }
        }

        if(reCount != reAlphaColor)
        {
            //Invoke("ReAlphaCount",speed);
            if (timer > speed)
            {
                //Invoke("AlphaCount",speed);
                ReAlphaCount();
                timer = 0f;
            }
        }
    }

    private void AlphaCount()
    {
        count += 0.03f;
        text.color = ColorChange.ColorChanes(text.color.r, text.color.g, text.color.b, count);
    }

    private void ReAlphaCount()
    {
        reCount -= 0.03f;
        text.color = ColorChange.ColorChanes(text.color.r, text.color.g, text.color.b, reCount);
    }
}