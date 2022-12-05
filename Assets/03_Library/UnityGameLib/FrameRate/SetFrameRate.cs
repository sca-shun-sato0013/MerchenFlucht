using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib;

public class SetFrameRate : UnityGameLib,IUnityGameLib
{
    [SerializeField] int mFrameRate = 60;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = mFrameRate;
    }

    
}
