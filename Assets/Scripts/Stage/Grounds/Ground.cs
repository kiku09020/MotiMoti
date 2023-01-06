using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    /* フィールド */
    Ground prevStage;        // 1つ前のステージ


    /* コンポーネント */
    Collider2D col;

    /* プロパティ */
    public Ground PrevStage  { get => prevStage;   set => prevStage ??= value; }
    public Collider2D Col => col;

//-------------------------------------------------------------------
    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        
    }

//-------------------------------------------------------------------

}
