using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;

public class ChangeDesign : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    Image designs1,designs2,designs3;

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

        DesignState(count,designs1,designs2,designs3);
    }

    private void DesignState(int count,Image d1,Image d2,Image d3)
    {
        if (count == 0)
        {
            d1.enabled = true;
            d2.enabled = false;
            d3.enabled = false;
        }

        if (count == 1)
        {
            d1.enabled = false;
            d2.enabled = true;
            d3.enabled = false;
        }

        if (count == 2)
        {
            d1.enabled = false;
            d2.enabled = false;
            d3.enabled = true;
        }
    }

    public void OnClickDownChangeDesign()
    {
        count--;

        if (count < 0) count = 2;

        DesignState(count, designs1, designs2, designs3);
    }
}
    