using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DebugManager : MonoBehaviour
{
    /* 値 */
    bool isPausing;

//-------------------------------------------------------------------
    void Start()
    {

    }

	private void Update()
	{
        Key();
	}

	//-------------------------------------------------------------------
	// キー操作
	void Key()
    {
        // シーン再読み込み
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneController.Instance.LoadNowScene();
            Debug.ClearDeveloperConsole();
        }

        // 一時停止
        else if(Input.GetKeyDown(KeyCode.P)){
            if(isPausing){
                Time.timeScale = 1;
                isPausing = false;
			}
            else{
                Time.timeScale = 0;
                isPausing = true;
			}

            Print(isPausing, true);
		}

        // ゲームオーバー
        else if (Input.GetKeyDown(KeyCode.F1)) {
            GameManager.isResult = true;
            Print("Transition to Result.", Color.red);
		}

        // 下の火の有効化
        else if (Input.GetKeyDown(KeyCode.F2)) {
            MainFireController.enable = !MainFireController.enable;
            Print($"MainFire's enable = {MainFireController.enable}", Color.red);
		}

        // 終了
        else if (Input.GetKeyDown(KeyCode.Escape)) {
            QuitGame();
        }
    }

    // ゲーム終了
    void QuitGame()
    {
#if UNITY_EDITOR
        Application.Quit();
        EditorApplication.isPlaying = false;

#elif UNITY_ANDROID
        CanvasManager.ActivateCautionUI(true);

#endif
    }

    static public void Print(object message,bool isBold)
	{
        var text = "";
		if (isBold) {
            text = $"<b>{message.ToString()}</b>";
		}
		else {
            text = message.ToString();
		}

        print(text);
	}

    static public void Print(string text,Color color)
	{
        var code = ColorUtility.ToHtmlStringRGBA(color);
        var str = $"<b><color=#{code}>{text}</color></b>";
        print(str);
	}
}
