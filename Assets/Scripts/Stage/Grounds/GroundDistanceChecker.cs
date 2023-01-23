using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �X�e�[�W���m�̍ŒZ�������v������
public class GroundDistanceChecker : MonoBehaviour
{
    Ground ground;
    Rigidbody2D rb;
    LineRenderer line;

    float distance;
    [SerializeField] float maxDist = 2.5f;

    /* �v���p�e�B */
    public float Distance => distance;

//-------------------------------------------------------------------
    void Awake()
    {
        ground=GetComponent<Ground>();
        rb = GetComponent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();

        line.positionCount = 2;
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

//-------------------------------------------------------------------
    void CheckDistance()
	{
        if (ground.PrevStage) {
            var dist = rb.Distance(ground.PrevStage?.Col);       // �ŒZ����
            distance = dist.distance;

#if UNITY_EDITOR
            // ���`��
            line.SetPosition(0, dist.pointA);
            line.SetPosition(1, dist.pointB);
#endif

            SetStagePosition();
        }
    }

    // �ʒu�̒���
    void SetStagePosition()
    {
        // ����������A�����Ɉړ�
        if (distance > maxDist) {
            transform.position = new Vector2(0, transform.position.y - 0.1f);
            transform.rotation = Quaternion.identity;
        }
    }
}
