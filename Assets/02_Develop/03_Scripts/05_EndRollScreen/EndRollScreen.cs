using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;

public class EndRollScreen : MonoBehaviour,IUpdateManager
{
    [SerializeField,Header("text")]
    GameObject[] obj;

    [SerializeField, Header("‰æ‘œ")]
    GameObject[] img;


    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
        StartCoroutine(EndRoll());
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;        
    }

    IEnumerator EndRoll()
    {
        img[0].SetActive(true);
        img[1].SetActive(false);
        img[2].SetActive(false);
        img[3].SetActive(false);
        img[4].SetActive(false);
        img[5].SetActive(false);


        obj[0].SetActive(true);
        obj[1].SetActive(false);
        obj[2].SetActive(false);
        obj[3].SetActive(false);
        obj[4].SetActive(false);
        obj[5].SetActive(false);
        obj[6].SetActive(false);
        obj[7].SetActive(false);
        obj[8].SetActive(false);
        obj[9].SetActive(false);
        obj[10].SetActive(false);

        yield return new WaitForSeconds(7f);

        img[0].SetActive(false);
        img[1].SetActive(true);
        img[2].SetActive(false);
        img[3].SetActive(false);
        img[4].SetActive(false);
        img[5].SetActive(false);


        obj[0].SetActive(false);
        obj[1].SetActive(true);
        obj[2].SetActive(false);
        obj[3].SetActive(false);
        obj[4].SetActive(false);
        obj[5].SetActive(false);
        obj[6].SetActive(false);
        obj[7].SetActive(false);
        obj[8].SetActive(false);
        obj[9].SetActive(false);
        obj[10].SetActive(false);

        yield return new WaitForSeconds(7f);

        img[0].SetActive(false);
        img[1].SetActive(false);
        img[2].SetActive(true);
        img[3].SetActive(false);
        img[4].SetActive(false);
        img[5].SetActive(false);


        obj[0].SetActive(false);
        obj[1].SetActive(false);
        obj[2].SetActive(true);
        obj[3].SetActive(false);
        obj[4].SetActive(false);
        obj[5].SetActive(false);
        obj[6].SetActive(false);
        obj[7].SetActive(false);
        obj[8].SetActive(false);
        obj[9].SetActive(false);
        obj[10].SetActive(false);

        yield return new WaitForSeconds(7f);

        img[0].SetActive(false);
        img[1].SetActive(false);
        img[2].SetActive(false);
        img[3].SetActive(true);
        img[4].SetActive(false);
        img[5].SetActive(false);


        obj[0].SetActive(false);
        obj[1].SetActive(false);
        obj[2].SetActive(false);
        obj[3].SetActive(true);
        obj[4].SetActive(false);
        obj[5].SetActive(false);
        obj[6].SetActive(false);
        obj[7].SetActive(false);
        obj[8].SetActive(false);
        obj[9].SetActive(false);
        obj[10].SetActive(false);

        yield return new WaitForSeconds(7f);

        img[0].SetActive(false);
        img[1].SetActive(false);
        img[2].SetActive(false);
        img[3].SetActive(false);
        img[4].SetActive(true);
        img[5].SetActive(false);


        obj[0].SetActive(false);
        obj[1].SetActive(false);
        obj[2].SetActive(false);
        obj[3].SetActive(false);
        obj[4].SetActive(true);
        obj[5].SetActive(false);
        obj[6].SetActive(false);
        obj[7].SetActive(false);
        obj[8].SetActive(false);
        obj[9].SetActive(false);
        obj[10].SetActive(false);

        yield return new WaitForSeconds(7f);

        img[0].SetActive(false);
        img[1].SetActive(false);
        img[2].SetActive(false);
        img[3].SetActive(false);
        img[4].SetActive(false);
        img[5].SetActive(true);


        obj[0].SetActive(false);
        obj[1].SetActive(false);
        obj[2].SetActive(false);
        obj[3].SetActive(false);
        obj[4].SetActive(false);
        obj[5].SetActive(true);
        obj[6].SetActive(false);
        obj[7].SetActive(false);
        obj[8].SetActive(false);
        obj[9].SetActive(false);
        obj[10].SetActive(false);

        yield return new WaitForSeconds(7f);

        img[0].SetActive(true);
        img[1].SetActive(false);
        img[2].SetActive(false);
        img[3].SetActive(false);
        img[4].SetActive(false);
        img[5].SetActive(false);


        obj[0].SetActive(false);
        obj[1].SetActive(false);
        obj[2].SetActive(false);
        obj[3].SetActive(false);
        obj[4].SetActive(false);
        obj[5].SetActive(false);
        obj[6].SetActive(true);
        obj[7].SetActive(false);
        obj[8].SetActive(false);
        obj[9].SetActive(false);
        obj[10].SetActive(false);

        yield return new WaitForSeconds(7f);

        img[0].SetActive(true);
        img[1].SetActive(true);
        img[2].SetActive(false);
        img[3].SetActive(false);
        img[4].SetActive(false);
        img[5].SetActive(false);


        obj[0].SetActive(false);
        obj[1].SetActive(false);
        obj[2].SetActive(false);
        obj[3].SetActive(false);
        obj[4].SetActive(false);
        obj[5].SetActive(false);
        obj[6].SetActive(false);
        obj[7].SetActive(true);
        obj[8].SetActive(false);
        obj[9].SetActive(false);
        obj[10].SetActive(false);

        yield return new WaitForSeconds(7f);

        img[0].SetActive(false);
        img[1].SetActive(false);
        img[2].SetActive(true);
        img[3].SetActive(false);
        img[4].SetActive(false);
        img[5].SetActive(false);


        obj[0].SetActive(false);
        obj[1].SetActive(false);
        obj[2].SetActive(false);
        obj[3].SetActive(false);
        obj[4].SetActive(false);
        obj[5].SetActive(false);
        obj[6].SetActive(false);
        obj[7].SetActive(false);
        obj[8].SetActive(true);
        obj[9].SetActive(false);
        obj[10].SetActive(false);

        yield return new WaitForSeconds(7f);

        img[0].SetActive(false);
        img[1].SetActive(false);
        img[2].SetActive(false);
        img[3].SetActive(true);
        img[4].SetActive(false);
        img[5].SetActive(false);


        obj[0].SetActive(false);
        obj[1].SetActive(false);
        obj[2].SetActive(false);
        obj[3].SetActive(false);
        obj[4].SetActive(false);
        obj[5].SetActive(false);
        obj[6].SetActive(false);
        obj[7].SetActive(false);
        obj[8].SetActive(false);
        obj[9].SetActive(true);
        obj[10].SetActive(false);

        yield return new WaitForSeconds(7f);

        img[0].SetActive(false);
        img[1].SetActive(false);
        img[2].SetActive(false);
        img[3].SetActive(false);
        img[4].SetActive(true);
        img[5].SetActive(false);


        obj[0].SetActive(false);
        obj[1].SetActive(false);
        obj[2].SetActive(false);
        obj[3].SetActive(false);
        obj[4].SetActive(false);
        obj[5].SetActive(false);
        obj[6].SetActive(false);
        obj[7].SetActive(false);
        obj[8].SetActive(false);
        obj[9].SetActive(false);
        obj[10].SetActive(true);

        yield return new WaitForSeconds(7f);

        img[0].SetActive(false);
        img[1].SetActive(false);
        img[2].SetActive(false);
        img[3].SetActive(false);
        img[4].SetActive(false);
        img[5].SetActive(false);


        obj[0].SetActive(false);
        obj[1].SetActive(false);
        obj[2].SetActive(false);
        obj[3].SetActive(false);
        obj[4].SetActive(false);
        obj[5].SetActive(false);
        obj[6].SetActive(false);
        obj[7].SetActive(false);
        obj[8].SetActive(false);
        obj[9].SetActive(false);
        obj[10].SetActive(false);
        obj[11].SetActive(true);

        yield return new WaitForSeconds(5f);

        SceneManager.Instance.SceneLoadingAsync("title");
    }
}
    