Shader "Custom/CuatroParteDos"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
	    _mascara("mascara (RGB)", 2D) = "white" {}
		_T("Albedo 2 (RGB)", 2D) = "white" {}
	    _Slider("Variante en x", Range(-1,1)) = 0
	    _Slider2("Variante en y", Range(-1,1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex,_mascara,_T;

        struct Input
        {
            float2 uv_MainTex;
        };

		float _Slider, _Slider2;
        fixed4 _Color;


        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			float2 movi = IN.uv_MainTex;
			float x = _Slider * _Time.y;
			float y = _Slider2 * _Time.y;
			movi += float2(x, y);

			float4 d = tex2D(_mascara, IN.uv_MainTex);
			float4 w = tex2D(_T, movi);

			float4 c = tex2D(_MainTex, IN.uv_MainTex);
            //float4 c = tex2D (_MainTex, movi);
			c *= _Color;

			float4 t = c * (1 - d);
			float4 p = t * w;

			float4 u = c * p;

            o.Albedo = u.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
