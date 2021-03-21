using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private Character characterRef;


    //���� ����
    [SerializeField] protected float weaponDamage; // ���� ���ݷ�
    [SerializeField] protected float weaponSpeed; // ���� ���� �ӵ�

    //���� ����Ʈ ������Ʈ
    [SerializeField] protected Effect weaponEffect;


    //���� �ִϸ��̼� ��Ʈ�ѷ�
    protected Animator myAnimator;

    //��ü ���� �ִ� ��Ʈ�ѷ�
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
    //ĳ����
    public Character CharacterRef { get { return characterRef; }  set { } }

    //���� ����
    public float WeaponSpeed { get { return weaponSpeed; } set { weaponSpeed = value; } }
    public Effect WeaponEffect { get { return weaponEffect; } set { }  }


    #endregion


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    //������ �ش� ������ �ִϸ��̼� ��Ʈ�ѷ�
    private void Start()
    {

        characterRef = transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.GetComponent<Character>();

        //weaponEffect = transform.Find("Weapon_Effect").gameObject.GetComponent<Effect>();
        
        //if(gameObject.name=="Long_Sword")
        //{
        //    Debug.Log("stop");
        //}
    }

    public void StateAction(RuntimeAnimatorController animatorController, Vector3 direction, float actionSpeed)
    {
        myAnimator.runtimeAnimatorController = animatorController;
        myAnimator.SetFloat("Direction_X", direction.x);
        myAnimator.SetFloat("Direction_Y", direction.y);
        myAnimator.speed = actionSpeed;
    }

    //public void StateAction(RuntimeAnimatorController animatorController, float animationNumber, float actionSpeed)
    //{
    //    myAnimator.runtimeAnimatorController = animatorController;

    //    myAnimator.SetFloat("Direction_X", animationNumber);
    //    myAnimator.speed = actionSpeed;
    //}

}
