using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;
using UnityEngine.UI;

public class KitchenMove : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    PlayableDirector kitchenMove_TimeLine;

    [SerializeField]
    KitchenReMove kitchenReMove;

    [SerializeField]
    Image kitchenMoveButtonImage;

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

    public void KitchenMoveButton()
    {
        exist = true;
        kitchenReMove.Exist = false;
        kitchenMove_TimeLine.enabled = false;
        kitchenMove_TimeLine.enabled = true;
       // StartCoroutine(TimeLine_Stop());
        kitchenMoveButtonImage.enabled = false;
    }

    IEnumerator TimeLine_Stop()
    {
        yield return new WaitForSeconds(1.2f);

        kitchenMove_TimeLine.enabled = false;
    }

}
    