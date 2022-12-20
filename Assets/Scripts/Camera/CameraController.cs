using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    /* 値 */
    [Header("Object")]
    [SerializeField] GameObject moti;

    [Header("Camera")]
    [SerializeField] float moveTime;        // カメラの移動時間
    [SerializeField] Ease easeType;         // イージングのタイプ

    /* コンポーネント取得用 */



//-------------------------------------------------------------------
    void Start()
    {
	/* オブジェクト取得 */ 


	/* コンポーネント取得 */     


        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        transform.DOMoveY(moti.transform.position.y,moveTime).SetEase(easeType);
    }

//-------------------------------------------------------------------

}
