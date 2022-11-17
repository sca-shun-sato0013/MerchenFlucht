using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib;
using NUnityGameLib.NDesignPattern.NSingleton;


[ExecuteAlways]//UnityEditor���쒆�ɂ����삷�鑮��
public class AspectKeeper : Singleton<AspectKeeper>,IUnityGameLib,ISingleton
{
    [SerializeField]
    private Camera targetCamera; //�ΏۂƂ���J����

    [SerializeField]
    private Vector2 aspectVec; //�ړI�𑜓x

    public override void UpdateLib()
    {               
        float screenAspect = Screen.width / (float)Screen.height; //��ʂ̃A�X�y�N�g��
        float targetAspect = aspectVec.x / aspectVec.y; //�ړI�̃A�X�y�N�g��

        float magRate = targetAspect / screenAspect; //�ړI�A�X�y�N�g��ɂ��邽�߂̔{��

        var viewportRect = new Rect(0, 0, 1, 1); //Viewport�����l��Rect���쐬

        if (magRate < 1)
        {
            viewportRect.width = magRate; //�g�p���鉡����ύX
            viewportRect.x = 0.5f - viewportRect.width * 0.5f;//������
        }
        else
        {
            viewportRect.height = 1 / magRate; //�g�p����c����ύX
            viewportRect.y = 0.5f - viewportRect.height * 0.5f;//������
        }

        targetCamera.rect = viewportRect; //�J������Viewport�ɓK�p
    }
}