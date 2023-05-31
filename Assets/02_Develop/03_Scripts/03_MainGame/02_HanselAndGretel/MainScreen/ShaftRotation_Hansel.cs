using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ShaftRotation_Hansel : MonoBehaviour, IUpdateManager
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

    [SerializeField]
    Image kitchenMoveButton, kitchenReMoveButton;

    [SerializeField]
    BoxCollider doorToKitchen;
    [SerializeField]
    PlayableDirector downArrowTimeLine, down2ArrowTimeLine, upArrowTimeLine, up2ArrowTimeLine;

    [SerializeField, Header("シャンデリアのカメラ移動")]
    PlayableDirector chandelier,reChandelier;
    [SerializeField]
    PlayableDirector kitchenMove, kitchenReMove;

    [SerializeField]
    KitchenMove kitchen;

    [SerializeField]
    KitchenReMove kitchenRe;

    int count = 0;

    bool flag = true;

    bool justOnce = true;

    bool rayCastON = false;

    Quaternion targetRot;

    public int Count => count;

    public bool RayCastON => rayCastON;

    // Start is called before the first frame update
    void Start()
    {
        targetRot = transform.rotation;
        
        UpdateManager.Instance.Bind(this, FrameControl.ON);
        downArrow.SetActive(false);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        if (count == -4 || count == 4) count = 0;
        
        mobile2DMainCamera.transform.rotation = Quaternion.RotateTowards(mobile2DMainCamera.transform.rotation, targetRot, step);        

        if (count == 1 || count == -3 )
        {
            upArrow.SetActive(true);
        }
        else
        {
            upArrow.SetActive(false);
        }

        if (mainCamera.transform.position.y >= 2.0f)
        {
            rayCastON = false;
        }
        else
        {
            rayCastON = targetRot == mobile2DMainCamera.transform.rotation;
        }

        if (!(mobile2DMainCamera.transform.position.x > -1f))
        {
            upArrow.SetActive(false);
        }

        if(mobile2DMainCamera.transform.position.y > 2f)
        {
            justOnce = true;
            kitchenMoveButton.enabled = false;
        }
        else if(justOnce)
        {
            justOnce = false;
            kitchenMoveButton.enabled = true;
        }
    }

    public void OnClickLeft()
    {
        if (Mathf.Approximately(Mathf.Abs(targetRot.y), Mathf.Abs(mobile2DMainCamera.transform.rotation.y)))
        {
            flag = true;
           
            count--;
           

            if(kitchenRe.Exist == true)
            {
                if (count == 1 || count == -3)
                {
                    kitchenMoveButton.enabled = true;
                }
                else
                {
                    kitchenMoveButton.enabled = false;
                }
            }
            
            if(kitchen.Exist == true)
            {
                if (count == -1 || count == 3)
                {
                    kitchenReMoveButton.enabled = true;
                }
                else
                {
                    kitchenReMoveButton.enabled = false;
                }
            }            

            targetRot = Quaternion.AngleAxis(angleLeft, axisY) * mobile2DMainCamera.transform.rotation;
        }
    }

    public void OnClickRight()
    {
        
        if (Mathf.Approximately(Mathf.Abs(targetRot.y), Mathf.Abs(mobile2DMainCamera.transform.rotation.y)))
        {
            flag = true;
            count++;
            
            if (kitchenRe.Exist == true)
            {
                if (count == 1 || count == -3)
                {
                    kitchenMoveButton.enabled = true;
                }
                else
                {
                    kitchenMoveButton.enabled = false;
                }
            }

            if (kitchen.Exist == true)
            {
                if (count == -1 || count == 3)
                {
                    kitchenReMoveButton.enabled = true;
                }
                else
                {
                    kitchenReMoveButton.enabled = false;
                }
            }

            targetRot = Quaternion.AngleAxis(angleRight, axisY) * mobile2DMainCamera.transform.rotation;
        }
    }

    public void OnClickUp()
    {      
        chandelier.enabled = false;
        chandelier.enabled = true;

        downArrow.SetActive(true);
        upArrow.SetActive(false);
    }

    public void OnClickDown()
    {
        reChandelier.enabled = false;
        reChandelier.enabled = true;

        upArrow.SetActive(true);
        downArrow.SetActive(false);
    }
}