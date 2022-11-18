using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib;
using UnityEngine.UI;
using NUnityGameLib.NGameManager.NDebugManager;
using NUnityGameLib.NGameManager.NSoundManager;

  public class EndRoll : UnityGameLib,IUnityGameLib
  {
    [SerializeField] Image img;
    [SerializeField] string str;
    [SerializeField] SoundManager soundManager;
      void Start() 
      {
        ImageLoadingAsync(img, str);
      }

    
  }





    