using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 Decorator

Decorator�� �ϳ��� �ڽ� ��常 ���� �� ����
Decorator�� ����� �ڽ� ����� ���·κ��� ���� ����� ������Ű�ų�, �ڽ� ��带 �����Ű�ų�, ��� ��� ������ ���� �ڽ� ����� ó���� �ݺ��ϴ� ���̴�.
������ �����ϸ� �ڽ��� �����ϰ�, ������ �������� ���ϸ� false �� ��ȯ = ���ǹ� ����
Decorator�� �����ϴ� ������ �������� ����� ��ȯ ����� �ڽ��� ��ȯ ����� ������
�Ϲ������� ���Ǵ� invert ���: �ܼ��� �ڽ� ����� ����� �����´�.(!= �ε�) �ڽ� ��尡 �����ϸ� �θ𿡰� ������ �����ְų�, �ڽ� ��尡 �����ؼ� �θ𿡰� ���и� �����ش�.
 */

//Decorate �� ��� ���� Ŭ������ Run�� �����ؾ��Ѵ�.
//Run�� Ư�� ������ ��������Ѵ�.
//Ư�� ������ ���� �� ��� �ڽĳ���� Run�� �����ϵ��� �Ѵ�.

public abstract class BT_Decorate : BT_Node
{
    BT_Node childNode;

    protected BT_Node GetChildNode() { return childNode; }
    public void AddChildNode(BT_Node node)
    {
        childNode = node;
    }


}