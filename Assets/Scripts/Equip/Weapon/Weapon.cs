using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private Character characterRef;
    protected Character CharacterRef { get { return characterRef; } private set { } }

    private void Start()
    {
        characterRef = transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.GetComponent<Character>();
    }

    abstract public void Attack();
}
