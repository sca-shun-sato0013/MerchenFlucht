using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;
using UnityEngine.UI;

public class KitchenReMove : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    PlayableDirector kitchenReMove_TimeLIne;

    [SerializeField]
    KitchenMove kitchenMove;
    [SerializeField]
    Image kitchenReMoveButtonImage;

    bool exist = false;

    public bool Exist
    {
        get => exist;
        set => exist = value;
    }

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

    }

    public void ReMove()
    {
        exist = true;
        kitchenMove.Exist = false;
        kitchenReMove_TimeLIne.enabled = false;
        kitchenReMove_TimeLIne.enabled = true;
        //StartCoroutine(TimeLine_Stop());
        kitchenReMoveButtonImage.enabled = false;
    }
}
    