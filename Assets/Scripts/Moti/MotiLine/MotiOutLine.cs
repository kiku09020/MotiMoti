using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiOutLine : MonoBehaviour
{
    LineRenderer outLine;
    Moti.MotiLineController mainLine;

    Vector3[] positions = new Vector3[2];
//-------------------------------------------------------------------
    void Awake()
    {
        outLine = GetComponent<LineRenderer>();
        mainLine = transform.parent.GetComponent<Moti.MotiLineController>();

        outLine.positionCount = 2;
        outLine.numCapVertices = 10;
    }

    void LateUpdate()
    {
        positions = mainLine.Positions;                         // êeÇ∆ìØólÇÃì_
        outLine.widthMultiplier = mainLine.Width + 0.1f;        // ëæÇ≥

        outLine.SetPositions(positions);
    }

//-------------------------------------------------------------------

}
