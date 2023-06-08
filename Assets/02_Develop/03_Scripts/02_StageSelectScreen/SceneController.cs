using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using UnityEngine.Playables;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    GameObject loadingScreen;
    [SerializeField]
    GameObject obj;
    [SerializeField]
    PlayableDirector stageSelect_LittleRed,stageSelect_Hansel,stageSelect_PeterPan;
    [SerializeField,Header("各スクリーン系")]
    GameObject littleScreen,hanselScreen,peterPanScreen;

    private int OnSelectButton = 0;

    bool check = false;
    private void Update()
    {
        if (check)
        {
            if (loadingScreen.activeSelf)
            {
                obj.SetActive(false);
            }
            else
            {
                obj.SetActive(true);
            }
        }

        if (MobileInput.InputState(TouchPhase.Began)) // 左クリック
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position); // Rayを生成

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Rayを投射
            {
                if (hit.collider.gameObject.name == "LittleRedRidingHoodBook")
                {
                    check = true;

                    hanselScreen.SetActive(false);
                    peterPanScreen.SetActive(false);
                    littleScreen.SetActive(true);
                }

                if (hit.collider.gameObject.name == "HanselAndGretelBook")
                {
                    check = true;
                    littleScreen.SetActive(false);
                    peterPanScreen.SetActive(false);
                    hanselScreen.SetActive(true);                    
                }

                if (hit.collider.gameObject.name == "PeterPanBook")
                {
                    check = true;

                    littleScreen.SetActive(false);
                    hanselScreen.SetActive(false);
                    peterPanScreen.SetActive(true);
                }
            }
        }
    }

    public void OnAkazukin()
    {
        OnSelectButton = 1;
        check = true;
        //赤ずきんシーン遷移
        stageSelect_LittleRed.enabled = false;
        stageSelect_LittleRed.enabled = true;
        StartCoroutine(TimeLine_Wait("LittleRedRidingHood"));
    }
    public void OnHengure()
    {
        OnSelectButton = 2;
        check = true;
        //ヘン&グレシーン遷移
        stageSelect_Hansel.enabled = false;
        stageSelect_Hansel.enabled = true;
        StartCoroutine(TimeLine_Wait("HanselAndGretel"));

    }
    public void OnPeter()
    {
        OnSelectButton = 3;
        check = true;
        //ピーターシーン遷移
        stageSelect_PeterPan.enabled = false;
        stageSelect_PeterPan.enabled = true;
        StartCoroutine(TimeLine_Wait("PeterPan"));
    }

    public void OnTitle()
    {
        //タイトルシーン遷移
        //SceneManager.LoadScene("title");
        SceneManager.Instance.SceneLoadingAsync("title");
    }

    public void ReturnButton()
    {
        hanselScreen.SetActive(false);
        peterPanScreen.SetActive(false);
        littleScreen.SetActive(false);
    }

    public void OnDecideBoutton()
    {
        if (OnSelectButton == 1)
        {
            Debug.Log("1");
            SceneManager.Instance.SceneLoadingAsync("LittleRedRidingHood");
        }
        if (OnSelectButton == 2)
        {
            Debug.Log("2");
            SceneManager.Instance.SceneLoadingAsync("HanselAndGretel");
        }
        if (OnSelectButton == 3)
        {
            Debug.Log("3");
            SceneManager.Instance.SceneLoadingAsync("PeterPan");
        }
    }

    IEnumerator TimeLine_Wait(string str)
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.Instance.SceneLoadingAsync(str);
    }
}
