using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motigome : Item
{
    [SerializeField] float power;
    static int getCount;

//-------------------------------------------------------------------
    void Awake()
    {
        getCount = 0;
    }

    void FixedUpdate()
    {
        
    }

//-------------------------------------------------------------------
    protected override void Getted()
	{
        getCount++;

        MotiGaugeManager.AddPower(power);
        MotiGaugeVisualizer.Instance.SetDispPower();

        Destroy(gameObject);
	}

    protected override void OnTriggerEnter2D(Collider2D col)
	{
        base.OnTriggerEnter2D(col);
	}
}
