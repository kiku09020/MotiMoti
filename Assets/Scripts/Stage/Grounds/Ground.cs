using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    /* �t�B�[���h */
    Ground prevStage;        // 1�O�̃X�e�[�W


    /* �R���|�[�l���g */
    Collider2D col;

    /* �v���p�e�B */
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
