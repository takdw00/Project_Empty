using UnityEngine;

public abstract class State : MonoBehaviour
{
    private Character characterRef;
    protected Character CharacterRef { get { return characterRef; } private set { } }

    protected virtual void Awake()
    {
        characterRef = GetComponent<Character>();
    }

    public abstract void Execution();
}
