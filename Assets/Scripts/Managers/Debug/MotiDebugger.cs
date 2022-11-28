using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiDebugger : MonoBehaviour
{
    /* 値 */
    [SerializeField] float boxSize;         // Boxの大きさ

    Moti targetMoti;

    /* コンポーネント取得用 */



//-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */
        targetMoti = GameObject.Find("Moti").GetComponent<Moti>();

        /* 初期化 */

    }

    void FixedUpdate()
    {
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, boxSize, boxSize), "Debug");

    }

    //-------------------------------------------------------------------

}
