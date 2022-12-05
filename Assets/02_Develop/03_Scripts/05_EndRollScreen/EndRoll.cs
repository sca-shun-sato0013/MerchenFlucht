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

    //スクロールの為
    [SerializeField] RectTransform rectTransform;

    [SerializeField] GameObject scroll;
    [SerializeField] float speed;
    [SerializeField] float height;
    [SerializeField] Vector3 target;

    [SerializeField] SoundManager soundManager;
      void Start() 
      { 
        ImageLoadingAsync(img, str);
      }


    public override void UpdateLib()
    {
        //MoveTowadsある座標からある座標にどのくらいの速さで移動する
        rectTransform.position += new Vector3(0f, 0.1f, 0);
    }
}





    