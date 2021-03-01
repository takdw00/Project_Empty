﻿Shader "Light2D/Sprites/FogOfWar"
{
	Properties
	{
		_MainTex ("Sprite Texture", 2D) = "white" {}
 
		_Color ("Tint", Color) = (1,1,1,1)

		// Camera 1

        _Cam1_Texture ("Camera 1 Texture", 2D) = "white" {}

		[HideInInspector]
        _Cam1_Position_X ("Camera 1 Position X", Float) = 0

		[HideInInspector]
        _Cam1_Position_Y ("Camera 1 Position Y", Float) = 0

		[HideInInspector]
        _Cam1_Size_X ("Camera 1 Size X", Float) = 1

		[HideInInspector]
        _Cam1_Size_Y ("Camera 1 Size Y", Float) = 1

		[HideInInspector]
        _Cam1_Size_Rotation ("Camera 1 Size Rotation", Float) = 0

		// Camera 2

        _Cam2_Texture ("Camera 2 Texture", 2D) = "white" {}

		[HideInInspector]
        _Cam2_Position_X ("Camera 2 Position X", Float) = 0

		[HideInInspector]
        _Cam2_Position_Y ("Camera 2 Position Y", Float) = 0

		[HideInInspector]
        _Cam2_Size_X ("Camera 2 Size X", Float) = 1

		[HideInInspector]
        _Cam2_Size_Y ("Camera 2 Size Y", Float) = 1

		[HideInInspector]
        _Cam2_Size_Rotation ("Camera 2 Size Rotation", Float) = 0
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
		Blend One OneMinusSrcAlpha

		Pass {

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
				float2 texcoord  : TEXCOORD1;
                float2 worldPos : TEXCOORD0;
			};
			
			fixed4 _Color;

             // Cam 1
            float _Cam1_Position_X;
            float _Cam1_Position_Y;
            float _Cam1_Size_X;
            float _Cam1_Size_Y;
            float _Cam1_Size_Rotation;

			 // Cam 2
			float _Cam2_Position_X;
            float _Cam2_Position_Y;
            float _Cam2_Size_X;
            float _Cam2_Size_Y;
            float _Cam2_Size_Rotation;

			sampler2D _MainTex;
            sampler2D _Cam1_Texture;
			sampler2D _Cam2_Texture;

			v2f vert(appdata_t IN)
			{
				v2f OUT;

				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
                
                OUT.worldPos = mul (unity_ObjectToWorld, IN.vertex);

				return OUT;
			}


            bool InRect (float2 pos, float2 rectPos, float2 rectSize) {
                return pos.x > rectPos.x && pos.x < rectPos.x +  rectSize.x && pos.y > rectPos.y && pos.y < rectPos.y + rectSize.y;
            }

            bool InCamera (float2 pos, float2 rectPos, float2 rectSize) {
                return InRect (pos, rectPos - rectSize / 2, rectSize);
            }

			float2 TransformToCamera(float2 pos, float rotation) {
                float angle = atan2(pos.y,  pos.x) - rotation;
                float dist = sqrt(pos.x *  pos.x +  pos.y *  pos.y);

                pos.x = cos(angle) * dist;
                pos.y = sin(angle) * dist;

                return(pos);
            }

			fixed4 GetPixelByID(float id, float2 texcoord) {
				if (id < 0.5f) {
					return(tex2D (_Cam1_Texture, texcoord));
				}

				if (id < 1.5f) {
					return(tex2D (_Cam2_Texture, texcoord));
				}
				
				return(fixed4(0, 0, 0, 0));
			}

			fixed4 PixelColor(v2f IN, float2 posInCamera, float2 cameraSize, float id) {
				float2 texcoord = posInCamera;
				texcoord += cameraSize / 2;
				texcoord /= cameraSize;
			
				fixed4 lightPixel = GetPixelByID(id, texcoord);
				fixed4 spritePixel = tex2D (_MainTex, IN.texcoord) * IN.color; 

				float multiplier = (lightPixel.r + lightPixel.g + lightPixel.b) / 3;

				spritePixel.a *= multiplier;

				if (spritePixel.a > 1) {
					spritePixel.a = 1;
				}

				spritePixel.rgb *= spritePixel.a; 
				
				return spritePixel;
			}
        
			fixed4 frag(v2f IN) : SV_Target
			{
				float2 camera_1_Size = float2(_Cam1_Size_X, _Cam1_Size_Y);
                float2 posInCamera1 = TransformToCamera(IN.worldPos - float2(_Cam1_Position_X, _Cam1_Position_Y),  _Cam1_Size_Rotation);

				float2 camera_2_Size = float2(_Cam2_Size_X, _Cam2_Size_Y);
                float2 posInCamera2 = TransformToCamera(IN.worldPos - float2(_Cam2_Position_X, _Cam2_Position_Y),  _Cam2_Size_Rotation);

                if (InCamera(posInCamera1, float2(0, 0), camera_1_Size)) {
                   
                    return PixelColor(IN, posInCamera1, camera_1_Size, 0);

				} else if (InCamera(posInCamera2, float2(0, 0), camera_2_Size)) {

					return PixelColor(IN, posInCamera2, camera_2_Size, 1);

                } else {
                    fixed4 spritePixel = tex2D (_MainTex, IN.texcoord) * IN.color;  

                    spritePixel.rgb *= spritePixel.a;

				    return spritePixel;
                }
				
			}

		    ENDCG
		}
	}
}