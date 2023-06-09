using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;
using NJsonLoader;

public class CipherScreen_Shelf : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    Fade fade;

    [SerializeField]
    FadeImage fadeImage;

    [SerializeField]
    Image item1, item2;

    [SerializeField]
    ScenarioScreenHansel hansel;

    [SerializeField]
    GameObject scenarioScreen,cipherScreen_shelf;

    [SerializeField]
    ImageLoadings imageLoadings;

    ScenarioState scenarioState;


    [SerializeField]
    Image[] imageColor;

    [SerializeField]
    Text text, text2,text3;

    int[] counts;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
        counts = new int[imageColor.Length];
        scenarioState = new ScenarioState();
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        
    }

    private void Decryption()
    {
        int check = 0;

        for (int i = 0; i < imageColor.Length; i++)
        {
            
            if (counts[i] == i + 1)
            {
                check++;
            }

            if (check == 7)
            {
                Debug.Log("全部そろった！");
                text.enabled = false;
                text3.enabled = false;
                text2.enabled = true;

                fade.FadeIn(2f);

                scenarioState.scenarioSceneHansel = ScenarioSceneHansel.shelfCipherAnswer;
                ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                StartCoroutine(Change_MainScreen());
            }
            else
            {
                text.enabled = false;
                text2.enabled = false;
                text3.enabled = true;
            }
        }
    }

    private IEnumerator Change_MainScreen()
    {
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        imageLoadings.AddList(item1, "Assets/LoadingDatas/ScenarioDatas/HanselAndGretel/H&G日記(閉).png");
        imageLoadings.AddList(item2, "Assets/LoadingDatas/ScenarioDatas/HanselAndGretel/H&G写真.png");
        scenarioScreen.SetActive(true);
        cipherScreen_shelf.SetActive(false);
        hansel.enabled = true;
    }

    private void ColorState(ref int count,Image img)
    {
        switch (count)
        {
            
            case 1:
                
                img.color = ColorChange.ColorChanes(1, 1, 0.5f, 1);
                break;

            case 2:
                img.color = ColorChange.ColorChanes(0.25f, 0.25f, 1, 1);
                break;

            case 3:
                img.color = ColorChange.ColorChanes(0.85f, 0.68f, 1, 1);
                break;

            case 4:
                img.color = ColorChange.ColorChanes(0.7f, 1f, 0.7f, 1);
                break;

            case 5:
                img.color = ColorChange.ColorChanes(1f, 0.6f, 0.6f, 1);
                break;

            case 6:
                img.color = ColorChange.ColorChanes(0.75f, 1f, 1f, 1);
                break;

            case 7:
                img.color = ColorChange.ColorChanes(1f, 0.8f, 0.6f, 1);
                break;

            case 8:
                count = 1;
                img.color = ColorChange.ColorChanes(1, 1, 0.5f, 1);
                break;
        }
    }

    public void OnClickColor0()
    {
        counts[0]++;

        ColorState(ref counts[0],imageColor[0]);

        Decryption();
    }

    public void OnClickColor1()
    {
        counts[1]++;

        ColorState(ref counts[1], imageColor[1]);

        Decryption();
    }

    public void OnClickColor2()
    {
        counts[2]++;

        ColorState(ref counts[2], imageColor[2]);

        Decryption();
    }

    public void OnClickColor3()
    {
        counts[3]++;

        ColorState(ref counts[3], imageColor[3]);

        Decryption();
    }

    public void OnClickColor4()
    {
        counts[4]++;

        ColorState(ref counts[4], imageColor[4]);

        Decryption();
    }

    public void OnClickColor5()
    {
        counts[5]++;

        ColorState(ref counts[5], imageColor[5]);

        Decryption();
    }

    public void OnClickColor6()
    {
        counts[6]++;

        ColorState(ref counts[6], imageColor[6]);

        Decryption();
    }
}
    