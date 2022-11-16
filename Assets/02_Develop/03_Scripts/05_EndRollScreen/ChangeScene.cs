using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib;
using NUnityGameLib.NGameManager.NSceneManager;
  public class ChangeScene : UnityGameLib,IUnityGameLib
  {
    [SerializeField] SceneManagerLib sLib;
      void Start() 
      {
          
      }

      public override void UpdateLib()
      {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sLib.SceneLodingAsync("title");
        }
      }
  }
    