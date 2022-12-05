Shader "Unlit/Lesson3UnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM //��������CG����̃v���O�����������Ƃ������}

            //�V�F�[�_�[���L�q


            //#pragma�Ƃ� �R���p�C���ɑ΂��ď���n������
            #pragma vertex vert //���_�t���O�����g�V�F�[�_�[�֐���
            #pragma fragment frag //�t���O�����g�V�F�[�_�[�֐���


            // make fog work
            // multi_compile����n�܂�̂̓V�F�[�_�[�o���A���g�Ƃ����@�\���g�����߂̖���
            // fog�͖��Ƃ����Ӗ����̂܂�
            //�R���p�C�����Ƀt�H�O���I���ɂȂ��Ă��邩�ǂ������݂Ď����Ő؂蕪���Ă����
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            
            //���_�V�F�[�_�[�ւ̓��̓f�[�^
            //���_���\�����
            //�Z�}���e�B�N�X �@�R����(:)�̌�ɏ�����Ă������
            //�����ɏ�����Ă���ϐ��ɑ΂��ăV�F�[�_�[�̊O���ł��̎�ނ̃f�[�^�����Ă����ĂƎw������ׂ̂���
            //POSITION ���_�̍��W float3 or float4
            //TEXCOORD[N] n�Ԗڂ̃e�N�X�`��UV�@n�ɂ�0�`3���w�� �v���b�g�t�H�[���ɂ���Ă�4�ȍ~���g�p�\ float2�`4
            //NORMAL ���_�̖@�� float4
            //TANGENT �ڐ� float4
            //COLOR ���_�J���[

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            //���_->�t���O�����g�ւ̎󂯓n���f�[�^
            //�|���S���P�ʂŃ��C�X�^���C�Y���������Ԃ��ꂽ�l���t���O�����g�V�F�[�_�[�ɓn�����
            //v2f�̃Z�}���e�B�N�X
            //SV_POSITION float4 ����͕K�{ ��ʂ̂ǂ��ɕ`�悷�邩�ǂ����̓��X�^���C�Y�̎��_�Ō��܂��Ă���
            //TEXCOORD[n] �e�N�X�`��UV�Ȃ� 
            //COLOR[n] �F�Ȃ�
            //SV_POSITION�͓���ł��̂܂ܕ�Ԃ��ꂽ�l�ɂȂ��Ă��Ȃ�
            //�ϐ���S�č��v����9�ȏ�ɂȂ�ƁA�v���b�g�t�H�[���ɂ���Ă͒l����Ԃ��ꂸ�ɂ��̂܂ܓn����Ă��܂�
            //��{�I�ɂ�8�ɗ}����
    
            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            //���_�V�F�[�_�[�̌`��

            /*
            
            v2f �֐��� (���_�f�[�^�^�@���_�f�[�^�ϐ���)
            {
                v2f o;
                //���_�V�F�[�_�[�̏���
                return o;
            }            
            */

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            //�F�����߂�
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG�@//�v���O�����I��
        }
    }
}
