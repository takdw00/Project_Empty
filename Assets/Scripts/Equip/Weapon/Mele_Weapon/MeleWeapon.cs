using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleWeapon : Weapon
{
    public GameObject hitbox_Down;
    public GameObject hitbox_Left_Down;
    public GameObject hitbox_Left_Up;
    public GameObject hitbox_Right_Down;
    public GameObject hitbox_Right_Up;
    public GameObject hitbox_Up;


    public void Enable_Down_Hitbox()
    {
        hitbox_Down.SetActive(true);
    }
    public void Disable_Down_Hitbox()
    {
        hitbox_Down.SetActive(false);
    }

    public void Enable_LeftDown_Hitbox()
    {
        hitbox_Left_Down.SetActive(true);
    }
    public void Disable_LeftDown_Hitbox()
    {
        hitbox_Left_Down.SetActive(false);
    }

    public void Enable_LeftUp_Hitbox()
    {
        hitbox_Left_Up.SetActive(true);
    }
    public void Disable_LeftUp_Hitbox()
    {
        hitbox_Left_Up.SetActive(false);
    }

    public void Enable_RightDown_Hitbox()
    {
        hitbox_Right_Down.SetActive(true);
    }
    public void Disable_RightDown_Hitbox()
    {
        hitbox_Right_Down.SetActive(false);
    }

    public void Enable_RightUp_Hitbox()
    {
        hitbox_Right_Up.SetActive(true);
    }
    public void Disable_RightUp_Hitbox()
    {
        hitbox_Right_Up.SetActive(false);
    }

    public void Enable_Up_Hitbox()
    {
        hitbox_Up.SetActive(true);
    }
    public void Disable_Up_Hitbox()
    {
        hitbox_Up.SetActive(false);
    }


    public void Enable_HitBox()
    {
        if (CharacterRef.Attack_Direction.x < 0.7 && CharacterRef.Attack_Direction.x > -0.7&& CharacterRef.Attack_Direction.y<0) // Down
        {

        }
        else if (CharacterRef.Attack_Direction.x < 0) //LeftDown
        {

        }
        else if (true)  //LeftUp
        {

        }
        else if (true) //RightDown
        {

        }
        else if (true) //RightUp
        {

        }
        else if (CharacterRef.Attack_Direction.x < 0.7 && CharacterRef.Attack_Direction.x > -0.7 && CharacterRef.Attack_Direction.y > 0) //Up
        {

        }
        else
        {
            return;
        }
    }
}
