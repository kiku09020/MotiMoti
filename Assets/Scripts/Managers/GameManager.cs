using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* 値 */


    /* コンポーネント取得用 */
    BGM bgm;

    /* プロパティ */
    static public bool GameOver    { get; set; }
    


//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject audObj = transform.Find("AudioManager").gameObject;

        /* コンポーネント取得 */
        bgm = audObj.GetComponent<BGM>();

        /* 初期化 */
        bgm.Play((int)BGM.AudioName.bgm2);
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        
    }

//-------------------------------------------------------------------

}
