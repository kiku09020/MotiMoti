using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistText : MonoBehaviour
{
    [SerializeField] Moti.MotiController moti;

    Text text;

//-------------------------------------------------------------------
    void Awake()
    {
        text = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        var motiPos = moti.transform.position;
        var dist = DistanceCaluculator.CheckAxisLength(motiPos.y, 0);

        text.text = dist.ToString("N0") + "m";
    }

//-------------------------------------------------------------------

}
