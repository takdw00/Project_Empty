using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    Character character;

    private void Start()
    {
        character = transform.GetChild(0).GetComponent<Character>();
    }

    public Character GetCharacter()
    {
        return character;
    }
    public void SetCharacter(Character setcharacter)
    {
        character= setcharacter;
    }

}
