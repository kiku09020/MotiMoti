using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �X�e�[�W���m�̍ŒZ�������v������
public class CheckStageDistance : MonoBehaviour
{
    Stage stage;
    Rigidbody2D rb;
    LineRenderer line;

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
        if (stage.PrevStage != null) {
            var dist = rb.Distance(stage.PrevStage?.Col);

            line.SetPosition(0, dist.pointA);
            line.SetPosition(1, dist.pointB);
        }
    }

//-------------------------------------------------------------------

}
