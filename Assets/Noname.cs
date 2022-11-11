using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib;
using NUnityGameLib.NPlayerController.NControllerPC;

  public class Noname : ControllerPC,IUnityGameLib,IControllerPC
  {
      void Start() 
      {
            Debug.Log("UnityGameStart");
      }

      public override void UpdateLib()
      {
      }
  }
    