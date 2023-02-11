Shader "Custom/Bordes/BordesContinuo" {

	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_Textura ("Textura", 2D) = "white" {}
	}


	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		sampler2D _Textura;
		struct Input {
			float2 uv_Textura;
			float3 worldNormal;
			float3 viewDir;
		};

		float4 _Color;


		void surf (Input IN, inout SurfaceOutputStandard o) {
			
			float bordes = 1-abs(dot(IN.viewDir, IN.worldNormal));
			float4 c = tex2D(_Textura, IN.uv_Textura)  ;
			float4 r = bordes * _Color;

			
			
			o.Albedo = ((c-bordes)+r);
			o.Emission = r;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
