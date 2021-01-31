using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Sequence

�ڽ� ��带 ������� �����ϱ� ���� ���
�򰡸� �����ϸ� sequence�� �ڽ� ��带 ���ʿ��� ������(�켱���� ���� �ʿ��� ���� ��)�� ������ ���� �켱 Ž�� ������� ���Ѵ�.
Sequence�� �ڽ� ��� �� �ϳ��� failure�� running�� ��ȯ�ϸ� selector�� ��� failure�� running�� �θ� ��忡 ��ȯ�Ѵ�.
Selector�� ��� �ڽ� ��尡 success�� ��ȯ���� ���� selector�� �θ� ��忡 success�� ��ȯ�Ѵ�.
������ ���Ǻ� �˻縦 �����ϰ� �Ѵ�.
AND ����Ʈ�� �����ϴ�.
Invert�� �̿��Ͽ� NOT ����Ʈ�� �̿� �����ϴ�.
Sequence�� �̿��Ͽ� ĳ���ͳ� ���� ������ ������ �׽�Ʈ�ϴ� �� �ʿ��� ��� ���� ���� ���� �� �ִ�.
 */
public class BT_Sequence : BT_Composite
{
    public override bool Run()
    {
        foreach (var node in GetChildNode())
        {
            if (!node.Run())
            {
                return false;
            }
        }
        return true;
    }
}
