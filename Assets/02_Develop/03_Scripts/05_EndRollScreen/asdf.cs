using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib;
using NUnityGameLib.NGameManager.NScenarioManager;
using NUnityGameLib.NGameManager.NDebugManager;
using NUnityGameLib.NDesignPattern.NSingleton;
using NUnityGameLib.NDesignPattern.NServiceLocator;
public class asdf : ScenarioManager,IUnityGameLib
{
    
    void Start()
    {

        ReLoadGoogleSheet();
    }

    public override void UpdateLib()
    {
        TextController();
        Singleton<DebugManager>.Instance.Debugger("a");
        ServiceLocator<IDebugManager>.Instance.Debugger("b");
        //Transform str = ServiceLocator<asdf>.Instance.transform;
    }
}
