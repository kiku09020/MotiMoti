using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private void Awake()
    {
        BGM.Instance.Play("titleBGM", 0, 0.5f);
    }
}
