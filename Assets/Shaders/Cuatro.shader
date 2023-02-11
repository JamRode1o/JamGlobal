Shader "Custom/Cuatro"
{
    Properties
    {
        _Tex ("Albedo (RGB)", 2D) = "white" {}
	    _Mascara("Albedo (RGB)", 2D) ="white" {}
		 _Mascara2("Albedo (RGB)", 2D) = "white" {}
		  _Mascara3("Albedo (RGB)", 2D) = "white" {}

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

        sampler2D _Tex,_Mascara,_Mascara2,_Mascara3;

        struct Input
        {
            float2 uv_Tex,uv_Mas;
        };

  

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            
            float4 c = tex2D (_Tex, IN.uv_Tex);
			float4 w = tex2D(_Mascara, IN.uv_Tex);
			float4 q= tex2D(_Mascara2, IN.uv_Tex);
			float4 r= tex2D(_Mascara3, IN.uv_Tex);

			float4 d = c.r * w;
			float4 t = c.g *q;
			float4 y = c.b*r;
			float4 u = d + t + y;


            o.Albedo = u.rgb;


        }
        ENDCG
    }
    FallBack "Diffuse"
}
