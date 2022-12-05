using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnityGameLib;
using NUnityGameLib.NDesignPattern.NSingleton;
using NUnityGameLib.NGameManager.NSceneManager;

  public class SceneM : SceneManagerLib,IUnityGameLib,ISceneManager,ISingleton
  {
      void Start() 
      {
         
      }

      public override void UpdateLib()
      {
        this.SceneLog(this);
      }
  }
    