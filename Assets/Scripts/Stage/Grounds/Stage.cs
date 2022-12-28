using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    /* フィールド */
    Stage prevStage;        // 1つ前のステージ


    /* コンポーネント */
    Collider2D col;

    /* プロパティ */
    public Stage PrevStage  { get => prevStage;   set => prevStage ??= value; }
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
