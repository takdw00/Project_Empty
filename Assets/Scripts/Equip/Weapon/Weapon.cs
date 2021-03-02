using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private Character characterRef;


    //무기 정보
    [SerializeField] protected float weaponDamage; // 무기 공격력
    [SerializeField] protected float weaponSpeed; // 무기 공격 속도




    //무기 애니메이션 컨트롤러
    protected Animator myAnimator;

    //교체 무기 애니 컨트롤러
    public RuntimeAnimatorController AinmationController_Battle_Idle;
    public RuntimeAnimatorController AinmationController_Battle_Ready;
    public RuntimeAnimatorController AinmationController_Battle_Run;
    public RuntimeAnimatorController AinmationController_Battle_Walk;
    public RuntimeAnimatorController AinmationController_Attack;
    public RuntimeAnimatorController AinmationController_Dodge;
    public RuntimeAnimatorController AinmationController_Guard;
    public RuntimeAnimatorController AinmationController_Pary;
    public RuntimeAnimatorController AinmationController_Hit;



    #region Properties
    //캐릭터
    protected Character CharacterRef { get { return characterRef; } private set { } }

    //무기 정보
    public float WeaponSpeed { get { return weaponSpeed; } set { weaponSpeed = value; } }

    #endregion


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    //무기의 해당 상태의 애니메이션 컨트롤러
    private void Start()
    {
        characterRef = transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.GetComponent<Character>();
    }

    public void StateAction(RuntimeAnimatorController animatorController, Vector3 direction, float actionSpeed) //2
    {
        myAnimator.runtimeAnimatorController = animatorController;
        myAnimator.SetFloat("Direction_X", direction.x);
        myAnimator.SetFloat("Direction_Y", direction.y);
        myAnimator.speed = actionSpeed;
    }


}
