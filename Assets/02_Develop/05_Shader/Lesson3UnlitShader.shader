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
            CGPROGRAM //ここからCG言語のプログラムを書くという合図

            //シェーダーを記述


            //#pragmaとは コンパイラに対して情報を渡す命令
            #pragma vertex vert //頂点フラグメントシェーダー関数名
            #pragma fragment frag //フラグメントシェーダー関数名


            // make fog work
            // multi_compileから始まるのはシェーダーバリアントという機能を使うための命令
            // fogは霧という意味そのまま
            //コンパイル時にフォグがオンになっているかどうかをみて自動で切り分けてくれる
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            
            //頂点シェーダーへの入力データ
            //頂点一つを表す情報
            //セマンティクス 　コロン(:)の後に書かれているもの
            //左側に書かれている変数に対してシェーダーの外側でこの種類のデータを入れておいてと指示する為のもの
            //POSITION 頂点の座標 float3 or float4
            //TEXCOORD[N] n番目のテクスチャUV　nには0～3を指定 プラットフォームによっては4以降も使用可能 float2～4
            //NORMAL 頂点の法線 float4
            //TANGENT 接線 float4
            //COLOR 頂点カラー

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            //頂点->フラグメントへの受け渡しデータ
            //ポリゴン単位でライスタライズ処理され補間された値がフラグメントシェーダーに渡される
            //v2fのセマンティクス
            //SV_POSITION float4 これは必須 画面のどこに描画するかどうかはラスタライズの時点で決まっている
            //TEXCOORD[n] テクスチャUVなど 
            //COLOR[n] 色など
            //SV_POSITIONは特殊でそのまま補間された値になっていない
            //変数を全て合計して9個以上になると、プラットフォームによっては値が補間されずにそのまま渡されてしまう
            //基本的には8個に抑える
    
            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            //頂点シェーダーの形式

            /*
            
            v2f 関数名 (頂点データ型　頂点データ変数名)
            {
                v2f o;
                //頂点シェーダーの処理
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

            //色を決める
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG　//プログラム終了
        }
    }
}
