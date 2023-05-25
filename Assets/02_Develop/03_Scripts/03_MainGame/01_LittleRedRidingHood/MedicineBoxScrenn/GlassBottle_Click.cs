using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;

public class GlassBottle_Click : MonoBehaviour, IUpdateManager
{
    [SerializeField]
    RayCastScript_Little rayCastScript_Little;

    [SerializeField]
    Image item3;
    
    void Start()
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;
    }

    public void OnClick()
    {
       Debug.Log("toote");
       rayCastScript_Little.ScenarioLoad_ItemGet(ScenarioSceneLittle.sleepingPills_Get,item3,"Assets/LoadingDatas/ScenarioDatas/LittleRedRidingHood/–ò•r.png");   
    }
}
    