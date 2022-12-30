using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    static public CameraController instance;		// 簡易的なシングルトンパターン用のインスタンス

    [Header("Camera")]
    [SerializeField] float moveTime;        // カメラの移動時間
    [SerializeField] Ease easeType;         // イージングのタイプ

	//-------------------------------------------------------------------
	private void Awake()
	{
		if (instance) {
			Destroy(gameObject);
		}
		else {
			instance = this;
		}
	}

	public void MoveCamera(GameObject obj)
	{
        transform.DOMoveY(obj.transform.position.y, moveTime).SetEase(easeType);
    }

}
