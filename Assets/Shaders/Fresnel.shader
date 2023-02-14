// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Fresnel"
{
    Properties{
    _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _FresnelPower ("Fresnel Power", Range(0,5)) = 1.5
        _FresnelIntensity ("Fresnel Intensity", Range(0,1)) = 1
    }
    SubShader {
        Tags {"Queue"="Transparent" "RenderType"="Opaque"}
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };
            
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float _FresnelPower;
            float _FresnelIntensity;
            
            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target {
                float fresnel = 1 - dot(normalize(i.worldPos - _WorldSpaceCameraPos), normalize(i.worldPos - _WorldSpaceCameraPos));
                fresnel = pow(fresnel, _FresnelPower) * _FresnelIntensity;
                fixed4 tex = tex2D(_MainTex, i.uv) * _Color;
                return lerp(tex, _Color, fresnel);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}