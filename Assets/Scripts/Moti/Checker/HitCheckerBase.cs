using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitCheckerBase : MonoBehaviour {

    [SerializeField] protected string targetTagName;      // ���蒲�ׂ�I�u�W�F�N�g�̃^�O��
    [SerializeField] protected Collider2D _collider;

    protected bool isTrigger;

    public bool IsHit { get; protected set; }
    public bool ColEnabled { get => _collider.enabled; set => _collider.enabled = value; }

    //-------------------------------------------------------------------
    protected virtual void Awake()
    {
        isTrigger = _collider.isTrigger;
    }

    public abstract void Init();
}