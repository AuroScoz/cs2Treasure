// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)
//灰階材質球 出處:https://blog.csdn.net/LIQIANGEASTSUN/article/details/49700621
Shader "UISprites/DefaultGray"
{
    Properties
    {
        [PerRendererData] _MinTex ("Sprite Texture", 2D) = "White" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel Snap", Float) = 0

        //---Add---
        // Change the brightness of the Sprite
        _GrayScale ("GrayScale", Float) = 1
        //---Add---
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
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ PIXELSNAP_ON
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

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color * _Color;
                #ifdef PIXELSNAP_ON
                OUT.vertex = UnityPixelSnap (OUT.vertex);
                #endif

                return OUT;
            }

            sampler2D _MainTex;
            float _GrayScale;

            fixed4 frag(v2f IN) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, IN.texcoord) * IN.color;

                //---Add---
                float cc = (c.r * 0.299 + c.g * 0.518 + c.b * 0.184);
                cc *= _GrayScale;
                c.r = c.g = c.b = cc;
                //---Add---

                c.rgb *= c.a;
                return c;
            }
        ENDCG
        }
    }
}
