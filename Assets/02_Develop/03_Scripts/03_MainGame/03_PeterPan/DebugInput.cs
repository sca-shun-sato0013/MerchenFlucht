using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInput : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            obj.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.F2))
        {
            obj.SetActive(false);
        }
    }
}
