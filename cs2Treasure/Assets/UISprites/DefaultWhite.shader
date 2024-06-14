// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

//全白材質球 出處:https://blog.csdn.net/qq_21315789/article/details/125408194
//結合出處:https://blog.csdn.net/LIQIANGEASTSUN/article/details/49700621
//此Shader會捨棄紋理的色彩 把圖變成純白色 原本第一個出處的照抄會導致紋理也丟失 所以結合出處2把紋理弄回來
Shader "UISprites/DefaultWhite"
{
    Properties
    {
        [PerRendererData] _MinTex ("Sprite Texture", 2D) = "White" {}
        _Color ("Tint", Color) = (1,1,1,1)
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
        CGPROGRAM
            //聲明頂點函數名為vert
            #pragma vertex vert
            //聲明片元函數名為frag
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                half2 texcoord  : TEXCOORD0;
            };

            fixed4 _Color;
            
            //頂點函數的內容
            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color * _Color;

                return OUT;
            }

            sampler2D _MainTex;

            //片元函數的內容
            fixed4 frag(v2f IN) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, IN.texcoord) * IN.color;

                //---Add---
                //這裡把色彩資訊捨棄掉 全部一律都變成1 不採用原本的色彩資訊 之後想要純黑就把cc的1改成0即可
                float cc = 1;
                c.r = c.g = c.b = cc;
                //---Add---

                c.rgb *= c.a;
                return c;
            }
        ENDCG
        }
    }
    //備用方案
    Fallback "VertexLit"
}
