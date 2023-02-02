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

    //�X�N���[���̈�
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
        //MoveTowads������W���炠����W�ɂǂ̂��炢�̑����ňړ�����
        rectTransform.position += new Vector3(0f, 0.1f, 0);
    }
}





    