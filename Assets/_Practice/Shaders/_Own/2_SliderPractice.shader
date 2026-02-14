shader "_Own/2_SliderColor"
{
	properties
	{
		_Color("Color", Color) = (1.0,1.0,1.0,1.0)
		_Slider("Slider", Range(0.0, 1.0)) = 0.5
	}

	subshader
	{
		pass
		{
			HLSLPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				float4 _Color;
				float _Slider;

				struct VIn
				{
					float4 pos : POSITION;
					float2 uv : TEXCOORD0;
				};
				
				struct v2f
				{
					float4 pos : SV_POSITION;
					float2 uv : TEXCOORD0;
				};

				v2f vert(VIn a_input)
				{
					v2f l_output;
					l_output.pos = mul(UNITY_MATRIX_MVP, a_input.pos);
					l_output.uv = a_input.uv;
					return l_output;
				}

				float4 frag(v2f a_input) : SV_TARGET
				{
					return step(a_input.uv.x, _Slider) * _Color;
				}
			ENDHLSL
		}
	}
}