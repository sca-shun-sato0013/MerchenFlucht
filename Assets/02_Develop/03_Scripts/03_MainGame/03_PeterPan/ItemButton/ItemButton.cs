using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;

public class ItemButton : MonoBehaviour
{
    [SerializeField]
    PlayableDirector itemButtonTimeLine, returnItemButtonTimeLine;

    [SerializeField]
    GameObject itemBox = null;

    int count = 1;

    void Start() 
    {
        itemBox.SetActive(false);
       // UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnClick()
    {
        count++;

        if(count % 2 == 0)
        {
            itemBox.SetActive(true);
            returnItemButtonTimeLine.enabled = false;
            itemButtonTimeLine.enabled = true;
        }
        else
        {
            itemButtonTimeLine.enabled = false;
            returnItemButtonTimeLine.enabled = true;
        }
    }
}
    