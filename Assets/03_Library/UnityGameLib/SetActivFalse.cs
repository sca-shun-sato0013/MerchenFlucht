using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib;

public class SetActivFalse : UnityGameLib,IUnityGameLib
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);   
    }    
}
