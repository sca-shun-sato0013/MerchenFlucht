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
        //targetRot = Quaternion.AngleAxis(angle, axis) * mobile2DMainCamera.transform.rotation;
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        if (count == -4 || count == 4) count = 0;

        //Debug.Log(mobile2DMainCamera.transform.rotation);

        Debug.Log(count);
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

        if (targetRot == mobile2DMainCamera.transform.rotation)
        {
            //shadowHumanChair.enabled = false;
            flag = true;
            Debug.Log(mobile2DMainCamera.transform.eulerAngles.y);
            count--;
            Debug.Log(count);

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
            //StartCoroutine(Wait());

            /*        if (count == -5 || count == 3) shadowHumanStandUp.enabled = true;
                    else shadowHumanStandUp.enabled = false;*/

            /*        if (count == 4 || count == -4) window.enabled = true;
                    else window.enabled = false;*/

            /*        if (count == 8 || count == -8 || count == 0) painting.enabled = true;
                    else painting.enabled = false;

                    if (count == 2 || count == -6) keyBox.enabled = true;
                    else keyBox.enabled = false;*/
        }
    }

    public void OnClickRight()
    {
        

        if (targetRot == mobile2DMainCamera.transform.rotation)
        {
            //shadowHumanChair.enabled = false;
            flag = true;
            count++;
            Debug.Log(count);


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
            ///StartCoroutine(Wait());

            /*        if (count == -5 || count == 3) shadowHumanStandUp.enabled = true;
                    else shadowHumanStandUp.enabled = false;*/

            /*        if (count == 4 || count == -4) window.enabled = true;
                    else window.enabled = false;*/

            /*        if (count == 8 || count == -8 || count == 0) painting.enabled = true;
                    else painting.enabled = false;

                    if (count == 2 || count == -6) keyBox.enabled = true;
                    else keyBox.enabled = false;*/
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

        /*        if (count == 0)
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
        */

        //count2--;

        //painting.enabled = false;
        //shadowHumanChair.enabled = true;
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
