﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public class FadeCheck : MonoBehaviour
{
    private enum SwitchFadeType
    {
        Normal,
        Scenario,
    }

    [SerializeField] SwitchFadeType switchFadeType;
    [SerializeField] GameObject obj = null;
    [SerializeField] Fade fade = null;
    [SerializeField] SetDisplayImage setDisplayImage;

    WaitUntil w;
    //[SerializeField] FadeImage fadeImage = null;
    // Start is called before the first frame update

    void Start()
    {
        w = new WaitUntil(()=> setDisplayImage.FadeCheck);

        switch (switchFadeType)
        {
            case SwitchFadeType.Normal:
                
                    obj.SetActive(true);
                    Invoke("wait", 0.1f);
                    fade.FadeIn(0, () => fade.FadeOut(2));
                
                break;


            case SwitchFadeType.Scenario: 
                    
                    StartCoroutine(FadeIn());

                break;

        }
    }

    // Update is called once per frame

    IEnumerator FadeIn()
    {
        obj.SetActive(true);
        yield return w;
        setDisplayImage.FadeCheck = false;
        Invoke("wait", 0.1f);
        fade.FadeIn(0, () => fade.FadeOut(2));
    }

    void wait()
    {
        obj.SetActive(false);
    }
}
