using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    //��ȣ�ۿ� ������ ��� ������Ʈ
    //ex)ĳ����, �ı� ������ ������Ʈ, ��ȣ�ۿ��� ���� �̺�Ʈ�� �ִ� ������Ʈ

    #region Status enabled or not
    private bool isDeath;
    private bool isHit;
    #endregion


    #region Properties
    public bool IsDeath { get { return isDeath; } set { isDeath = value; } }

    public bool IsHit { get { return isHit; } set { isHit = value; } }
    #endregion
}
