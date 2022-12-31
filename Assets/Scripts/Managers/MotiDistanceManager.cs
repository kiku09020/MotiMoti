using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotiDistanceManager : MonoBehaviour
{
    [SerializeField] Moti.MotiController moti;
    [SerializeField] Text distanceText;

    static float distance;

    static public float Distance => distance;

//-------------------------------------------------------------------
    void Awake()
    {
        distance = 0;
    }

    void FixedUpdate()
    {
        if (!GameManager.isResult) {
            CheckDistance();
            SetText();
        }
    }

//-------------------------------------------------------------------
    // 距離計測
    void CheckDistance()
	{
        var motiPos = moti.transform.position;
        distance = DistanceCaluculator.CheckAxisLength(motiPos.y, 0);
	}

    // テキスト
    void SetText()
	{
        var intDist = (int)distance;
        distanceText.text = intDist.ToString("N0") + "m";
	}

    // ハイスコア変更
    static public void CheckHighScore()
	{
        var highScore = DataManager.data.highScore;
        var intDist = (int)distance;

		if (highScore < intDist) {
            DataManager.data.highScore = intDist;
		}
	}
}
