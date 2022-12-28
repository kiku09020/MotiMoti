using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis
{
    x,y
}

public class DistanceCaluculator : MonoBehaviour
{
    /* �����𒲂ׂ� */
    // GameObject���狁�߂�
    static public float CheckObjectDistance(GameObject fromObject, GameObject toObject)
	{
        var fromPoint = fromObject.transform.position;
        var toPoint = toObject.transform.position;

        Debug.DrawLine(fromPoint, toPoint);             // ����`��
        return Vector2.Distance(fromPoint, toPoint);
	}

    // �x�N�g�����狁�߂�
    static public float CheckPointDistance(Vector2 fromPoint, Vector2 toPoint)
	{
        Debug.DrawLine(fromPoint, toPoint);
        return Vector2.Distance(fromPoint, toPoint);
	}



    /* ���̒��������߂� */
    // float���璷�������߂�
    static public float CheckAxisLength(float from, float to)
	{
        var dist = Mathf.Abs(to - from);

        print($"dist = {dist}");
        return dist;
	}

    // �x�N�g�����玲�̒��������߂�
    static public float CheckAxisLength(Vector2 fromPoint, Vector2 toPoint, Axis axis)
    {
        var from = 0f; var to = 0f;

        switch (axis) {
            case Axis.x:
                from = fromPoint.x;     to = toPoint.x;
                break;

            case Axis.y:
                from = fromPoint.y;     to = toPoint.y;
                break;
		}
        
        var dist = Mathf.Abs(to - from);

        print($"dist = {dist}");
        return dist;
    }

    /* �p�x�𒲂ׂ� */

}
