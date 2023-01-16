using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateBase 
{
	public void StateEnter();
	public void StateUpdate();
	public void StateExit();
}
