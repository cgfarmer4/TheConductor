﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/Volund/BS4SuperShader" {
Properties {
	_MainTex("Diffuse", 2D) = "white" {}
}

CGINCLUDE

#pragma only_renderers d3d11 ps4 opengl

#include "UnityCG.cginc"

struct v2f {
	float4 pos	: SV_Position;
	float2 uv	: TEXCOORD0;
};

v2f vert(appdata_img v)  {
	v2f o;
	o.pos = UnityObjectToClipPos(v.vertex);
	o.uv = v.texcoord;
	return o;
}

uniform sampler2D _MainTex;
uniform float4 _MainTex_TexelSize;

uniform float4 _Target_TexelSize;

uniform float _KernelCosPower;
uniform float _KernelScale;
uniform float _NormalizationFactor;

float4 frag(v2f i) : SV_Target {
	const int width = ceil(_MainTex_TexelSize.z / _Target_TexelSize.z / 2.f);
	const float ratio = 1.f / (1.41f * width);
	
	float weight = 0.f;
	float4 color = float4(0.f, 0.f, 0.f, 0.f);

	for(int y = -width; y <= width; ++y) {
		for(int x = -width; x <= width; ++x) {
			float2 off = float2(x * _MainTex_TexelSize.x, y * _MainTex_TexelSize.y);
			float2 uv = i.uv + off;
		
			float3 s = tex2D(_MainTex, uv).rgb;
		
			float c = clamp(sqrt(x*x + y*y) * ratio * (1.f/_KernelScale), -1.57f, 1.57f);
			float w = pow(cos(c), _KernelCosPower);
			color.rgb += s.rgb * w;
			weight += w;
		}
	}
	
	return _NormalizationFactor * color.rgbb / weight;
}

ENDCG

SubShader {
	Cull Off ZTest Always ZWrite Off

	Pass {
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		ENDCG
	}
}}