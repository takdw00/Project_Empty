using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Selector

�ڽ� ��� ��� �ϳ��� �����ϱ� ���� ���
�򰡸� �����ϸ� selector�� �ڽ� ��带 ���ʿ��� ������(�켱���� ���� �ʿ��� ���� ��)�� ������ ���� �켱 Ž�� ������� ���Ѵ�.
Selector�� �ڽ� ��� �� �ϳ��� success�� running�� ��ȯ�ϸ�, selector�� ��� success�� running�� �θ� ��忡 ��ȯ�Ѵ�.
Selector�� ��� �ڽ� ��尡 failure�� ��ȯ���� ���� selector�� �θ� ��忡 failure�� ��ȯ�Ѵ�.
 */
public class BT_Selector : BT_Composite
{
    public override bool Run()
    {
        foreach(var node in GetChildNode())
        {
            if(node.Run())
            {
                return true;
            }
        }
        return false;
    }
}
