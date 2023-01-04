using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDestroyer : MonoBehaviour
{
    [SerializeField] float destroyDist;     // ��������̋���


    Moti.MotiController moti;

//-------------------------------------------------------------------
    void Awake()
    {
        moti = GameObject.Find("Moti").GetComponent<Moti.MotiController>();
    }

    void FixedUpdate()
    {
        DestroyStage();
    }

//-------------------------------------------------------------------
    // �폜
    void DestroyStage()
	{
        var motiPos = moti.transform.position;

        // �X�e�[�W�̈ʒu���w���菬����������폜
		if (transform.position.y < (motiPos.y - destroyDist)) {
            Destroy(this.gameObject);
		}
	}
}