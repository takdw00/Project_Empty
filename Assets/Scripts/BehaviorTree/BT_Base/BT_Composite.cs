using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Composite

���� ���� �ϳ� �̻��� �ڽ��� ���� �� �ִ� ���
�ڽ� ��� �� �ϳ� �̻��� ������ Ư�� ���� ��忡 ���� ù ��°���� ������ ������ �Ǵ� ������ ������ ó����
� �ܰ迡���� ó�� �ϷḦ ����ϰ� ���� �ڽ� ����� ���и� �θ� ��忡�� ���� �Ǵ� ���� �� �ϳ��� �����Ѵ�.
�θ� ��尡 �ڽ� ����� ����� ó���ϴ� ���� �ڽ� ���� ����ؼ� �θ� Running�� ��ȯ�Ѵ�.
�Ϲ������� ���Ǵ� ���� ���� Sequence
Sequence�� �� �ڽ� ��带 ������� �����ϸ�, �ڽ� ��� �� �� ���� �����ϴ� �������� failure�� ��ȯ�ϰ� ��� �ڽ� ��尡 Success�� ��ȯ�ϸ� �θ� ��忡�� Success�� ��ȯ�Ѵ�.
 */

public abstract class BT_Composite : BT_Node
{
    List<BT_Node> childNodeList = new List<BT_Node>();
    protected List<BT_Node> GetChildNode() { return childNodeList; }
    public void AddChildNode(BT_Node node)
    {
        childNodeList.Add(node);
    }
}
