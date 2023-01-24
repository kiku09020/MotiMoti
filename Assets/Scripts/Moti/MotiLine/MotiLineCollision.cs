using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class MotiLineCollision : MonoBehaviour
    {
        [SerializeField] LayerMask stageHitLayer;        // ステージのみに当たり判定チェックする

        MotiController moti;

        /* プロパティ */
        public bool IsHit { get; private set; }
        public Vector2 HitPoint { get; private set; }

        private void Start()
        {
            moti = transform.parent.GetComponent<MotiController>();
        }

        public bool Ray(Vector3 originPos, Vector3 targetPos)
        {
            if (moti.Family.OtherMoti ) {
                var vec = targetPos - originPos ;
                var ray = new Ray2D(originPos, vec);

                Debug.DrawLine(originPos, targetPos,Color.yellow);
                var hit = Physics2D.Raycast(ray.origin, ray.direction, vec.magnitude, stageHitLayer);

                if (hit) {
                    Hit(hit);
                    return true;
                }

                else {
                    IsHit = false;
                    HitPoint = originPos;
                }
            }

            return false;
        }

        void Hit(RaycastHit2D hit)
        {
            if (!IsHit) {
                HitPoint = hit.point;
            }

            IsHit = true;
        }
    }
}