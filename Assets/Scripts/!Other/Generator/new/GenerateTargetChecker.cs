using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GenerateTargetChecker : MonoBehaviour
{
    [SerializeField] GameObject targetObj;      // �Ώۂ̃I�u�W�F�N�g

    public GameObject TargetObj => targetObj;

    //-------------------------------------------------------------------
    /// <summary>
    /// �^�[�Q�b�g�Ƃ̋����ȓ����ǂ������`�F�b�N
    /// </summary>
    public bool CheckTargetWithinDistance(float targetDistance ,Vector2 generatedPos, bool isAxis = false)
    {
        // �����ȓ���������true
        if (GetDistance(generatedPos,isAxis) < targetDistance) {
            return true;
        }

        return false;
    }

    /// <summary>
    ///  �^�[�Q�b�g�Ƃ̋����ȏォ�ǂ���
    /// </summary>
    public bool CheckTargetOverDistance(float targetDistance, Vector2 generatedPos, bool isAxis = false)
    {
        // �����Ă邩
        if (GetDistance(generatedPos,isAxis) >= targetDistance) {
            return true;
        }

        return false;
    }

    // �����擾
    float GetDistance(Vector2 position,bool isAxis)
    {
        var dist = 0f;

        if (isAxis) {
            dist = DistanceCaluculator.CheckAxisDistance(targetObj.transform.position.y, position.y);
        }

        else {
            dist = DistanceCaluculator.CheckDistance(targetObj.transform.position, position);
        }

        return dist;
    }
}
