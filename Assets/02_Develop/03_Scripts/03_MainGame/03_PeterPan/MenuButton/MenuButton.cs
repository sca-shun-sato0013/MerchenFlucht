using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    PlayableDirector menuButtonTimeLine,returnButtonTimeLine;

    [SerializeField]
    GameObject menuBackGround;

    public void Onlick()
    {
        returnButtonTimeLine.enabled = false;
        menuButtonTimeLine.enabled = true;
        menuBackGround.SetActive(true);
    }
}
    