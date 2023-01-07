using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDestroyer : MonoBehaviour
{
    [SerializeField] float destroyDist;     // もちからの距離


    Moti.MotiController moti;

//-------------------------------------------------------------------
    void Awake()
    {
        moti = GameObject.Find("Moti").GetComponent<Moti.MotiController>();
    }

    void FixedUpdate()
    {
        if (!GameManager.isResult) {
            CheckDestroy();
        }
    }

//-------------------------------------------------------------------
    // 削除
    void CheckDestroy()
	{
        var motiPos = moti.transform.position;

        // ステージの位置が指定より小さかったら削除
        DistanceCaluculator.CheckOverDistance(transform.position.y, (motiPos.y - destroyDist), DestroyObject);
	}

	private void DestroyObject()
	{
        Destroy(gameObject);
	}
}
