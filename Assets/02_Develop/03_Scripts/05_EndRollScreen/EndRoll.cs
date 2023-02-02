using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonlyUsed;
using GameManager;
using UnityEngine.UI;


  public class EndRoll : MonoBehaviour,IUpdateManager
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
         UpdateManager.Instance.Bind(this, FrameControl.ON);
         ImageLoading.ImageLoadingAsync(img, str);
      }

    public void OnUpdate(double deltaTime)
    {
        //MoveTowadsある座標からある座標にどのくらいの速さで移動する
        rectTransform.position += new Vector3(0f, 0.1f, 0);
    }
}





    