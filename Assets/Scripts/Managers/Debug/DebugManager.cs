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

#if UNITY_EDITOR
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

            Print(nameof(isPausing),isPausing);
		}

        // ゲームオーバー
        else if (Input.GetKeyDown(KeyCode.F1)) {
            GameManager.isResult = true;
            Print("Transition to Result.", Color.red);
		}

        // 下の火の有効化
        else if (Input.GetKeyDown(KeyCode.F2)) {
            FireController.Instance.SetEnable();
            Print($"MainFire's enable = {FireController.Instance.isEnable}", Color.red);
		}

        else if (Input.GetKeyDown(KeyCode.F3)) {
            MotiGaugeManager.Instance.SetPowerMax();
        }

        // 終了
        else if (Input.GetKeyDown(KeyCode.Escape)) {
            QuitGame();
        }

#endif
    }

    // ゲーム終了
    void QuitGame()
    {
#if UNITY_EDITOR
        Application.Quit();
        EditorApplication.isPlaying = false;

#elif UNITY_ANDROID
        PauseManager.Instance.isExit = true;
        CanvasManager.ActivateCautionUI(true);

#endif
    }

    static public void Print(string  objectName, object message)
	{
        var text = $"<b>{objectName} = {message.ToString()}</b>";
        print(text);
	}

    static public void Print(string text,Color color)
	{
        var code = ColorUtility.ToHtmlStringRGBA(color);
        var str = $"<b><color=#{code}>{text}</color></b>";
        print(str);
	}

    static public void Print(params object[] messages)
	{
        var text = "";
        foreach(var msg in messages) {
            text += msg;
		}

        print($"<b>{text}</b>");
	}
}
