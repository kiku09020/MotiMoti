using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitCheckerBase : MonoBehaviour {

    [SerializeField] protected Collider2D _collider;                     // enable�w��p

    [SerializeField] protected LayerMask targetLayer;                    // layer
    [SerializeField] protected string targetTag;                         // tag
    
    protected bool isTrigger;                           // trigger���ǂ���

    /* �v���p�e�B */
    public bool IsHit { get; protected set; }           // ����
    public bool ColEnabled { get => _collider.enabled; set => _collider.enabled = value; }      // enabled

    /* Editor�p�v���p�e�B */
    public Collider2D Collider { get => _collider; set => _collider = value; }
    public LayerMask TargetLayer { get => targetLayer; set => targetLayer = value; }
    public string TargetTag { get => targetTag; set => targetTag = value; }
    //-------------------------------------------------------------------
    protected virtual void Awake()
    {
        IsHit = false;
        ColEnabled = true;

        isTrigger = _collider.isTrigger;
    }
}