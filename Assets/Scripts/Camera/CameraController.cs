using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : Singleton<CameraController>
{
    [Header("Chase")]
    [SerializeField] float chaseTime;        // カメラの移動時間
    [SerializeField] Ease chaseEaseType;         // イージングのタイプ

	[Header("Zoom")]
	[SerializeField] Camera targetCamera;	// ズームするカメラ
	[SerializeField] float zoomTime;		// ズーム時間
	[SerializeField] Ease zoomEaseType;     // イージング
	[SerializeField] float zoomSize;

	//-------------------------------------------------------------------
	private void Awake()
	{

	}

	// 追尾
	public void ChaseObject(GameObject obj)
	{
        transform.DOMoveY(obj.transform.position.y, chaseTime).SetEase(chaseEaseType);
    }

	// ズーム
	public void ZoomObject(GameObject obj)
	{
		transform.DOMove(obj.transform.position, zoomTime).SetEase(zoomEaseType);       // オブジェクトの位置に移動
		targetCamera.DOOrthoSize(zoomSize, zoomTime);
	}

}
