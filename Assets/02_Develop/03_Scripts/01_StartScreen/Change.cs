using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;

public class Change : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    ImageTransparencyAnimation transparencyAnimation;

    [SerializeField]
    VersionCheck versionCheck;

    // Start is called before the first frame update
    void Start()
    {
        UpdateManager.Instance.Bind(this,FrameControl.ON);

        StartCoroutine(Flush());
    }

    // Update is called once per frame
    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;


    }

    public void OnClick()
    {
        versionCheck.Version();
        if(versionCheck.UpdateCheck)
        {
            SceneManager.Instance.SceneLoadingAsync("StageSelectScene");
        }
    }

    IEnumerator Flush()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);

            transparencyAnimation.enabled = false;

            yield return new WaitForSeconds(0.5f);

            transparencyAnimation.enabled = true;
        }
    }
}
