Shader "Light2D/Internal/BlurLight"
{
	Properties
	{
		 _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)

		textureSize("TextureSize", Range(32,4000)) = 2048

		_Radius("Radius", Range(0,50)) = 1
		_Ratio("Ratio", Range(0,50)) = 1
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off

		Blend SrcAlpha One

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
			};
			
			fixed4 _Color;

			float textureSize;

			float _Radius;
			float _Ratio;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = _Color; // IN.color * 
	
				return OUT;
			}

			sampler2D _MainTex;

			fixed4 frag(v2f IN) : SV_Target
			{

				float2 uv = IN.texcoord;

				fixed4 color = tex2D (_MainTex, uv);

				if (_Radius > 0) {
					float4 sum = float4(0.0, 0.0, 0.0, 0.0);

					float2 pos = IN.texcoord;
					float2 tc = pos;

					float blur = _Radius / 4000;     
					float blurX = blur;
					float blurY = blur * _Ratio;
			
					int size = 30;

   					float c = 1.0 / (size * 84);

					float a = 0;

					[unroll]
					for (int x = -19; x < 20; x++) {

						[unroll]
						for (int y = -19; y < 20; y++) {
					
							float val = c * sqrt(19-abs(x) + 19 - abs(y));

							float4 c = tex2D(_MainTex, float2(tc.x + x * blurX, tc.y + y * blurY)) * val;

							//float4 c2 = float4(c.r, 1, 1, c.a);

							a += (c.x + c.y + c.z) / 3;
					

						}
					}
					
					color = float4(1,1,1,1) * IN.color;

					color.rgb *= a;
					
				} else {
					color = float4(1,1,1,0) * color.a;
				}
				
				return color;
			}
			
			ENDCG
		}
	}
}