using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;

public class AnchoredWindowMove : MonoBehaviour,IUpdateManager
{
    [SerializeField,Header("ˆÚ“®‚³‚¹‚½‚¢component")]
    RectTransform rectTransform;

    [SerializeField,Header("–Ú“I‚ÌÀ•W")]
    Vector2 target;

    [SerializeField,Header("ˆÚ“®‚Ì‘¬‚³")]
    float speed;

    Vector2 vec2;

    private void OnDisable()
    {
        rectTransform.anchoredPosition = vec2;
    }

    void Start() 
    {
        vec2 = rectTransform.anchoredPosition;
     
        UpdateManager.Instance.Bind(this,FrameControl.ON);  
    }

    public void OnUpdate(double deltaTime)
    {
        rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition,target,speed * Time.deltaTime);
    }
}
    