using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnityGameLib;

public class StartButtonScript : UnityGameLib,IUnityGameLib
{
    //ã§ìØçÏã∆
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("StageSelectScreen");
    }
}