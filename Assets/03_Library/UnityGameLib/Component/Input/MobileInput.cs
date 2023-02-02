using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;


public static class MobileInput
{
    public static bool InputState(TouchPhase touchPhase)
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == touchPhase)
            {
                return true;      
            }
        }
        return false;
    }
}
    