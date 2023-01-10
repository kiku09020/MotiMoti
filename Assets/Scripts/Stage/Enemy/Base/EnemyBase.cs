using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected string name;
    protected int motigomeCnt;

//-------------------------------------------------------------------
    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        
    }

//-------------------------------------------------------------------
    // �f�[�^����l���Z�b�g
    void SetDataParams(string name)
	{
        var data = EnemyData_SO.ReadData(name);

        name = data.Name;
        motigomeCnt = data.MotigomeCnt;
	}
}
