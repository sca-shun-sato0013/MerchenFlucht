using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;

public class ShaftRotation : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    GameObject mobile2DMainCamera;

    [SerializeField] float angleLeft;
    [SerializeField] float angleRight;
    [SerializeField] float angleUp;
    [SerializeField] Vector3 axisY = Vector3.up;
    [SerializeField] Vector3 axis;
    [SerializeField] float step = 5;

    int count = 0;
    Quaternion targetRot;

    WaitForSeconds wait;
    // Start is called before the first frame update
    void Start()
    {
        wait = new WaitForSeconds(0.05f);
        UpdateManager.Instance.Bind(this, FrameControl.ON);
        //targetRot = Quaternion.AngleAxis(angle, axis) * mobile2DMainCamera.transform.rotation;
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        if (count == 8 || count == -8) count = 0;

        Debug.Log(count);
        mobile2DMainCamera.transform.rotation = Quaternion.RotateTowards(mobile2DMainCamera.transform.rotation, targetRot, step);
    }

    public void OnClickLeft()
    {
        Debug.Log(mobile2DMainCamera.transform.eulerAngles.y);
        count--;

           targetRot = Quaternion.AngleAxis(angleLeft, axisY) * mobile2DMainCamera.transform.rotation;
        StartCoroutine(Wait());
    }

    public void OnClickRight()
    {
        count++;
           targetRot = Quaternion.AngleAxis(angleRight, axisY) * mobile2DMainCamera.transform.rotation;
        StartCoroutine(Wait());
    }

    public void OnClickUp()
    {
        if (count == 0)
        {
            axis.x = -1f;
            axis.y = 0f;
            axis.z = 0f;
        }

        if (count == -1 || count == 7)
        {
            axis.x = -1f;
            axis.y = 0f;
            axis.z = -1f;
        }

        if (count == -2 || count == 6)
        {
            axis.x = 0f;
            axis.y = 0f;
            axis.z = -1f;
        }

        if (count == -3 || count == 5)
        {
            axis.x = 1f;
            axis.y = 0f;
            axis.z = -1f;
        }

        if (count == -4 || count == 4)
        {
            axis.x = 1f;
            axis.y = 0f;
            axis.z = 0f;
        }

        if (count == -5 || count == 3)
        {
            axis.x = 1f;
            axis.y = 0f;
            axis.z = 1f;
        }

        if (count == -6 || count == 2)
        {
            axis.x = 0f;
            axis.y = 0f;
            axis.z = 1f;
        }

        if (count == -7 || count == 1)
        {
            axis.x = -1f;
            axis.y = 0f;
            axis.z = 1f;
        }
        targetRot = Quaternion.AngleAxis(angleUp, axis) * mobile2DMainCamera.transform.rotation;
       
    }

    public void OnClickDown()
    {
        if (count == 0)
        {
            axis.x = 1f;
            axis.y = 0f;
            axis.z = 0f;
        }

        if (count == -1 || count == 7)
        {
            axis.x = 1f;
            axis.y = 0f;
            axis.z = 1f;
        }

        if (count == -2 || count == 6)
        {
            axis.x = 0f;
            axis.y = 0f;
            axis.z = 1f;
        }

        if (count == -3 || count == 5)
        {
            axis.x = -1f;
            axis.y = 0f;
            axis.z = 1f;
        }

        if (count == -4 || count == 4)
        {
            axis.x = -1f;
            axis.y = 0f;
            axis.z = 0f;
        }

        if (count == -5 || count == 3)
        {
            axis.x = -1f;
            axis.y = 0f;
            axis.z = -1f;
        }

        if (count == -6 || count == 2)
        {
            axis.x = 0f;
            axis.y = 0f;
            axis.z = -1f;
        }

        if (count == -7 || count == 1)
        {
            axis.x = 1f;
            axis.y = 0f;
            axis.z = -1f;
        }
        targetRot = Quaternion.AngleAxis(angleUp, axis) * mobile2DMainCamera.transform.rotation;

    }
    IEnumerator Wait()
    {
        yield return wait;

        if (count == 0)
        {
            Vector3 pos;
            pos.x = 0f;
            pos.y = 180f;
            pos.z = 0f;
            mobile2DMainCamera.transform.eulerAngles = pos;
        }

        if (count == -1 || count == 7)
        {
            Vector3 pos;
            pos.x = 0f;
            pos.y = 135f;
            pos.z = 0f;
            mobile2DMainCamera.transform.eulerAngles = pos; 
        }

        if (count == -2 || count == 6)
        {
            Vector3 pos;
            pos.x = 0f;
            pos.y = 90f;
            pos.z = 0f;
            mobile2DMainCamera.transform.eulerAngles = pos;
        }

        if (count == -3 || count == 5)
        {
            Vector3 pos;
            pos.x = 0f;
            pos.y = 45f;
            pos.z = 0f;
            mobile2DMainCamera.transform.eulerAngles = pos;
        }

        if (count == -4 || count == 4)
        {
            Vector3 pos;
            pos.x = 0f;
            pos.y = 0f;
            pos.z = 0f;
            mobile2DMainCamera.transform.eulerAngles = pos;
        }

        if (count == -5 || count == 3)
        {
            Vector3 pos;
            pos.x = 0f;
            pos.y = 315f;
            pos.z = 0f;
            mobile2DMainCamera.transform.eulerAngles = pos;
        }

        if (count == -6 || count == 2)
        {
            Vector3 pos;
            pos.x = 0f;
            pos.y = 270f;
            pos.z = 0f;
            mobile2DMainCamera.transform.eulerAngles = pos;
        }

        if (count == -7 || count == 1)
        {
            Vector3 pos;
            pos.x = 0f;
            pos.y = 225f;
            pos.z = 0f;
            mobile2DMainCamera.transform.eulerAngles = pos;
        }

    }
}
    