using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;

public class Change : MonoBehaviour,IUpdateManager
{
    bool flag = true;
    bool input = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateManager.Instance.Bind(this,FrameControl.ON);   
    }

    // Update is called once per frame
    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        input = Input.GetMouseButtonDown(0) || MobileInput.InputState(TouchPhase.Began);
        
        if (input && flag)
        {
            Debug.Log(input);
            flag = false;
            SceneManager.Instance.SceneLoadingAsync("StageSelectScene");
        }
    }
}
