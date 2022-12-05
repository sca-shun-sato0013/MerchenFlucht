//Shaderブロック シェーダー名を書くブロック

Shader "Unlit/Sample"
{
    //マテリアルのInspectorで設定したいプロパティを記述
    Properties
    {
        //プロパティ名(Inspectorに表示する名前,型) = デフォルト値 {オプション}
        //[NoScaleOffset]属性をつけるとInspectorに表示されなくなる(TilingとOffsetを使わない場合)
        //[NoScaleOffset]
        _MainTex ("Texture", 2D) = "white" {}

        //float
        //小数点の値を自由に設定できる

        [Space] _FloatValue("float",float) = 0.1

        //int
        //整数の値を自由に設定できる

        [Space] _IntValue("int",int) = 5

        //Range
        //指定範囲内の値をスライダーで設定できる

        [Space] _Range("Range",Range(0.5,1.0)) = 0.75

        //Color
        //色をカラーピッカーで設定できる
        //シェーダー上では、色は0～1の値で表現する(1,1,1,1)は白

        [Space] _Color("Color",Color) = (1,0,0,1)


    }

    //シェーダーのまとまりを記述するブロック
    SubShader
    {
        //Unity側にシェーダーの設定を伝えるためにタグを付ける
        //RenderType シェーダーがどのようなグループに属しているかを指定
        //半透明描画 RenderType = Transparent
        //それ以外 RenderType = Opaque

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


            //sampler2D = PropertiesブロックのTextture2Dと同じ
            //Inspectorで設定したものはシェーダー側で受け取って使うことができる
            //頂点フラグメントシェーダ側で用意した同じ名前のプロパティに自動で受け渡される

            sampler2D _MainTex;

            //テクスチャ名_STでTilingとOffsetの値をfloat4プロパティで自動で格納する仕組み
            // Tiling 画像を縮小拡大して余った部分を自身の画像で補填する
            // Offset 画像の位置を決める
            //x TilingのX
            //y TilingのY
            //z OffsetのX
            //w OffsetのY
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
