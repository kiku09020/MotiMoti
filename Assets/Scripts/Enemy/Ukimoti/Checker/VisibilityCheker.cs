using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 視界に入ったかどうか
namespace Ukimoti {
    public class VisibilityCheker : HitCheckerTrigger {
        public Vector2 TargetPos { get; private set; }

        List<Collider2D> collisionList = new List<Collider2D>();        // 触れたもののリスト

        protected override void HitEnter(Collider2D collision)
        {
            collisionList.Add(collision);       // リストに追加
        }

        protected override void HitStay(Collider2D collision)
        {
            var nearlyDist = 10f;

            // ターゲット2ついたら、近い方を狙う
            foreach(var col in collisionList) {
                var targetPos   = col.gameObject.transform.position;
                var vec         = targetPos - transform.position;
                var dist        = vec.magnitude;        // 距離

                // 一番近いのと比較して、目的地代入
                if (dist < nearlyDist) {
                    nearlyDist = dist;
                    TargetPos = targetPos;
                }
            }
        }

        protected override void HitExit(Collider2D collision)
        {
            collisionList.Remove(collision);    // リストから除去
        }
    }
}