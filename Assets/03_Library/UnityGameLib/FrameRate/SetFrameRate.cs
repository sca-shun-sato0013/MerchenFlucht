using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFrameRate : MonoBehaviour
{
    [SerializeField] int mFrameRate = 60;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = mFrameRate;
    }    
}
