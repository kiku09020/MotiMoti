using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Data;

public class ResultTexts : SimpleSingleton<ResultTexts>
{
    [SerializeField] Text distanceText;
    [SerializeField] Text highScoreText;

    //-------------------------------------------------------------------
    public void SetText()
    {
        var intDist = (int)MotiDistanceManager.Distance;
        distanceText.text = intDist.ToString("N0") + "m";

        highScoreText.text = SaveDataManager.Instance.datainfo.highScore.ToString("N0") + "m";
    }
}
