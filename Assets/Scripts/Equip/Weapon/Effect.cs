using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private Character characterRef;
    private Weapon weaponRef;

    //����Ʈ �ִϸ��̼� ��Ʈ�ѷ�
    protected Animator myAnimator;

    //��ü ����Ʈ �ִ� ��Ʈ�ѷ�
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
    protected Weapon WeaponRef { get { return weaponRef; } private set { } }

    #endregion

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    private void Start()
    {

        weaponRef = transform.parent.GetComponent<Weapon>();
        characterRef = transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.GetComponent<Character>();
        if(characterRef==null)
        Debug.Log("stop");
    }

    public void StateEffect(RuntimeAnimatorController animatorController, Vector3 direction, float actionSpeed)
    {
        if(!(animatorController==null))
        {
            myAnimator.runtimeAnimatorController = animatorController;
        }
        else
        {
            myAnimator.runtimeAnimatorController = AinmationController_Battle_Idle;
        }
        myAnimator.SetFloat("Direction_X", direction.x);
        myAnimator.SetFloat("Direction_Y", direction.y);
        myAnimator.speed = actionSpeed;

    }
}
