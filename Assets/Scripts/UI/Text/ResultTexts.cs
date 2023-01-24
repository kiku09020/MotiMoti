using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTexts : SimpleSingleton<ResultTexts>
{
    [SerializeField] Text distanceText;
    [SerializeField] Text highScoreText;

    //-------------------------------------------------------------------
    public void SetText()
    {
        var intDist = (int)MotiDistanceManager.Distance;
        distanceText.text = intDist.ToString("N0") + "m";

        highScoreText.text = DataManager.Instance.data.highScore.ToString("N0") + "m";
    }
}
