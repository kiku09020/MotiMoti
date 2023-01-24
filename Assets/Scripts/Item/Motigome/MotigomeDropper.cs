using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotigomeDropper : MonoBehaviour
{
    static Transform parent;
    public static GameObject Motigome { get; private set; }

    static MotigomeDropper()
    {
        Motigome = (GameObject)Resources.Load("Prefabs/DroppedMotigome");
    }

    public static void SetParent()
    {
        if (!parent) {
            var par = GameObject.Find("Motigomes");
            parent = par.transform;
        }
    }

    // ”‚ğƒ‰ƒ“ƒ_ƒ€w’è
    public static int SetMotigomeCnt(int refValue,int randomRange)
    {
        var min = refValue - randomRange;
        var max = refValue + randomRange + 1;

        return Random.Range(min, max);
    }

    // ¶¬
    public static void Drop(int count,Vector2 position)
    {
        var obj = new GameObject("DroppedGroup");
        obj.transform.position = position;
        obj.transform.parent = parent;

        for(int i = 0; i < count; ++i) {
            var pos = 0.1f * Random.insideUnitCircle + position;

            var inst = Instantiate(Motigome, pos, Quaternion.identity, obj.transform);
            var comp = inst.GetComponent<Motigome.Motigome>();
            comp.Dropped();
        }
    }
}
