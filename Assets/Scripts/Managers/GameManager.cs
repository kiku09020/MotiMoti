using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* 値 */
    bool gameOver;
    bool gameClear;
    bool isPause;

    /* コンポーネント取得用 */


    /* プロパティ */
    public bool GameOver 
    { 
        get => gameOver;
        set { if (gameOver != value) gameOver = value;  }
        }

    public bool GameClear 
    { 
        get => gameClear;
        set { if (gameClear != value) gameClear = value; }
        }

    public bool IsPause
    {
        get => isPause;
        set { if (isPause != value) isPause = value; }
    }


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
        
    }

//-------------------------------------------------------------------

}
