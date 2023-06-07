using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    GameObject loadingScreen;
    [SerializeField]
    GameObject obj;

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
                    SceneManager.Instance.SceneLoadingAsync("LittleRedRidingHood");
                }

                if (hit.collider.gameObject.name == "HanselAndGretelBook")
                {
                    check = true;
                    SceneManager.Instance.SceneLoadingAsync("HanselAndGretel");
                }

                if (hit.collider.gameObject.name == "PeterPanBook")
                {
                    check = true;
                    SceneManager.Instance.SceneLoadingAsync("PeterPan");
                }
            }
        }
    }

    public void OnAkazukin()
    {
        OnSelectButton = 1;
        //赤ずきんシーン遷移
        //SceneManager.LoadScene("LittleRedRidingHood");
        //SceneManager.Instance.SceneLoadingAsync("LittleRedRidingHood");
    }
    public void OnHengure()
    {
        OnSelectButton = 2;
        //ヘン&グレシーン遷移
        //SceneManager.LoadScene("HanselAndGretel");
        //SceneManager.Instance.SceneLoadingAsync("HanselAndGretel");
    }
    public void OnPeter()
    {
        OnSelectButton = 3;
        //ピーターシーン遷移
        //SceneManager.LoadScene("PeterPan");
        //SceneManager.Instance.SceneLoadingAsync("PeterPan");
    }

    public void OnTitle()
    {
        //タイトルシーン遷移
        //SceneManager.LoadScene("title");
        SceneManager.Instance.SceneLoadingAsync("title");
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
}
