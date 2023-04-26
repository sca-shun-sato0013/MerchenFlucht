using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Rendering;
using UnityEngine.Playables;

public class MainScreen : MonoBehaviour,IUpdateManager
{
    [SerializeField, Header("フェードアウトの時間")]
    float timer;

    [SerializeField]
    ShaftRotation_Hansel direction;
    [SerializeField]
    PlayableDirector kitchenMove;

    [SerializeField]
    Fade fade;

    [SerializeField]
    GameObject fadeCanvas;

    [SerializeField]
    GameObject kitchenMoveButton, kitchenReMoveButton;

    [SerializeField]
    GameObject scenarioManager;

    [SerializeField]
    Volume volume;

    private void OnEnable()
    {
        volume.enabled = true;
        fade.FadeOut(timer);
    }

    
    void Start() 
    {        
        UpdateManager.Instance.Bind(this,FrameControl.ON);  
    }

    public void OnUpdate(double deltaTime)
    {
/*        if(kitchenMoveButton.activeSelf == false)
        {
            if(direction.Count == -1 || direction.Count == 3)
            {
                kitchenReMoveButton.SetActive(true);
            }
            else
            {
                kitchenReMoveButton.SetActive(false);
            }

        }*/
    }
}
    