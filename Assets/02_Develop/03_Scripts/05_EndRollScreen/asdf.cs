using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib.NGameManager.NScenarioManager;
public class asdf : ScenarioManager
{
    public override void UpdateLib()
    {
      if(Input.GetKeyDown(KeyCode.B))
        {
            ReLoadGoogleSheet();
        }
    }
}
