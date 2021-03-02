using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private Character characterRef;


    //���� ����
    [SerializeField] protected float weaponDamage; // ���� ���ݷ�
    [SerializeField] protected float weaponSpeed; // ���� ���� �ӵ�




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
    protected Character CharacterRef { get { return characterRef; } private set { } }

    //���� ����
    public float WeaponSpeed { get { return weaponSpeed; } set { weaponSpeed = value; } }

    #endregion


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    //������ �ش� ������ �ִϸ��̼� ��Ʈ�ѷ�
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
