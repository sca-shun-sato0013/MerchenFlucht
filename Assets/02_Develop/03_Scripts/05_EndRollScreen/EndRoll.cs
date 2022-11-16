using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib;
using UnityEngine.UI;
  public class EndRoll : UnityGameLib,IUnityGameLib
  {
    [SerializeField] Image img;
    [SerializeField] string str;
      void Start() 
      {
        ImageLoadingAsync(img, str);
      }
  }





    