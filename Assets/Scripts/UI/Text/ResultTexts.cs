using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTexts : Singleton<ResultTexts>
{
    [SerializeField] Text distanceText;
    [SerializeField] Text highScoreText;

    //-------------------------------------------------------------------
    public void SetText()
    {
        var intDist = (int)MotiDistanceManager.Distance;
        distanceText.text = intDist.ToString("N0") + "m";

        highScoreText.text = DataManager.data.highScore.ToString("N0") + "m";
    }
}
