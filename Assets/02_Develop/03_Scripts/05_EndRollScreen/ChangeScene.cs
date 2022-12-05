using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib;
using NUnityGameLib.NDesignPattern.NSingleton;
using NUnityGameLib.NGameManager.NSceneManager;
  public class ChangeScene : UnityGameLib,IUnityGameLib
  {
    
    bool bol = true;
      void Start() 
      {
          
      }

      public override void UpdateLib()
      {
        if(Input.GetMouseButtonDown(0) && bol)
        {
            bol = false;
            Singleton<SceneManagerLib>.Instance.SceneLoadingAsync("title");
            //sLib.SceneLoadingAsync("title");
        }
      }
  }
    