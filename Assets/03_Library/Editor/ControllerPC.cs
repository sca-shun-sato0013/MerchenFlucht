using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class ControllerPC : EditorWindow
{

    // @""�Ƃ��邱�ƂŁA�����s��������
    // �����u"�v�́u""�v�Ƃ��ď����܂�
    private const string CODE =
@"using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnityGameLib;
using NUnityGameLib.NPlayerController.NControllerPC;

  public class Noname : ControllerPC,IUnityGameLib,IControllerPC
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

    // ���j���[�́uTools -> Generate Script�v��I�������Generate���\�b�h���Ă΂��
    [MenuItem("UnityGameLib/Generate/Script/ControllerPC")]
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
