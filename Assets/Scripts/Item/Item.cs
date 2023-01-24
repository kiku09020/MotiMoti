using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
	protected string GetText { get; set; }

	public abstract void Getted();

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Moti") {
			Getted();
		}
	}
}
