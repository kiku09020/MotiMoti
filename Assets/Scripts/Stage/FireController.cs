using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float speedUpValue;

    bool isHit;
    GameObject hitObject;

    public bool IsHit => isHit;
    public GameObject HitObject => hitObject;

//-------------------------------------------------------------------
    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        MoveUp();
    }

//-------------------------------------------------------------------
    // 上の方に移動
    void MoveUp()
	{
        transform.position += new Vector3(0, speed, 0);
	}

    // 速度上昇
    public void SpeedUp()
	{
        speed += speedUpValue;
	}

    //-------------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Moti") {
            isHit = true;
            GameManager.isResult = true;
            hitObject = col.gameObject;
		}
	}
}
