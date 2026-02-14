shader "_Own/1_Basics"
{
	properties
	{

	}

	subshader
	{
		pass 
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct Input
			{
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};
			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert(Input a_input)
			{
				v2f l_output;
				l_output.pos = mul(UNITY_MATRIX_MVP, a_input.pos);
				l_output.uv = a_input.uv;
				return l_output;
			}

			float4 frag(v2f a_input) : SV_TARGET
			{
				return float4(a_input.uv, 0.0, 0.0);
			}
			ENDHLSL
		}
	}
}