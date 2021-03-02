using UnityEngine;

public abstract class State : MonoBehaviour
{
    private Character characterRef;
    protected Character CharacterRef { get { return characterRef; } private set { } }

    //캐릭터의 해당 상태 애니메이션 컨트롤러
    [SerializeField] protected RuntimeAnimatorController characterState_AnimatorController;



    public RuntimeAnimatorController CharacterState_AnimatorController { get { return characterState_AnimatorController; } }

    protected virtual void Awake()
    {
        characterRef = GetComponent<Character>();
    }

    public abstract void Execution();

    public abstract void Animation();

    //protected RuntimeAnimatorController AnimationController(Vector3 direction)
    //{
    //    //Animation cAni;
    //    //cAni = CharacterRef.gameObject.GetComponent<Animation>();

    //    if (direction.x == 0 && direction.y < 0) // Down
    //    {
    //        return d;
    //    }
    //    else if (direction.x < 0 && direction.y < 0) // Left Down
    //    {
    //        return ld;
    //    }
    //    else if (direction.x < 0 && direction.y > 0) // Left Up
    //    {
    //        return lu;
    //    }
    //    else if (direction.x > 0 && direction.y < 0) // Right Down
    //    {
    //        return rd;
    //    }
    //    else if (direction.x > 0 && direction.y > 0) // Right Up
    //    {
    //        return ru;
    //    }
    //    else if (direction.x == 0 && direction.y > 0) // Up
    //    {
    //        return u;
    //    }
    //    return null;
    //}
}
