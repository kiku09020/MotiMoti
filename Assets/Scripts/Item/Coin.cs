using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    static int getCount;

//-------------------------------------------------------------------
    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        
    }

//-------------------------------------------------------------------
    protected override void Getted()
	{
        print("a");
	}

    protected override void OnTriggerEnter2D(Collider2D col)
	{
        base.OnTriggerEnter2D(col);
	}
}
