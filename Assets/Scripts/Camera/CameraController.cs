using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : Singleton<CameraController>
{
	[Header("Camera")]
	[SerializeField] Camera zoomingCamera;  // ズームするカメラ
	[SerializeField] float offset;

	//-------------------------------------------------------------------
	private void Awake()
	{

	}

	//-------------------------------------------------------------------
	// 追尾
	public void Chase(Moti.MotiController moti, float duration = 1, Ease easeType = Ease.Unset)
    {
		var position = Vector2.zero;

        if (moti.Family.IsSingle) {
			position = moti.transform.position;
        }

        else {
			position = Vector2.Lerp(moti.transform.position, moti.Family.OtherMoti.transform.position, 0.5f);
        }
		transform.DOMoveY(position.y + offset, duration).SetEase(easeType);

	}

	//-------------------------------------------------------------------
	// ズーム
	public void ZoomIn(GameObject target, float duration = 0.5f, float targetZoomSize = 3,Ease easeType = Ease.Unset)
	{
		DOTween.Sequence()	.Append(transform.DOMove(target.transform.position, duration))		// オブジェクトの位置に移動
							.Join(zoomingCamera.DOOrthoSize(targetZoomSize, duration))			// サイズ変更
							.SetUpdate(true).SetEase(easeType);			
	}

	// ズームアウト
	public void ZoomOut(GameObject target, float duration = 0.5f, float targetZoomSize = 3, Ease easeType = Ease.Unset)
    {
		transform.DOMove(target.transform.position, duration).SetEase(easeType);
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
