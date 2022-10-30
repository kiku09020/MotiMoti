using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button
{
    public class TitleButton : ButtonAbstract
    {
		protected GameObject titleObj;

		protected override void Awake()
		{
			titleObj = GameObject.Find("TitleManager");
            GameObject audObj = titleObj.transform.Find("AudioManager").gameObject;

            se = audObj.GetComponent<SystemSound>();
		}

		public override void Clicked(){}
	}
}