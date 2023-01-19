using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitCheckerBase : MonoBehaviour {

    [SerializeField] protected Collider2D _collider;                     // enable指定用

    [SerializeField] protected LayerMask targetLayer;                    // layer
    [SerializeField] protected string targetTag;                         // tag
    
    protected bool isTrigger;                           // triggerかどうか

    /* プロパティ */
    public bool IsHit { get; protected set; }           // 判定
    public bool ColEnabled { get => _collider.enabled; set => _collider.enabled = value; }      // enabled

    /* Editor用プロパティ */
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