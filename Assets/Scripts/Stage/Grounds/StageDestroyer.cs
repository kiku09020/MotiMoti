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
        if (!GameManager.isResult) {
            CheckDestroy();
        }
    }

//-------------------------------------------------------------------
    // �폜
    void CheckDestroy()
	{
        var motiPos = moti.transform.position;

        // �X�e�[�W�̈ʒu���w���菬����������폜
        DistanceCaluculator.CheckOverDistance(transform.position.y, (motiPos.y - destroyDist), DestroyObject);
	}

	private void DestroyObject()
	{
        Destroy(gameObject);
	}
}
