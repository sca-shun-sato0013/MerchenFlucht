//Shader�u���b�N �V�F�[�_�[���������u���b�N

Shader "Unlit/Sample"
{
    //�}�e���A����Inspector�Őݒ肵�����v���p�e�B���L�q
    Properties
    {
        //�v���p�e�B��(Inspector�ɕ\�����閼�O,�^) = �f�t�H���g�l {�I�v�V����}
        //[NoScaleOffset]�����������Inspector�ɕ\������Ȃ��Ȃ�(Tiling��Offset���g��Ȃ��ꍇ)
        //[NoScaleOffset]
        _MainTex ("Texture", 2D) = "white" {}

        //float
        //�����_�̒l�����R�ɐݒ�ł���

        [Space] _FloatValue("float",float) = 0.1

        //int
        //�����̒l�����R�ɐݒ�ł���

        [Space] _IntValue("int",int) = 5

        //Range
        //�w��͈͓��̒l���X���C�_�[�Őݒ�ł���

        [Space] _Range("Range",Range(0.5,1.0)) = 0.75

        //Color
        //�F���J���[�s�b�J�[�Őݒ�ł���
        //�V�F�[�_�[��ł́A�F��0�`1�̒l�ŕ\������(1,1,1,1)�͔�

        [Space] _Color("Color",Color) = (1,0,0,1)


    }

    //�V�F�[�_�[�̂܂Ƃ܂���L�q����u���b�N
    SubShader
    {
        //Unity���ɃV�F�[�_�[�̐ݒ��`���邽�߂Ƀ^�O��t����
        //RenderType �V�F�[�_�[���ǂ̂悤�ȃO���[�v�ɑ����Ă��邩���w��
        //�������`�� RenderType = Transparent
        //����ȊO RenderType = Opaque

        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            //Tags {"LightMode" = "ShadowCaster"}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };


            //sampler2D = Properties�u���b�N��Textture2D�Ɠ���
            //Inspector�Őݒ肵�����̂̓V�F�[�_�[���Ŏ󂯎���Ďg�����Ƃ��ł���
            //���_�t���O�����g�V�F�[�_���ŗp�ӂ����������O�̃v���p�e�B�Ɏ����Ŏ󂯓n�����

            sampler2D _MainTex;

            //�e�N�X�`����_ST��Tiling��Offset�̒l��float4�v���p�e�B�Ŏ����Ŋi�[����d�g��
            // Tiling �摜���k���g�債�ė]�������������g�̉摜�ŕ�U����
            // Offset �摜�̈ʒu�����߂�
            //x Tiling��X
            //y Tiling��Y
            //z Offset��X
            //w Offset��Y
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
