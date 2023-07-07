using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.Profiling;

public class ShaftRotation_Little : MonoBehaviour, IUpdateManager
{
    [SerializeField]
    GameObject mobile2DMainCamera;

    [SerializeField] float angleLeft;
    [SerializeField] float angleRight;
    [SerializeField] float angleUp;
    [SerializeField] Vector3 axisY = Vector3.up;
    [SerializeField] Vector3 axis;
    [SerializeField] float step = 5;
    [SerializeField]
    GameObject upArrow, downArrow, leftArrow, rightArrow;

    [SerializeField]
    GameObject mainCamera;

    [SerializeField,Header("BoxColider")]
    BoxCollider frontDoor_BoxCol,wolf_BoxCol;

    CustomSampler cs = CustomSampler.Create("Debug");
    int count = 0;

    bool flag = true;

    bool justOnce = true;

    bool rayCastON = false;

    Quaternion targetRot;

    WaitForSeconds wait;

    public int Count => count;

    public bool RayCastON => rayCastON;

    // Start is called before the first frame update
    void Start()
    {
        targetRot = transform.rotation;
        wait = new WaitForSeconds(0.05f);
        UpdateManager.Instance.Bind(this, FrameControl.ON);
        downArrow.SetActive(false);

    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        if (count == -4 || count == 4) count = 0;
        cs.Begin();
        Debug.Log(count);
        cs.End();
        mobile2DMainCamera.transform.rotation = Quaternion.RotateTowards(mobile2DMainCamera.transform.rotation, targetRot, step);

        if (mainCamera.transform.position.y >= 2.0f)
        {
            rayCastON = false;
        }
        else
        {
            rayCastON = targetRot == mobile2DMainCamera.transform.rotation;
        }

        if(count == 0)
        {
            frontDoor_BoxCol.enabled = true;
        }
        else
        {
            frontDoor_BoxCol.enabled = false;
        }

        if(count == -2 || count == 2)
        {
            wolf_BoxCol.enabled = true;
        }
        else
        {
            wolf_BoxCol.enabled = false;
        }
    }

    public void OnClickLeft()
    {
        if (targetRot == mobile2DMainCamera.transform.rotation)
        {
            flag = true;
            Debug.Log(mobile2DMainCamera.transform.eulerAngles.y);
            count--;
            Debug.Log(count);

            targetRot = Quaternion.AngleAxis(angleLeft, axisY) * mobile2DMainCamera.transform.rotation;

        }
    }

    public void OnClickRight()
    {
        if (targetRot == mobile2DMainCamera.transform.rotation)
        {
            flag = true;
            count++;
            Debug.Log(count);


            targetRot = Quaternion.AngleAxis(angleRight, axisY) * mobile2DMainCamera.transform.rotation;
        }
    }

    public void OnClickUp()
    {
        downArrow.SetActive(true);
        upArrow.SetActive(false);
    }

    public void OnClickDown()
    {
        upArrow.SetActive(true);
        downArrow.SetActive(false);
    }
}
