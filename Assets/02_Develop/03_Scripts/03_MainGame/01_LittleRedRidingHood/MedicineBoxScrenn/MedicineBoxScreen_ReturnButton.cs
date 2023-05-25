using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;

public class MedicineBoxScreen_ReturnButton : MonoBehaviour,IUpdateManager
{
    
    [SerializeField]
    PlayableDirector medicineBoxScreen_Close;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;
    }

    public void OnClick_ReturnButton()
    {
        medicineBoxScreen_Close.enabled = false;
        medicineBoxScreen_Close.enabled = true;
    }
}
    