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
    [SerializeField,Header("�e�X�N���[���n")]
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

        if (MobileInput.InputState(TouchPhase.Began)) // ���N���b�N
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position); // Ray�𐶐�

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Ray�𓊎�
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
        //�Ԃ�����V�[���J��
        stageSelect_LittleRed.enabled = false;
        stageSelect_LittleRed.enabled = true;
        StartCoroutine(TimeLine_Wait("LittleRedRidingHood"));
    }
    public void OnHengure()
    {
        OnSelectButton = 2;
        check = true;
        //�w��&�O���V�[���J��
        stageSelect_Hansel.enabled = false;
        stageSelect_Hansel.enabled = true;
        StartCoroutine(TimeLine_Wait("HanselAndGretel"));

    }
    public void OnPeter()
    {
        OnSelectButton = 3;
        check = true;
        //�s�[�^�[�V�[���J��
        stageSelect_PeterPan.enabled = false;
        stageSelect_PeterPan.enabled = true;
        StartCoroutine(TimeLine_Wait("PeterPan"));
    }

    public void OnTitle()
    {
        //�^�C�g���V�[���J��
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
