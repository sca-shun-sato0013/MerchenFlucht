using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;

public class ReturnButton : MonoBehaviour
{
    [SerializeField]
    PlayableDirector returnButtonTimeLine,menuButtonTimeLine;

    [SerializeField]
    GameObject menuBackGround;

    public void OnClick()
    {
        menuButtonTimeLine.enabled = false;
        returnButtonTimeLine.enabled = true;
        menuBackGround.SetActive(false);
    }
}
    