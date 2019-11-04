// Improved tiling script based on ideas found here:  https://forum.unity.com/threads/improved-terrain-texture-tiling.116509/
// Originally was:  Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Dragon Audit/Standard Terrain with Better Tiling" {
	Properties{
		// used in fallback on old cards & base map
		[HideInInspector] _MainTex("BaseMap (RGB)", 2D) = "white" {}
		[HideInInspector] _Color("Main Color", Color) = (1,1,1,1)
	}

		SubShader{
			Tags {
				"Queue" = "Geometry-100"
				"RenderType" = "Opaque"
			}

			CGPROGRAM
			#pragma surface surf Standard vertex:SplatmapVert finalcolor:SplatmapFinalColor finalgbuffer:SplatmapFinalGBuffer addshadow fullforwardshadows
			#pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap forwardadd
			#pragma multi_compile_fog // needed because finalcolor oppresses fog code generation.
			#pragma target 3.0
			// needs more than 8 texcoords
			#pragma exclude_renderers gles
			#include "UnityPBSLighting.cginc"

			#pragma multi_compile __ _NORMALMAP

			#define TERRAIN_STANDARD_SHADER
			#define TERRAIN_INSTANCED_PERPIXEL_NORMAL
			#define TERRAIN_SURFACE_OUTPUT SurfaceOutputStandard
			#include "TerrainSplatmapCommon.cginc"

			half _Metallic0;
			half _Metallic1;
			half _Metallic2;
			half _Metallic3;

			half _Smoothness0;
			half _Smoothness1;
			half _Smoothness2;
			half _Smoothness3;

			#ifdef TERRAIN_STANDARD_SHADER
			void SplatmapMixCustom(Input IN, half4 defaultAlpha, out half4 splat_control, out half weight, out fixed4 mixedDiffuse, inout fixed3 mixedNormal)
			#else
			void SplatmapMixCustom(Input IN, out half4 splat_control, out half weight, out fixed4 mixedDiffuse, inout fixed3 mixedNormal)
			#endif
			{
				// adjust splatUVs so the edges of the terrain tile lie on pixel centers
				float2 splatUV = (IN.tc.xy * (_Control_TexelSize.zw - 1.0f) + 0.5f) * _Control_TexelSize.xy;
				splat_control = tex2D(_Control, splatUV);
				weight = dot(splat_control, half4(1,1,1,1));

				#if !defined(SHADER_API_MOBILE) && defined(TERRAIN_SPLAT_ADDPASS)
					clip(weight == 0.0f ? -1 : 1);
				#endif

					// Normalize weights before lighting and restore weights in final modifier functions so that the overal
					// lighting result can be correctly weighted.
					splat_control /= (weight + 1e-3f);

					float2 uvSplat0 = TRANSFORM_TEX(IN.tc.xy, _Splat0);
					float2 uvSplat1 = TRANSFORM_TEX(IN.tc.xy, _Splat1);
					float2 uvSplat2 = TRANSFORM_TEX(IN.tc.xy, _Splat2);
					float2 uvSplat3 = TRANSFORM_TEX(IN.tc.xy, _Splat3);

					mixedDiffuse = 0.0f;
					#ifdef TERRAIN_STANDARD_SHADER
					/*
					// Original tiling:
					mixedDiffuse += splat_control.r * tex2D(_Splat0, uvSplat0) * half4(1.0, 1.0, 1.0, defaultAlpha.r);
					mixedDiffuse += splat_control.g * tex2D(_Splat1, uvSplat1) * half4(1.0, 1.0, 1.0, defaultAlpha.g);
					mixedDiffuse += splat_control.b * tex2D(_Splat2, uvSplat2) * half4(1.0, 1.0, 1.0, defaultAlpha.b);
					mixedDiffuse += splat_control.a * tex2D(_Splat3, uvSplat3) * half4(1.0, 1.0, 1.0, defaultAlpha.a);
					*/
					// Improved tiling:
					mixedDiffuse += (splat_control.r * (tex2D(_Splat0, uvSplat0) + tex2D(_Splat0, uvSplat0 * -.25))) * .5
						* half4(1.0, 1.0, 1.0, defaultAlpha.r);
					mixedDiffuse += (splat_control.g * (tex2D(_Splat1, uvSplat1) + tex2D(_Splat1, uvSplat1 * -.25))) * .5
						* half4(1.0, 1.0, 1.0, defaultAlpha.g);
					mixedDiffuse += (splat_control.b * (tex2D(_Splat2, uvSplat2) + tex2D(_Splat2, uvSplat2 * -.25))) * .5
						* half4(1.0, 1.0, 1.0, defaultAlpha.b);
					mixedDiffuse += (splat_control.a * (tex2D(_Splat3, uvSplat3) + tex2D(_Splat3, uvSplat3 * -.25))) * .5
						* half4(1.0, 1.0, 1.0, defaultAlpha.a);
				#else
					// This code is never executed
					mixedDiffuse += splat_control.r * tex2D(_Splat0, uvSplat0);
					mixedDiffuse += splat_control.g * tex2D(_Splat1, uvSplat1);
					mixedDiffuse += splat_control.b * tex2D(_Splat2, uvSplat2);
					mixedDiffuse += splat_control.a * tex2D(_Splat3, uvSplat3);
				#endif

				#ifdef _NORMALMAP
					// Improved tiling:
					mixedNormal =
						(UnpackNormalWithScale(tex2D(_Normal0, uvSplat0), _NormalScale0) +
						UnpackNormalWithScale(tex2D(_Normal0, uvSplat0 * -.25), _NormalScale0))
						* .5
						* splat_control.r;
					mixedNormal +=
						(UnpackNormalWithScale(tex2D(_Normal1, uvSplat1), _NormalScale1) +
						UnpackNormalWithScale(tex2D(_Normal1, uvSplat1 * -.25), _NormalScale1))
						* .5
						* splat_control.g;
					mixedNormal +=
						(UnpackNormalWithScale(tex2D(_Normal2, uvSplat2), _NormalScale2) +
						UnpackNormalWithScale(tex2D(_Normal2, uvSplat2 * -.25), _NormalScale2))
						* .5
						* splat_control.b;
					mixedNormal +=
						(UnpackNormalWithScale(tex2D(_Normal3, uvSplat3), _NormalScale3) +
						UnpackNormalWithScale(tex2D(_Normal3, uvSplat3 * -.25), _NormalScale3))
						* .5
						* splat_control.a;
					mixedNormal.z += 1e-5f; // to avoid nan after normalizing

					// Experimental tiling (came out kinda too shiny for me)
					/*mixedNormal  = UnpackNormalWithScale(
						tex2D(_Normal0, uvSplat0) + tex2D(_Normal0, uvSplat0 * -.25), _NormalScale0) * .5
						* splat_control.r;
					mixedNormal += UnpackNormalWithScale(
						tex2D(_Normal1, uvSplat1) + tex2D(_Normal1, uvSplat1 * -.25), _NormalScale1) * .5
						* splat_control.g;
					mixedNormal += UnpackNormalWithScale(
						tex2D(_Normal2, uvSplat2) + tex2D(_Normal2, uvSplat2 * -.25), _NormalScale2) * .5
						* splat_control.b;
					mixedNormal += UnpackNormalWithScale(
						tex2D(_Normal3, uvSplat3) + tex2D(_Normal3, uvSplat3 * -.25), _NormalScale3) * .5
						* splat_control.a;
					mixedNormal.z += 1e-5f; // to avoid nan after normalizing
					*/

					// Original tiling:
					/*mixedNormal = UnpackNormalWithScale(tex2D(_Normal0, uvSplat0), _NormalScale0) * splat_control.r;
					mixedNormal += UnpackNormalWithScale(tex2D(_Normal1, uvSplat1), _NormalScale1) * splat_control.g;
					mixedNormal += UnpackNormalWithScale(tex2D(_Normal2, uvSplat2), _NormalScale2) * splat_control.b;
					mixedNormal += UnpackNormalWithScale(tex2D(_Normal3, uvSplat3), _NormalScale3) * splat_control.a;
					mixedNormal.z += 1e-5f; // to avoid nan after normalizing
					*/
				#endif

				#if defined(INSTANCING_ON) && defined(SHADER_TARGET_SURFACE_ANALYSIS) && defined(TERRAIN_INSTANCED_PERPIXEL_NORMAL)
					mixedNormal = float3(0, 0, 1); // make sure that surface shader compiler realizes we write to normal, as UNITY_INSTANCING_ENABLED is not defined for SHADER_TARGET_SURFACE_ANALYSIS.
				#endif

				#if defined(UNITY_INSTANCING_ENABLED) && !defined(SHADER_API_D3D11_9X) && defined(TERRAIN_INSTANCED_PERPIXEL_NORMAL)
					float3 geomNormal = normalize(tex2D(_TerrainNormalmapTexture, IN.tc.zw).xyz * 2 - 1);
					#ifdef _NORMALMAP
						float3 geomTangent = normalize(cross(geomNormal, float3(0, 0, 1)));
						float3 geomBitangent = normalize(cross(geomTangent, geomNormal));
						mixedNormal = mixedNormal.x * geomTangent
									  + mixedNormal.y * geomBitangent
									  + mixedNormal.z * geomNormal;
					#else
						mixedNormal = geomNormal;
					#endif
					mixedNormal = mixedNormal.xzy;
				#endif
			}

			void surf(Input IN, inout SurfaceOutputStandard o) {
				half4 splat_control;
				half weight;
				fixed4 mixedDiffuse;
				half4 defaultSmoothness = half4(_Smoothness0, _Smoothness1, _Smoothness2, _Smoothness3);
				SplatmapMixCustom(IN, defaultSmoothness, splat_control, weight, mixedDiffuse, o.Normal);
				o.Albedo = mixedDiffuse.rgb;
				o.Alpha = weight;
				o.Smoothness = mixedDiffuse.a;
				o.Metallic = dot(splat_control, half4(_Metallic0, _Metallic1, _Metallic2, _Metallic3));
			}

			ENDCG

			UsePass "Hidden/Nature/Terrain/Utilities/PICKING"
			UsePass "Hidden/Nature/Terrain/Utilities/SELECTION"
		}

			Dependency "AddPassShader" = "Hidden/TerrainEngine/Splatmap/Standard-AddPass"
				Dependency "BaseMapShader" = "Hidden/TerrainEngine/Splatmap/Standard-Base"
				Dependency "BaseMapGenShader" = "Hidden/TerrainEngine/Splatmap/Standard-BaseGen"

				Fallback "Nature/Terrain/Diffuse"
}
