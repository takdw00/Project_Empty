using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rendering.Day {

    public class SpriteRendererShadow {
        static VirtualSpriteRenderer virtualSpriteRenderer = new VirtualSpriteRenderer();

        static public void Draw(DayLightCollider2D id, Vector2 offset) {
            if (id.mainShape.shadowType != DayLightCollider2D.ShadowType.SpriteOffset) {
                return;
            }

            if (id.InAnyCamera() == false) {
                return;
            }

            Material material = Lighting2D.materials.GetSpriteShadow();
            material.color = Color.black;

            foreach(DayLightColliderShape shape in id.shapes) {
                
                SpriteRenderer spriteRenderer = shape.spriteShape.GetSpriteRenderer();
                if (spriteRenderer == null) {
                    continue;
                }
                
                virtualSpriteRenderer.sprite = spriteRenderer.sprite;
                virtualSpriteRenderer.flipX = spriteRenderer.flipX;
                virtualSpriteRenderer.flipY = spriteRenderer.flipY;

                if (virtualSpriteRenderer.sprite == null) {
                    continue;
                }
                                    
                float x = id.transform.position.x + offset.x;
                float y = id.transform.position.y + offset.y;

                float rot = -Lighting2D.DayLightingSettings.direction * Mathf.Deg2Rad;

                float sunHeight = Lighting2D.DayLightingSettings.height;

                x += Mathf.Cos(rot) * id.mainShape.height * sunHeight;
                y += Mathf.Sin(rot) * id.mainShape.height * sunHeight;

                material.mainTexture = virtualSpriteRenderer.sprite.texture;

                Vector2 scale = new Vector2(id.transform.lossyScale.x, id.transform.lossyScale.y);

                Universal.Sprite.FullRect.Simple.Draw(id.spriteMeshObject, material, virtualSpriteRenderer, new Vector2(x, y), scale, id.transform.rotation.eulerAngles.z);
            }

            material.color = Color.white;
        }

          static public void DrawProjection(DayLightCollider2D id, Vector2 offset) {
            if (id.mainShape.shadowType != DayLightCollider2D.ShadowType.SpriteProjection) {
                return;
            }

            if (id.InAnyCamera() == false) {
                return;
            }

            Material material = Lighting2D.materials.GetSpriteShadow();
            material.color = Color.black;

            foreach(DayLightColliderShape shape in id.shapes) {
                SpriteRenderer spriteRenderer = shape.spriteShape.GetSpriteRenderer();
                if (spriteRenderer == null) {
                    continue;
                }
                
                virtualSpriteRenderer.sprite = spriteRenderer.sprite;
                virtualSpriteRenderer.flipX = spriteRenderer.flipX;
                virtualSpriteRenderer.flipY = spriteRenderer.flipY;

                Sprite sprite = virtualSpriteRenderer.sprite;

                if (virtualSpriteRenderer.sprite == null) {
                    continue;
                }
            
                float sunHeight = Lighting2D.DayLightingSettings.height;
                float rot = Lighting2D.DayLightingSettings.direction * Mathf.Deg2Rad;
     
                Vector2 pos = new Vector2(id.transform.position.x + offset.x, id.transform.position.y + offset.y);
                Vector2 scale = new Vector2(id.transform.lossyScale.x, id.transform.lossyScale.y);

                SpriteTransform spriteTransform = new SpriteTransform(virtualSpriteRenderer, pos, scale, id.transform.rotation.eulerAngles.z);

                Rect uv = spriteTransform.uv;
    
                float pivotY = (float)sprite.pivot.y / sprite.texture.height;
                pivotY = uv.y + pivotY;

                float pivotX = (float)sprite.pivot.x / sprite.texture.width;
                
             
                Pair2 pair = Pair2.Zero();
               	pair.A = pos + pair.A.Push(-rot + Mathf.PI / 2, id.shadowThickness);
                pair.B = pos + pair.B.Push(-rot - Mathf.PI / 2, id.shadowThickness);

                if (Lighting2D.DayLightingSettings.direction < 180) {
                    float uvx = uv.x;
                    uv.x = uv.width;
                    uv.width = uvx;
                }

                Vector2 v1 = pair.A;
                Vector2 v2 = pair.A;
                Vector2 v3 = pair.B;
                Vector2 v4 = pair.B;

                v2 = v2.Push(-rot, id.shadowDistance * sunHeight);
                v3 = v3.Push(-rot, id.shadowDistance * sunHeight);

                material.mainTexture = virtualSpriteRenderer.sprite.texture;
        
                material.SetPass (0); 
        
                GL.Begin (GL.QUADS);

                GL.Color(GLExtended.color);

                GL.TexCoord3 (uv.x, pivotY, 0);
                GL.Vertex3 (v1.x, v1.y, 0);

                GL.TexCoord3 (uv.x, uv.height, 0);
                GL.Vertex3 (v2.x, v2.y, 0);

                GL.TexCoord3 (uv.width, uv.height, 0);
                GL.Vertex3 (v3.x, v3.y, 0);

                GL.TexCoord3 (uv.width, pivotY, 0);
                GL.Vertex3 (v4.x, v4.y, 0);

                GL.End ();
            }

            material.color = Color.white;
        }
    }
}