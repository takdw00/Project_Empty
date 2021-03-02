using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private Character characterRef;


    //���� ����
    [SerializeField] protected float weaponDamage; // ���� ���ݷ�
    [SerializeField] protected float weaponSpeed; // ���� ���� �ӵ�




    #region Properties
    //ĳ����
    protected Character CharacterRef { get { return characterRef; } private set { } }

    //���� ����
    public float WeaponSpeed { get { return weaponSpeed; } set { weaponSpeed = value; } }

    #endregion


    //������ �ش� ������ �ִϸ��̼� ��Ʈ�ѷ�
    private void Start()
    {
        characterRef = transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.GetComponent<Character>();
    }

    abstract public void Attack();
}
