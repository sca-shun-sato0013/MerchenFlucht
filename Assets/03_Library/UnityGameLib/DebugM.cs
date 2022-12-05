using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib;
using NUnityGameLib.NDesignPattern.NSingleton;
using NUnityGameLib.NGameManager.NDebugManager;

  public class DebugM : DebugManager,IUnityGameLib,IDebugManager,ISingleton
  {
    [SerializeField, Header("基本的なデータをdebugするclass数")] int classNumber;
    [SerializeField,Header("UnityGameLib継承クラスのみ")] UnityGameLib[] lib;
    
      void Start() 
      {
       
      }

      public override void UpdateLib()
      {
        for(int i = 0; i < classNumber; ++i)
        {
            GeneralDebugger(lib[i]);
        }
      }

  }
    