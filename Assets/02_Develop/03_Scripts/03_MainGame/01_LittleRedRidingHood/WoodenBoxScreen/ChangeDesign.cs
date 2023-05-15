using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;

struct Designs
{
   public Image design1;
   public Image design2;
   public Image design3;
}

public class ChangeDesign : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    Designs designs;

    int count = 0;

    

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;
    }

    public void OnClickUpChangeDesign()
    {
        count++;

        if(count == 3) count = 0;

        DesignState(count,designs);
    }

    private void DesignState(int count,Designs d)
    {
        if (count == 0)
        {
            d.design1.enabled = true;
            d.design2.enabled = false;
            d.design3.enabled = false;
        }

        if (count == 1)
        {
            d.design1.enabled = false;
            d.design2.enabled = true;
            d.design3.enabled = false;
        }

        if (count == 2)
        {
            d.design1.enabled = false;
            d.design2.enabled = false;
            d.design3.enabled = true;
        }
    }
    public void OnClickDownChangeDesign()
    {
        count--;

        if (count < 0) count = 2;

        DesignState(count, designs);
    }
}
    