using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : Singleton<CameraController>
{
	[Header("Camera")]
	[SerializeField] Camera zoomingCamera;	// ズームするカメラ

	//-------------------------------------------------------------------
	private void Awake()
	{

	}

	//-------------------------------------------------------------------
	// 追尾
	public void Chase(GameObject target, float duration = 1, Ease easeType = Ease.Unset)
    {
		transform.DOMoveY(target.transform.position.y, duration).SetEase(easeType);
	}

	//-------------------------------------------------------------------
	// ズーム
	public void Zoom(GameObject target, float duration = 0.5f, float targetZoomSize = 3,Ease easeType = Ease.Unset)
	{
		transform.DOMove(target.transform.position, duration).SetEase(easeType);			// オブジェクトの位置に移動
		zoomingCamera.DOOrthoSize(targetZoomSize, duration).SetEase(easeType);				// サイズ変更
	}

	//-------------------------------------------------------------------
	// ズームアウト
	public void ZoomOut(GameObject target, float duration = 0.5f, float targetZoomSize = 3, Ease easeType = Ease.Unset)
    {
		transform.DOMove(target.transform.position, duration).SetEase(easeType);
		zoomingCamera.DOOrthoSize(targetZoomSize, duration).SetEase(easeType);
    }
}
