#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GithubAccess : EditorWindow
{
    [MenuItem("UnityGameLib/Access/Github")]
    private static void Window1()
    {
        Application.OpenURL("https://github.com/");
    }

    [MenuItem("UnityGameLib/Access/C# MicrosoftReference")]
    private static void Window2()
    {
        Application.OpenURL("https://learn.microsoft.com/ja-jp/dotnet/csharp/language-reference/");
    }

    [MenuItem("UnityGameLib/Access/UnityReference")]
    private static void Window3()
    {
        Application.OpenURL("https://docs.unity3d.com/ja/2019.4/ScriptReference/index.html");
    }
}

#endif