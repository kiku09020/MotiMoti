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
	public void ZoomIn(GameObject target, float duration = 0.5f, float targetZoomSize = 3,Ease easeType = Ease.Unset)
	{
		transform.DOMove(target.transform.position, duration).SetEase(easeType);			// オブジェクトの位置に移動
		zoomingCamera.DOOrthoSize(targetZoomSize, duration).SetEase(easeType);				// サイズ変更
	}

	// ズームアウト
	public void ZoomOut(float duration = 0.5f, float targetZoomSize = 3, Ease easeType = Ease.Unset)
    {
		transform.DOMove(Vector2.zero, duration).SetEase(easeType);
		zoomingCamera.DOOrthoSize(targetZoomSize, duration).SetEase(easeType);
    }

	// ズームイン、ズームアウト
	public void ZoomInOut(GameObject target, float inDuration = 0.5f, float outDuration = 0.5f, 
						  float targetZoomSize = 3, Ease easeType = Ease.Unset)
	{
		var size = zoomingCamera.orthographicSize;		// 呼び出し時のカメラのサイズ

							// ズームイン
		DOTween.Sequence()	.Append(transform.DOMove(target.transform.position, inDuration))
							.Join(zoomingCamera.DOOrthoSize(targetZoomSize, inDuration))

							// ズームアウト
							.Append(transform.DOMove(Vector2.zero, outDuration))
							.Join(zoomingCamera.DOOrthoSize(size, outDuration))

							.SetEase(easeType);
	}
}
