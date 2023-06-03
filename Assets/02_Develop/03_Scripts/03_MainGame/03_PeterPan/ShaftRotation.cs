using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;

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
    [SerializeField] 
    GameObject upArrow,downArrow,leftArrow,rightArrow;
    [SerializeField]
    GameObject shadowHumanChair;
    [SerializeField]
    RayCastScript rayCastScript;
    [SerializeField] 
    PlayableDirector downArrowTimeLine, down2ArrowTimeLine, upArrowTimeLine, up2ArrowTimeLine;

    [SerializeField]
    BoxCollider painting;

    int count = 0;
    int count2 = 1;

    bool flag = true;
    bool flagTimeLine = false;
    Quaternion targetRot;

    WaitForSeconds wait;
    // Start is called before the first frame update
    void Start()
    {
        targetRot = transform.rotation;
        wait = new WaitForSeconds(0.05f);
        UpdateManager.Instance.Bind(this, FrameControl.ON);
        //targetRot = Quaternion.AngleAxis(angle, axis) * mobile2DMainCamera.transform.rotation;
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        if (count == 8 || count == -8) count = 0;

        if(count == 0 && count2 == 1)
        {
            painting.enabled = true;
        }
        else
        {
            painting.enabled = false;
        }

        if(count == 0 && count2 == -1 && rayCastScript.ExamineTheChair)
        {
            shadowHumanChair.SetActive(true);
        }
        else
        {
            shadowHumanChair.SetActive(false);
        }


        Debug.Log(count);
        Debug.Log(count2);

        if (flag) mobile2DMainCamera.transform.rotation = Quaternion.RotateTowards(mobile2DMainCamera.transform.rotation, targetRot, step);

        if(count == 0 && flag)
        {
            downArrow.SetActive(true);
        }
        else if(count != 0 && flag)
        {
            upArrow.SetActive(false);
            downArrow.SetActive(false);
        }
    }

    public void OnClickLeft()
    {
        if(Mathf.Approximately(Mathf.Abs(targetRot.y), Mathf.Abs(mobile2DMainCamera.transform.rotation.y)))
        {
            flag = true;

            count--;

            targetRot = Quaternion.AngleAxis(angleLeft, axisY) * mobile2DMainCamera.transform.rotation;
        }
    }

    public void OnClickRight()
    {
        if (Mathf.Approximately(Mathf.Abs(targetRot.y), Mathf.Abs(mobile2DMainCamera.transform.rotation.y)))
        {
            flag = true;
            count++;
            targetRot = Quaternion.AngleAxis(angleRight, axisY) * mobile2DMainCamera.transform.rotation;
        }
    }

    public void OnClickUp()
    {


        count2++;


        if (count2 == 0)
        {
            upArrow.SetActive(true);
            downArrow.SetActive(false);
            leftArrow.SetActive(false);
            rightArrow.SetActive(false);
            flag = false;
            
            downArrowTimeLine.enabled = false;
            down2ArrowTimeLine.enabled = false;
            upArrowTimeLine.enabled = false;
            up2ArrowTimeLine.enabled = true;
        }
        
        if(count2 == 1)
        {
            upArrow.SetActive(false);
            downArrow.SetActive(true);
            leftArrow.SetActive(true);
            rightArrow.SetActive(true);
            flag = false;
            downArrowTimeLine.enabled = false;
            down2ArrowTimeLine.enabled = false;
            up2ArrowTimeLine.enabled = false;
            upArrowTimeLine.enabled = true;
        }

    }

    public void OnClickDown()
    {

        count2--;

        if (count2 == 0)
        {
            upArrow.SetActive(true);
            downArrow.SetActive(true);
            leftArrow.SetActive(false);
            rightArrow.SetActive(false);

            flag = false;
            upArrowTimeLine.enabled = false;
            up2ArrowTimeLine.enabled = false;
            down2ArrowTimeLine.enabled = false;
            downArrowTimeLine.enabled = true;
        }

        if (count2 == -1)
        {
            flagTimeLine = true;
            upArrow.SetActive(true);
            downArrow.SetActive(false);
            leftArrow.SetActive(false);
            rightArrow.SetActive(false);

            flag = false;
            upArrowTimeLine.enabled = false;
            up2ArrowTimeLine.enabled = false;
            downArrowTimeLine.enabled = false;
            down2ArrowTimeLine.enabled = true;
        }

    }
}
    