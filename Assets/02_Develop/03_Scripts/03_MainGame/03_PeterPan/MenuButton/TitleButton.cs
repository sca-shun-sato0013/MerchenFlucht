using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Rendering;

public class TitleButton : MonoBehaviour
{
    [SerializeField]
    Volume volume;
    public void OnClick()
    {
        volume.enabled = false;
        SceneManager.Instance.SceneLoadingAsync("title");
    }
}
    