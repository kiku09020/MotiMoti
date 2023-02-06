using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SmartToggle))]
public abstract class ToggleActionBase : MonoBehaviour
{
    [SerializeField] protected SmartToggle toggle;

    public abstract void Changed();     // ïœçXÇ≥ÇÍÇΩÇ∆Ç´
}
