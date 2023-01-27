using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyerBase))]       // �폜�R���|�[�l���g�K�{�ɂ���
public class Generator : MonoBehaviour
{
    [Header("Object")]
    [SerializeField,Tooltip("��������I�u�W�F�N�g")] 
    protected GameObject genObj;
    protected Transform parent;                 // ������

    [SerializeField, Tooltip("������̃I�u�W�F�N�g")]
    protected GameObject targetObj;

    [Header("Distance")]
    [SerializeField,Tooltip("�������ꂽ�I�u�W�F�N�g���m�̋���")]
    protected float genObjDist;
    [SerializeField, Tooltip("�v���C���[���琶���ʒu�̋���")]
    protected float targetDist;

    [Header("Position")]
    [SerializeField,Tooltip("�����ʒu�̊J�n�n�_")] 
    protected Vector2 startGenPos;
    protected Vector2 genPos;                   // �����ʒu

    [Header("Other")]
    [SerializeField, Tooltip("�ő吶����")]
    protected int maxCnt;

    // list
    protected List<GameObject> genObjList = new List<GameObject>();     // �������ꂽ�I�u�W�F�N�g�̃��X�g

    /* �v���p�e�B */
    public List<GameObject> GenObjList => genObjList;
    public int MaxCnt => maxCnt;

	//-------------------------------------------------------------------
    protected virtual void Awake()
    {
        parent = transform;         // ������w��
        genPos = startGenPos;       // �ŏ��̐����ʒu�̎w��
    }

    void FixedUpdate()
    {
        if (!GameManager.isResult) {
            var dist = DistanceCaluculator.CheckDistance(targetObj.transform.position, genPos);
            if (dist < targetDist) {
                Generate();
            }
        }
    }

//-------------------------------------------------------------------
    // Y���W�̂�
    protected void SetGeneratePosition()
	{
        var y = genPos.y + genObjDist;

        genPos = new Vector2(0, y);
	}

    // ����ꂽ�ꏊ�ɂ̂�
    protected void SetGeneratePosition(float range,bool containMinus)
    {
        var x = 0f;
        if (containMinus) {
            x = range * Expansion.GetRandomDirect();
        }

        else {
            x = range;
        }

        var y = genPos.y + genObjDist;
        genPos = new Vector2(x, y);
    }

    // X���W�������_���Ɏw�肷��
    protected void SetGenerateRandomPosition(float range)
    {
        var x = Random.Range(-range, range);
        var y = genPos.y + genObjDist;

        genPos = new Vector2(x, y);
    }

    //-------------------------------------------------------------------
    // �����Ăяo���p
    protected virtual void Generate()
    {
        GenerateBase();
    }

    // ����
    protected virtual GameObject GenerateBase()
	{
        SetGeneratePosition();      // �����ʒu�̎w��

        var obj = Instantiate(genObj, genPos, Quaternion.identity, parent);   // �C���X�^���X��
        genObjList.Add(obj);                                           // ���X�g�ɒǉ�

        return obj;
	}

    protected virtual GameObject GenerateBase(float xRange, bool isRandom = true)
    {
        if (isRandom) {
            SetGenerateRandomPosition(xRange);
        }

        else {
            SetGeneratePosition(xRange, true);
        }

        var obj = Instantiate(genObj, genPos, Quaternion.identity, parent);
        genObjList.Add(obj);

        return obj;
    }
}
