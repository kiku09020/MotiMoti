using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �X�e�[�W���m�̍ŒZ�������v������
public class StageDistanceChecker : MonoBehaviour
{
    Stage stage;
    Rigidbody2D rb;
    LineRenderer line;

    float distance;
    [SerializeField] float stageMaxDist = 2.5f;

    /* �v���p�e�B */
    public float Distance => distance;

//-------------------------------------------------------------------
    void Awake()
    {
        stage=GetComponent<Stage>();
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
        if (stage.PrevStage) {
            var dist = rb.Distance(stage.PrevStage?.Col);       // �ŒZ����
            distance = dist.distance;

            // ���`��
            line.SetPosition(0, dist.pointA);
            line.SetPosition(1, dist.pointB);

            print(distance);

            SetStagePosition();
        }
    }

    // �ʒu�̒���
    void SetStagePosition()
    {
        // ����������A�����Ɉړ�
        if (distance > stageMaxDist) {
            transform.position = new Vector2(0, transform.position.y);
        }
    }
}
