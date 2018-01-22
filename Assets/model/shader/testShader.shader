// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader "Custom/testShader"
// {
// 	Properties
// 	{
// 		// _MainTex ("Texture", 2D) = "white" {}
// 		// _Alpha ("Alpha", 2D) = "white" {}
// 		// _TexToGray("BW blend", Range(0,1)) = 0
// 		_Color("Color", Color) = (1, 1, 1, 1)
// 	}
// 	SubShader
// 	{
// 		// No culling or depth
		
// 		Tags { "RenderType"="Opaque" }
// 		// Cull Off
// 		ZWrite On
// 		ZTest Always
// 		Fog { Mode Off}
// 		// Blend SrcAlpha OneMinusSrcAlpha
// 		// ColorMask RGB

// 		Pass
// 		{
// 			CGPROGRAM
// 			#pragma vertex vert
// 			#pragma fragment frag
			
// 			#include "UnityCG.cginc"

// 			struct appdata
// 			{
// 				float4 vertex : POSITION;
// 				float2 uv : TEXCOORD0;
// 			};

// 			struct v2f
// 			{
// 				float2 uv : TEXCOORD0;
// 				float4 vertex : SV_POSITION;
// 			};

// 			v2f vert (appdata v)
// 			{
// 				v2f o;
// 				// o.vertex = UnityObjectToClipPos(v.vertex);
// 				o.vertex = UnityObjectToClipPos(v.vertex);
// 				o.uv = v.uv;
// 				return o;
// 			}
			
// 			// sampler2D _MainTex;
// 			// sampler2D _Alpha;
// 			// fixed _TexToGray;
// 			// fixed4 frag (v2f i) : SV_Target
// 			// {
// 			// 	fixed4 col = tex2D(_MainTex, i.uv);
// 			// 	fixed4 alp = tex2D(_Alpha, i.uv);
// 			// 	fixed4 gray = (col.r*0.3 + col.g*0.59 + col.b*0.11);
// 			// 	// just invert the colors
// 			// 	 col = (col*(1-_TexToGray) + gray*(_TexToGray)) * alp;
// 			// 	// col.a = _TexToGray;
// 			// 	return col;
// 			// }
// 			fixed4 _Color;
// 			fixed4 frag () : SV_TARGET
// 			{
// 				return fixed4(_Color.rgb * _Color.a, 1.0);
// 			}


// 			ENDCG
// 		}
// 	}
	// Properties {
    //     _MainTex ("Base (RGB)", 2D) = "white" {}
    //     _Alpha ("Alpha (A)", 2D) = "white" {}
    // }
    // SubShader {
    //     Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}
	// 	Cull off
    //     ZWrite On
       
    //     Blend SrcAlpha OneMinusSrcAlpha
    //     ColorMask RGB
       
    //     Pass {
    //         SetTexture[_MainTex] {
    //             Combine texture
    //         }
    //         SetTexture[_Alpha] {
    //             Combine previous * texture
    //         }
    //     }
    // }
// }

Shader "Outlined/Silhouetted Diffuse" {
	Properties {
		_Color ("Main Color", Color) = (.5,.5,.5,1)
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_Outline ("Outline width", Range (0.0, 0.3)) = .005
		_MainTex ("Base (RGB)", 2D) = "white" { }
	}
 
	CGINCLUDE
		#include "UnityCG.cginc"
	
		struct appdata {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};
	
		struct v2f {
			float4 pos : POSITION;
			float4 color : COLOR;
		};
	
		uniform float _Outline;
		uniform float4 _OutlineColor;
	
		v2f vert(appdata v) {
			// just make a copy of incoming vertex data but scaled according to normal direction
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
		
			float3 norm   = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
			float2 offset = TransformViewToProjection(norm.xy);
	
			o.pos.xy += offset * o.pos.z * _Outline;
			o.color = _OutlineColor;
			return o;
		}
	ENDCG
 
	SubShader {
		Tags { "Queue" = "Transparent" }
 
		// note that a vertex shader is specified here but its using the one above
		Pass {
			Name "OUTLINE"
			Tags { "LightMode" = "Always" }
			Cull Off
			ZWrite Off
			ZTest Always
			ColorMask RGB // alpha not used
 
			// you can choose what kind of blending mode you want for the outline
			Blend SrcAlpha OneMinusSrcAlpha // Normal
			//Blend One One // Additive
			//Blend One OneMinusDstColor // Soft Additive
			//Blend DstColor Zero // Multiplicative
			//Blend DstColor SrcColor // 2x Multiplicative
 
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
	
				half4 frag(v2f i) :COLOR {
					return i.color;
				}
			ENDCG
		}
 
		Pass {
			Name "BASE"
			ZWrite On
			ZTest LEqual
			Blend SrcAlpha OneMinusSrcAlpha
			Material {
				Diffuse [_Color]
				Ambient [_Color]
			}
			Lighting On
			SetTexture [_MainTex] {
				ConstantColor [_Color]
				Combine texture * constant
			}
			SetTexture [_MainTex] {
				Combine previous * primary DOUBLE
			}
		}
	}
 
	// SubShader {
	// 	Tags { "Queue" = "Transparent" }
 
	// 	Pass {
	// 		Name "OUTLINE"
	// 		Tags { "LightMode" = "Always" }
	// 		Cull Front
	// 		ZWrite Off
	// 		ZTest Always
	// 		ColorMask RGB
 
	// 		// you can choose what kind of blending mode you want for the outline
	// 		Blend SrcAlpha OneMinusSrcAlpha // Normal
	// 		//Blend One One // Additive
	// 		//Blend One OneMinusDstColor // Soft Additive
	// 		//Blend DstColor Zero // Multiplicative
	// 		//Blend DstColor SrcColor // 2x Multiplicative
 
	// 		CGPROGRAM
	// 		#pragma vertex vert
	// 		#pragma exclude_renderers gles xbox360 ps3
	// 		ENDCG
	// 		SetTexture [_MainTex] { combine primary }
	// 	}
 
	// 	Pass {
	// 		Name "BASE"
	// 		ZWrite On
	// 		ZTest LEqual
	// 		Blend SrcAlpha OneMinusSrcAlpha
	// 		Material {
	// 			Diffuse [_Color]
	// 			Ambient [_Color]
	// 		}
	// 		Lighting On
	// 		SetTexture [_MainTex] {
	// 			ConstantColor [_Color]
	// 			Combine texture * constant
	// 		}
	// 		SetTexture [_MainTex] {
	// 			Combine previous * primary DOUBLE
	// 		}
	// 	}
	// }
 
	Fallback "Diffuse"
}

