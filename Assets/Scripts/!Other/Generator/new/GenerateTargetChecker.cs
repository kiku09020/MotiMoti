using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GenerateTargetChecker : MonoBehaviour
{
    [SerializeField] GameObject targetObj;      // 対象のオブジェクト

    public GameObject TargetObj => targetObj;

    //-------------------------------------------------------------------
    /// <summary>
    /// ターゲットとの距離以内かどうかをチェック
    /// </summary>
    public bool CheckTargetWithinDistance(float targetDistance ,Vector2 generatedPos, bool isAxis = false)
    {
        // 距離以内だったらtrue
        if (GetDistance(generatedPos,isAxis) < targetDistance) {
            return true;
        }

        return false;
    }

    /// <summary>
    ///  ターゲットとの距離以上かどうか
    /// </summary>
    public bool CheckTargetOverDistance(float targetDistance, Vector2 generatedPos, bool isAxis = false)
    {
        // 超えてるか
        if (GetDistance(generatedPos,isAxis) >= targetDistance) {
            return true;
        }

        return false;
    }

    // 距離取得
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
