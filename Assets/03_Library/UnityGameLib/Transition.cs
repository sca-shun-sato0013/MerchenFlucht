using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using NUnityGameLib;

public class Transition : UnityGameLib,IUnityGameLib
{
    [SerializeField]
    private Material transitionIn;

    [SerializeField]
    private Material transitionOut;

    [SerializeField]
    private UnityEvent OnTransition;
    [SerializeField]
    private UnityEvent OnComplete;

    void Start()
    {
        StartCoroutine(BeginTransition());
    }

    void Update()
    {
    }

    IEnumerator BeginTransition()
    {
        yield return Animate(transitionIn, 1);
        if (OnTransition != null) { OnTransition.Invoke(); }
        yield return new WaitForEndOfFrame();

        yield return Animate(transitionOut, 1);
        if (OnComplete != null) { OnComplete.Invoke(); }
    }

    /// <summary>
    /// time�b�����ăg�����W�V�������s��
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator Animate(Material material, float time)
    {
        GetComponent<Image>().material = material;
        float current = 0;
        while (current < time)
        {
            material.SetFloat("_Alpha", current / time);
            yield return new WaitForEndOfFrame();
            current += Time.deltaTime;
        }
        material.SetFloat("_Alpha", 1);
    }
}