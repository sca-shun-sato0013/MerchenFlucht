using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    //‹¤“¯ì‹Æ
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("StageSelectScreen");
    }
}