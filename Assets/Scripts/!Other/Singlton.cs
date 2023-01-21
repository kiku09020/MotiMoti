using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singlton<T> : MonoBehaviour where T :Component
{
    static T instance;      // インスタンス本体

    // インスタンス取得
    public static T Instance {
        get {
            if (!instance) {
                instance = (T)FindObjectOfType(typeof(T));      // 既存のインスタンス検索

                if (!instance) {
                    SetUpInstance();
                }
            }

            return instance;
        }
    }

    // 起動時にシングルトンのセットアップ
    protected virtual void Awake()
    {
        RemoveDuplicates();
    }

    // インスタンスの検索、新規作成
    static void SetUpInstance()
    {
        instance = (T)FindObjectOfType(typeof(T));      // 検索

        // 新規作成
        if (!instance) {
            var obj = new GameObject();         // ゲームオブジェクト作成
            obj.name = typeof(T).Name;

            instance = obj.AddComponent<T>();   // コンポーネント追加
            DontDestroyOnLoad(obj);             // シーン遷移時に破棄しない
        }
    }

    // 重複チェック、削除
    void RemoveDuplicates()
    {
        // 新規作成
        if (!instance) {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }

        // 重複を削除
        else {
            Destroy(gameObject);
        }
    }
}
