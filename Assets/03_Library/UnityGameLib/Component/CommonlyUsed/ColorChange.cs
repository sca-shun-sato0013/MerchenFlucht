using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;

public static class ColorChange
{
    public static Color ColorChanes(float r,float g,float b,float a)
    {
        Color c;
        c.r = r;
        c.g = g;
        c.b = b;
        c.a = a;
        
        return c;
    }
}
    