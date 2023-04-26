using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;

public class RayCastComponent : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    InputType inputType;

    Ray ray;

    RaycastHit hit;
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

            ray = Camera.main.ScreenPointToRay(touch.position); // RayÇê∂ê¨

            Debug.Log(touch.position);

            Physics.Raycast(ray, out hit);
        }
    }

    public (bool rayCollision,RaycastHit hit) RayCast()
    {
        return (Ray(inputType),hit);
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
    