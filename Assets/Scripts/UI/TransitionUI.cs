using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionUI : Singleton<TransitionUI>
{
    [Header("Materials")]
    [SerializeField] List<Material> matList = new List<Material>();       // list

    [Header("Transition")]
    [SerializeField, Range(0, 3)] float transtionDuration;     // 画面遷移時間

    [Header("Loop")]
    [SerializeField] bool isLoop;                               // ループするか
    [SerializeField, Range(0, 1)] float loopWaitDuration;           // ループ開始までの時間

    Material mat;
    Image img;

    // TransitionTyepe
    public enum Type
    {
        circleIn,       // In
        circleOut,		// Out
    }

    public float TransitionDuration => transtionDuration;

    protected override void Awake()
    {
        if (TryGetComponent(out Image img)) {
            this.img = GetComponent<Image>();
        }

        else {
            gameObject.AddComponent<Image>();
        }
    }

    // Transition開始
    public void PlayTransition(Type type)
    {
        mat = matList[(int)type];
        img.material = mat;                     // マテリアル変更

        gameObject.SetActive(true);             // 表示
        StartCoroutine(Transition());			// 再生
    }

    // Transition本体
    IEnumerator Transition()
    {
        var time = 0f;

        while (time < transtionDuration) {          // 指定時間まで繰り返して値を指定する
            var phase = time / transtionDuration;
            mat.SetFloat("_phase", phase);          // マテリアルのプロパティの指定

            yield return null;
            time += Time.deltaTime;
        }

        mat.SetFloat("_phase", 1);                  // while終了時の残りカス削除

        // ループ時の処理
        if (isLoop) {
            yield return new WaitForSeconds(loopWaitDuration);  // 待機
            yield return Transition();                          // 再度実行
        }
    }

    private void OnDestroy()
    {
        mat.SetFloat("_phase", 0);

        if (!mat) {
            Destroy(mat);		// マテリアル削除
        }
    }
}
