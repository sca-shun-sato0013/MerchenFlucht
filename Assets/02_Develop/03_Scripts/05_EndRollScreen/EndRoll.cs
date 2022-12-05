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

    //�X�N���[���̈�
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
        //MoveTowads������W���炠����W�ɂǂ̂��炢�̑����ňړ�����
        rectTransform.position += new Vector3(0f, 0.1f, 0);
    }
}





    