using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : AudioBasic
{
	public enum AudioName {
		bgm1,
		bgm2,
	}

	public override void Play(int audio)
	{
		AudioClip clip = clips[audio];

		source.loop = true;		// ループ
		source.clip = clip;		// クリップ指定
		source.Play();			// 再生
	}
}
