using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;


public class UnderFloorStorageScreen_Sucess : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    RayCastScript_Little rayCastScript_Little;

    [SerializeField]
    Text numberCount1,numberCount2,numberCount3,numberCount4;

    bool flag = true;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        if (!(numberCount1.text == "1")) return;
        if (!(numberCount2.text == "6")) return;
        if (!(numberCount3.text == "7")) return;
        if (!(numberCount4.text == "9")) return;

        if (flag)
        {
            flag = false;

            rayCastScript_Little.ScenarioLoad(ScenarioSceneLittle.underFloorStorage_Sucess);
        }
    }


}
    