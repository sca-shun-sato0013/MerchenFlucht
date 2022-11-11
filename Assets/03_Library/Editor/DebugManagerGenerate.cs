using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class DebugManagerGenerate : EditorWindow
{

    // @""�Ƃ��邱�ƂŁA�����s��������
    // �����u"�v�́u""�v�Ƃ��ď����܂�
    private const string CODE =
@"using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib;
using NUnityGameLib.NDesignPattern.NSingleton;
using NUnityGameLib.NGameManager.NDebugManager;

  public class Noname : DebugManager,IUnityGameLib,IDebugManager,ISingleton
  {
      void Start() 
      {
            Debug.Log(""UnityGameStart"");
      }

      public override void UpdateLib()
      {

      }
  }
    ";

    // ���j���[��UnityGameLib�I�������Generate���\�b�h���Ă΂��
    [MenuItem("UnityGameLib/Generate/Script/DebugManager")]
    private static void Generate()
    {
        // �쐬����A�Z�b�g�̃p�X
        string filePath = "Assets/Noname.cs";

        // �������O(�p�X)���d�����Ă����ꍇ�ɁA�����Ō���ɁuSample1.cs�v�݂������������Ă����
        string assetPath = AssetDatabase.GenerateUniqueAssetPath(filePath);

        // �A�Z�b�g(.cs)���쐬����
        File.WriteAllText(assetPath, CODE);

        // �ύX���������A�Z�b�g���C���|�[�g����(UnityEditor�̍X�V)
        AssetDatabase.Refresh();
    }
}
