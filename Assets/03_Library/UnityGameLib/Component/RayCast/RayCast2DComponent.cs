using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;

public class RayCast2DComponent : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    InputType inputType;

    RaycastHit2D hit2D;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        if(Ray(inputType))
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position); // RayÇê∂ê¨
         
            hit2D = Physics2D.Raycast(ray.origin, ray.direction);

            Debug.Log(hit2D.collider.gameObject.name);
        }
    }

    public (bool ray2DCollision,RaycastHit2D hit2D) RayHit2D()
    {
  
        return (Ray(inputType),hit2D);
    }

    private bool Ray(InputType inputType)
    {
        switch (inputType)
        {
            case InputType.InputPC:
                
                return Input.GetMouseButtonDown(0);
                
            case InputType.MobileInput:

                return MobileInput.InputState(TouchPhase.Began);
               
        }

        return false;
    }
}
    