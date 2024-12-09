Shader "Quyet/Burn"
{
    Properties
    {
        _BaseTex ("BaseTex", 2D) = "white" {}
        _PlusTex("PlusTex", 2D)="white" {}
        _ScaleTexture("_ScaleTexture", Range(0.0,10.0)) = 0.1
        _ColorMulti("Color", Color) = (1,1,1,1)
        _TexFadePlus ("FadeTex", 2D) = "white" {}
        _ScaleFadePlus("Fade", Range(-0.1,1.0)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Pass
        {
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
            sampler2D _BaseTex;
            float4 _BaseTex_ST;
            sampler2D _PlusTex;
            float4 _PlusTex_ST;
            float _ScaleTexture;
            fixed4 _ColorMulti;
            sampler2D _TexFadePlus;
            float _ScaleFadePlus;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _BaseTex);
                
                return o;
            }
            fixed4 frag (v2f i) : SV_Target
            {
                float2 uvs=i.uv;
                uvs*=_ScaleTexture;
                fixed4 col1 = tex2D(_PlusTex, uvs);
                fixed4 col1White=tex2D(_TexFadePlus,uvs);
                fixed4 col2 = tex2D(_BaseTex, i.uv)*_ColorMulti;
                float reveal=step(col1.r,_ScaleFadePlus);
                fixed4 col1Total=fixed4(col1.rgb*reveal+col1White.rgb*(1-reveal),1);
                fixed4 col=col1Total*col2;
                return col;
            }
            ENDCG
        }
    }
}