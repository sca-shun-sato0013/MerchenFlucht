using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class UnityDebugWindow : EditorWindow
{
 
    string text = "";
    /// <summary>
    /// ���֐�unity�̃��j���[��ɕ\�������֐�
    /// ���֐����̃{�^�����g���邩�̔���
    /// ��O�֐����j���[�A�C�e���̕��я��̂̎w��
    /// </summary>
    [MenuItem("UnityGameLib/Debug/DebugWindow",false,1)]
    private static void ShowWindow()
    {
        UnityDebugWindow window = (UnityDebugWindow)GetWindow(typeof(UnityDebugWindow));
        window.titleContent = new GUIContent("UnityDebugWindow");
    }

    private void OnGUI()
    {
        GUILayout.Label("������o��");
       text = EditorGUILayout.TextArea(text, GUILayout.Height(100));
      

        if (GUILayout.Button("�R���\�[���ɏo��"))
        {
            Debug.Log(text);           
        }
        
   
    }
}
