using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib;
using NUnityGameLib.NDesignPattern.NSingleton;
using NUnityGameLib.NGameManager.NDebugManager;

  public class DebugM : DebugManager,IUnityGameLib,IDebugManager,ISingleton
  {
    [SerializeField, Header("��{�I�ȃf�[�^��debug����class��")] int classNumber;
    [SerializeField,Header("UnityGameLib�p���N���X�̂�")] UnityGameLib[] lib;
    
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
    