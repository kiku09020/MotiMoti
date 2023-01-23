using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ステージ同士の最短距離を計測する
public class GroundDistanceChecker : MonoBehaviour
{
    Ground ground;
    Rigidbody2D rb;
    LineRenderer line;

    float distance;
    [SerializeField] float maxDist = 2.5f;

    /* プロパティ */
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
            var dist = rb.Distance(ground.PrevStage?.Col);       // 最短距離
            distance = dist.distance;

#if UNITY_EDITOR
            // 線描画
            line.SetPosition(0, dist.pointA);
            line.SetPosition(1, dist.pointB);
#endif

            SetStagePosition();
        }
    }

    // 位置の調整
    void SetStagePosition()
    {
        // 遠かったら、中央に移動
        if (distance > maxDist) {
            transform.position = new Vector2(0, transform.position.y - 0.1f);
            transform.rotation = Quaternion.identity;
        }
    }
}
