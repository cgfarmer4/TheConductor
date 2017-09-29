// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Zololgo/Sci-Fi Hologram" 
{
	Properties
	{
		_Brightness ("Brightness", Range(0,4)) = 1
		_Fade ("Fade", Range(0,1)) = 0
		_RimColor ("Tint", Color) = (0.5,0.5,0.5,1)	
		_RimStrenght ("Rim strength", Range(0,2)) = 0
		_RimFalloff ("Rim falloff", Range(0,1)) = 1	
		_Color ("Tint", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Color(RGB) Fade(A)", 2D) = "grey" {}
		_Scanlines ("Scanlines", 2D) = "white" {}
		_Scan2 ("Scanlines 2 ", 2D) = "white" {}
		_ScanStr ("Strength", Range(0,1)) = 1
		_ScanStr2 ("Strength", Range(0,1)) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue"="Transparent"}
		LOD 100
		
		Pass
		{
			zwrite off
			blend one one
			cull off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag 
			#include "UnityCG.cginc"
			#pragma multi_compile SCAN2_OFF SCAN2_ON
			sampler2D _MainTex, _Scanlines, _Scan2;
			float4 _Color, _RimColor, _MainTex_ST, _Scanlines_ST, _Scan2_ST;
			float _Fade, _RimStrenght, _Brightness, _RimFalloff, _ScanStr, _ScanStr2;
			
			struct appdata 
			{
				float4 vertex : POSITION;
				float4 normal : NORMAL;
				float4 color : COLOR;
				float2 uv_main : TEXCOORD0;
			};
			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
				float2 uv_main : TEXCOORD0;
				float2 scanlines_uv : TEXCOORD1;
				float2 scan2_uv : TEXCOORD2;
			};
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv_main = TRANSFORM_TEX(v.uv_main, _MainTex);
				float4 screenPosOrigin = ComputeScreenPos(UnityObjectToClipPos(half4(0,0,0,1)));
				float4 screenPos = ComputeScreenPos(o.vertex);		
				float dis = length(ObjSpaceViewDir(half4(0,0,0,0)));				
				float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				float2 flicker_uv = screenPos.xy / screenPos.w - screenPosOrigin.xy / screenPosOrigin.w;
				flicker_uv.y = worldPos.y; // y-on világkoordináta, flicker térbleiséghez kell
				o.scanlines_uv = flicker_uv * _Scanlines_ST.xy + frac(_Time.x*_Scanlines_ST.zw);
				o.scan2_uv = o.scanlines_uv;
				#if SCAN2_ON
				o.scan2_uv = flicker_uv * _Scan2_ST.xy + frac(_Time.x*_Scan2_ST.zw);
				#endif
				float3 viewDir = normalize(ObjSpaceViewDir(v.vertex));
                float fresnel_rim = 1 - abs(dot(v.normal, viewDir));
				float fresnel_dissolve = 1 - dot(v.normal, viewDir);
                o.color = _Color*max(0,lerp(1,(0.5-fresnel_dissolve),_Fade*2.0)) + lerp(0,smoothstep(1 - _RimFalloff, 1.0, fresnel_rim), _RimStrenght) * _RimColor * 2.0;		
				return o;
			}
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 main = tex2D(_MainTex, i.uv_main) * _Brightness;
				fixed4 rim = i.color;
				fixed4 pri = tex2D (_Scanlines, i.scanlines_uv) * _ScanStr;
				fixed4 msk = fixed4(0,0,0,0);
				#if SCAN2_ON
				msk = tex2D (_Scan2, i.scan2_uv) * _ScanStr2;
				#endif
				return main * max(pri,msk) * rim * fixed4(0.5,0.5,0.5,0.5);
			}
			ENDCG
		}
	}
	CustomEditor "SciFiHologramShaderGUI"
}
