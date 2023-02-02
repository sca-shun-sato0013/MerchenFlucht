using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;

public class TitleButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.Instance.SceneLoadingAsync("title");
    }
}
    