using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    /* �t�B�[���h */
    Stage prevStage;        // 1�O�̃X�e�[�W


    /* �R���|�[�l���g */
    Collider2D col;

    /* �v���p�e�B */
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
