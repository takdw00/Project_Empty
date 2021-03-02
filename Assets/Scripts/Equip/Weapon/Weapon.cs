using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private Character characterRef;


    //무기 정보
    [SerializeField] protected float weaponDamage; // 무기 공격력
    [SerializeField] protected float weaponSpeed; // 무기 공격 속도




    #region Properties
    //캐릭터
    protected Character CharacterRef { get { return characterRef; } private set { } }

    //무기 정보
    public float WeaponSpeed { get { return weaponSpeed; } set { weaponSpeed = value; } }

    #endregion


    //무기의 해당 상태의 애니메이션 컨트롤러
    private void Start()
    {
        characterRef = transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.GetComponent<Character>();
    }

    abstract public void Attack();
}
