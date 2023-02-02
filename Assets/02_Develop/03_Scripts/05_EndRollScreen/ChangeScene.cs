using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using DesignPattern;

  public class ChangeScene : MonoBehaviour,IUpdateManager
  {
    
      bool bol = true;

      void Start() 
      {
         UpdateManager.Instance.Bind(this,FrameControl.ON);
      }

    public void OnUpdate(double deltaTime)
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began && bol)
            {
                bol = false;
                Singleton<SceneManager>.Instance.SceneLoadingAsync("title");
                //sLib.SceneLoadingAsync("title");
            }
        }
    }      
  }
    