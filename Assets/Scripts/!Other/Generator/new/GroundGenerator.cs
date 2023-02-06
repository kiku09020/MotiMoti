using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : GeneratorSingle
{
    [Header("Ground")]
    [SerializeField,Tooltip("回転開始高度")] 
    float rotateStartHeight;

    protected override void GenerateBase()
    {
        // Groundコンポーネントついてる場合のみ生成
        if (targetGenObj.TryGetComponent(out Ground groundBase)) {
            Ground generatedGround = Instantiate(groundBase, generatedPos, Quaternion.identity, parent);

            // ひとつ前のオブジェクトを指定する
            if (GeneratedObjList?.Count > 0) {
                generatedGround.PrevStage = GeneratedObjList[GeneratedObjList.Count - 1].GetComponent<Ground>();
            }

            GeneratedObjList.Add(generatedGround.gameObject);
        }

        // コンポーネントついていない場合、警告
        else {
            Debug.LogError($"{nameof(targetGenObj)}に{typeof(Ground).Name}コンポーネントがついていません");
        }
    }
}
