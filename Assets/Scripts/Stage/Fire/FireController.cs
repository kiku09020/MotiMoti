using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FireController : SimpleSingleton<FireController>
{
    [Header("Start")]
    [SerializeField] int startMovableDist;  // 動けるようになる距離

    [Header("Always")]
    [SerializeField] float speed;           // 移動速度
    [SerializeField] float speedUpValue;    // 速度上昇値

    [Header("United")]
    [SerializeField] float moveTime;        // 移動時間
    [SerializeField] float minDist;         // もちとの最低距離

    public bool isEnable;                   // 有効

//-------------------------------------------------------------------
    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        SetStartMovable();

		if (isEnable) {
            MoveUp();
		}
    }

    // 有効・無効の切り替え
    public void SetEnable()
    {
        isEnable = !isEnable;
    }

    public void SetEnable(bool enable)
    {
        isEnable = enable;
    }

//-------------------------------------------------------------------
    // United時の移動
    public void UnitedMove(Moti.MotiController targetMoti)
    {
        var motiPosY = targetMoti.transform.position.y;
        var dist = Mathf.Abs(DistanceCaluculator.CheckAxisLength(transform.position.y, motiPosY));

        var unitedPosY = motiPosY;      // 現在の位置を保存

        // 移動
        if (minDist < dist) {
            var targetPosY = unitedPosY - minDist;
            transform.DOMoveY(targetPosY, moveTime);
        }
    }

    // 上の方に移動
    void MoveUp()
	{
        transform.position += new Vector3(0, speed, 0);
	}

    // 速度上昇
    public void SpeedUp()
	{
        speed += speedUpValue;
	}

    // 指定の高さ以上で火が有効になる
    void SetStartMovable()
    {
        // 指定高さを超えたら動く
        if (startMovableDist < MotiDistanceManager.Distance) {
            isEnable = true;
        }
    }
}
