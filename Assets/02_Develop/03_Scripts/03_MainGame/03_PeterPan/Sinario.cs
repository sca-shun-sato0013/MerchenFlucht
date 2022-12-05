using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib.NGameManager.NScenarioManager;

public class Sinario : ScenarioManager,IScenarioManager
{
    void Start()
    {

        ReLoadGoogleSheet();
    }

    public override void UpdateLib()
    {
        TextController();
  
    }
}
