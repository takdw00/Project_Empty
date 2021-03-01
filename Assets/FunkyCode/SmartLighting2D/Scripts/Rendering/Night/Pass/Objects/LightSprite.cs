using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rendering.Night {
	

    public class LightSprite {

		static public void Draw_scriptable(Scriptable.LightSprite2D id, Camera camera) {

			if (id.Sprite == null) {
				return;
			}

			if (id.InCamera(camera) == false) {
				return;
			}

			Vector2 offset = -camera.transform.position;

			Vector2 position = id.Position;
			Vector2 scale = id.Scale;
			float rot = id.Rotation;

			Color color = id.Color;

			Material material = Lighting2D.materials.GetAdditive();
			material.SetColor ("_TintColor", color);

			material.mainTexture = id.Sprite.texture;

			VirtualSpriteRenderer virtualSprite = new VirtualSpriteRenderer();
			virtualSprite.sprite = id.Sprite;

			GLExtended.color = Color.white;

			Universal.Sprite.FullRect.Simple.Draw(id.spriteMeshObject, material, virtualSprite, offset + position, scale, rot);

			material.mainTexture = null;
		}

		static public void Draw(LightSprite2D id, Camera camera) {
			Material material = null;

			if (id.GetSprite() == null) {
				return;
			}

			if (id.InCamera(camera) == false) {
				return;
			}

			Vector2 offset = -camera.transform.position;

			Vector2 position = id.transform.position;

			Vector2 scale = id.transform.lossyScale;
			scale.x *= id.lightSpriteTransform.scale.x;
			scale.y *= id.lightSpriteTransform.scale.y;

			float rot = id.lightSpriteTransform.rotation;
			if (id.lightSpriteTransform.applyRotation) {
				rot += id.transform.rotation.eulerAngles.z;
			}

			Color color = id.color;

			Sprite sprite = id.GetSprite();
			Texture2D texture = sprite.texture;
			float ratio = (float)texture.width / (float)texture.height;
			//float ratio = sprite.rect.width / sprite.rect.height;

			if (id.glowMode.enable) {

				switch(id.type) {
					case LightSprite2D.Type.Light: 
						material = Lighting2D.materials.GetBlurLight();

						material.SetColor ("_Color", color);
						material.SetFloat("_Radius", id.glowMode.glowRadius);
						material.SetFloat("_Ratio", ratio);

						material.mainTexture = texture;
						
						Universal.Sprite.FullRect.Simple.Draw(id.spriteMeshObject, material, id.spriteRenderer, offset + position + id.lightSpriteTransform.position, scale, rot);
						
						material.mainTexture = null;
				
						break;

					case LightSprite2D.Type.Mask:

						material = Lighting2D.materials.GetBlurMask();

						material.SetColor ("_Color", color);
						material.SetFloat("_Radius", id.glowMode.glowRadius);
						material.SetFloat("_Ratio", ratio);

						material.mainTexture = texture;
						
						Universal.Sprite.FullRect.Simple.Draw(id.spriteMeshObject, material, id.spriteRenderer, offset + position + id.lightSpriteTransform.position, scale, rot);
						
						material.mainTexture = null;
					
						break;
				}
					

			} else {
				switch(id.type) {
					case LightSprite2D.Type.Light: 

						material = Lighting2D.materials.GetAdditive();
						material.SetColor ("_TintColor", color);
						
						material.mainTexture = texture;
						
						Universal.Sprite.FullRect.Simple.Draw(id.spriteMeshObject, material, id.spriteRenderer, offset + position + id.lightSpriteTransform.position, scale, rot);
						
						material.mainTexture = null;

						break;

					case LightSprite2D.Type.Mask:

						material = Lighting2D.materials.GetMask();
						material.color = color;

						material.mainTexture = texture;

						Universal.Sprite.FullRect.Simple.Draw(id.spriteMeshObject, material, id.spriteRenderer, offset + position + id.lightSpriteTransform.position, scale, rot);
						
						material.mainTexture = null;

					
						break;
				}
			}

			if (material != null) {
				material.color = Color.white;
			}
			
		}
	}
}