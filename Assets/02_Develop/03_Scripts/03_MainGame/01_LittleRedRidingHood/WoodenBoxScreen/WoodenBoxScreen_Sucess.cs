using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;


public class WoodenBoxScreen_Sucess : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    Image design1,design2,design3;

    [SerializeField]
    Image item5;

    [SerializeField]
    RayCastScript_Little rayCastScript_Little;

    bool flag = true;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

     
        if(!(design1.enabled == true)) return;
        if (!(design2.enabled == true)) return;
        if (!(design3.enabled == true)) return;


        if(flag)
        {
            
            flag = false;
            rayCastScript_Little.ScenarioLoad_ItemGet(ScenarioSceneLittle.woodenBoxScreen_Sucess,item5, "Assets/LoadingDatas/ScenarioDatas/PeterPan/ŠG–{‚É‹²‚Ü‚Á‚Ä‚éŒ®.png");
        }
    }
}
    