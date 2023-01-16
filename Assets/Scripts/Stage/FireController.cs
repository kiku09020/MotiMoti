using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : DamageGimmicks
{
    [SerializeField] float speed;
    [SerializeField] float speedUpValue;

    static public bool enable;

//-------------------------------------------------------------------
    void Awake()
    {
        enable = true;
    }

    void FixedUpdate()
    {
		if (enable) {
            MoveUp();
		}
    }

//-------------------------------------------------------------------
    // è„ÇÃï˚Ç…à⁄ìÆ
    void MoveUp()
	{
        transform.position += new Vector3(0, speed, 0);
	}

    // ë¨ìxè„è∏
    public void SpeedUp()
	{
        speed += speedUpValue;
	}
}
