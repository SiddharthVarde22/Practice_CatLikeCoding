
shader "myPractice/Basic Properties"
{
	properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Range("Range", range(1.0, 2.0)) = 1.5
		_float("Float", float) = 1.0
		_int("Int", int) = 5
		_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_vector("Vector", vector) = (2,3,2,0)
		_texture("texture map", 2D) = "white"{}
		_cubeMap("reflection map", Cube) = "white"{}
		_3dMap("3D map", 3D) = "white"{}

		// Property Drawers
		[space(10)]
		[Header(Property Drawers__ Learrn other property drawers later)]
		[Toggle] _Enable ("Enable ?", float) = 0
	}

		subshader
	{
		Pass
		{
			CGPROGRAM
			#include "UnityCG.cginc"
			#pragma fragment frag
			#pragma shader_feature _ENABLE_ON

			// Adding Connection variables
			float4 _Color;
			sampler2D _MainTexture;

			float4 frag() : SV_Target
			{
				#if _ENABLE_ON
					return _Color;
				else
					return float4(1,1,1,1);
			}
			ENDCG
		}
	}
}