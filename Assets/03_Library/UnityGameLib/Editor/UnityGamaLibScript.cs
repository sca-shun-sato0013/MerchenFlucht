#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.IO;
using UnityEditor;

public class UnityGamaLibScript : EditorWindow
{
    string script = "";
    string className = "";
    // @""とすることで、複数行を書ける
    // ただ「"」は「""」として書きます
    private const string CODE =
@"using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;

public class Noname : MonoBehaviour,IUpdateManager
{
    

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;
    }
}
    ";



    [MenuItem("UnityGameLib/TemplateCode/Standard")]
    [MenuItem("Assets/Create/UnityGameLib/TemplateCode/Standard")]
    private static void ShowWindow()
    {
        UnityGamaLibScript window = (UnityGamaLibScript)GetWindow(typeof(UnityGamaLibScript));
        window.titleContent = new GUIContent("☆ScriptCreator");
    }

    private void OnGUI()
    {
        GUILayout.Label("ScriptName");
        className = EditorGUILayout.TextArea(className, GUILayout.Height(20));

        if (GUILayout.Button("ScriptCreate"))
        {
            Debug.Log(className);
            script = CODE.Replace("Noname",className);
            Generate(className,script);
        }
    }

    private static void Generate(string scriptName,string script)
    {
        // 作成するアセットのパス
        string filePath = GetCurrentDirectory()+"/"+scriptName+".cs";

        // もし名前(パス)が重複していた場合に、自動で語尾に「Sample1.cs」みたく数字をつけてくれる
        string assetPath = AssetDatabase.GenerateUniqueAssetPath(filePath);

        // アセット(.cs)を作成する
        File.WriteAllText(assetPath,script);

        // 変更があったアセットをインポートする(UnityEditorの更新)
        AssetDatabase.Refresh();

    }

    /// <summary>
    /// 参考URL
    /// https://qiita.com/r-ngtm/items/13d609cbd6a30e39f83a
    /// </summary>
    /// <returns></returns>
    static string GetCurrentDirectory()
    {
        BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
        Assembly asm = Assembly.Load("UnityEditor.dll");
        System.Type typeProjectBrowser = asm.GetType("UnityEditor.ProjectBrowser");
        EditorWindow projectBrowserWindow = GetWindow(typeProjectBrowser);
        return (string)typeProjectBrowser.GetMethod("GetActiveFolderPath", flag).Invoke(projectBrowserWindow, null);
    }

}

#endif
