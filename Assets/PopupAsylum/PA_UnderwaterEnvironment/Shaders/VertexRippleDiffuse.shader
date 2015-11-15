Shader "Custom/VertexRipple/DiffuseMobile"
{
	Properties 
	{
_MainTex("_MainTex", 2D) = "black" {}
_Speed("_Speed", Range(0,3) ) = 0.5
_Scale("_Scale", Range(0,4) ) = 0.193
_WaveLength("_WaveLength", Float) = 0

	}
	
	SubShader 
	{
		Tags
		{
"Queue"="Geometry"
"IgnoreProjector"="True"
"RenderType"="Opaque"

		}

		
Cull Off
ZWrite On
ZTest LEqual
ColorMask RGBA
Fog{
}


		CGPROGRAM
#pragma surface surf Lambert  vertex:vert
#pragma target 2.0


sampler2D _MainTex;
fixed _Speed;
fixed _Scale;
fixed _WaveLength;

			
			struct Input {
				fixed2 uv_MainTex;

			};

			void vert (inout appdata_full v, out Input o) {
				UNITY_INITIALIZE_OUTPUT(Input,o);
				fixed4 vertexPosition = v.vertex;
				fixed timeHeightOffset = vertexPosition.y * _WaveLength.x;
				fixed waveTime = (timeHeightOffset + _Time.y) * _Speed.x;
				fixed positionOffset = sin(waveTime) * _Scale.x * v.color.r;
				v.vertex = float4(vertexPosition.x, vertexPosition.y, vertexPosition.z + positionOffset.x, vertexPosition.w);
			}
			

			void surf (Input IN, inout SurfaceOutput o) {
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				
				fixed4 Tex2D0=tex2D(_MainTex,(IN.uv_MainTex.xyxy).xy);

				o.Albedo = Tex2D0;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Diffuse"
}