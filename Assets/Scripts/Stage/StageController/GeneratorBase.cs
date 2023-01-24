using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyerBase))]       // �폜�R���|�[�l���g�K�{�ɂ���
public class GeneratorBase : MonoBehaviour
{
    const float dispSpace = 10;

    [Header("GenerateObject")]
    [SerializeField,Tooltip("��������I�u�W�F�N�g")] 
    protected GameObject genObj;
    [SerializeField,Tooltip("�������parent")]
    protected Transform parent;

    [Space(dispSpace)]
    [SerializeField,Tooltip("�������ꂽ�I�u�W�F�N�g���m�̋���")]
    protected float genObjDist;
    [SerializeField,Tooltip("�ő吶����")]
    protected int maxCnt;

    // position
    [Space(dispSpace)]
    [SerializeField,Tooltip("�����ʒu�̊J�n�n�_")] 
    protected Vector2 startGenPos;
    protected Vector2 genPos;                                   // �����ʒu

    // target
    [Space(dispSpace)]
    [SerializeField,Tooltip("�v���C���[���琶���ʒu�̋���")] 
    protected float targetDist;
    protected static GameObject targetObj;                      // �v���C���[(Ground������)

    // list
    protected List<GameObject> genObjList = new List<GameObject>();     // �������ꂽ�I�u�W�F�N�g�̃��X�g

    /* �v���p�e�B */
    public List<GameObject> GenObjList => genObjList;
    public static GameObject TargetObj => targetObj;
    public int MaxCnt => maxCnt;

	//-------------------------------------------------------------------
    protected virtual void Awake()
    {
        targetObj = GameObject.Find("Moti");
        genPos = startGenPos;

		while (genObjList.Count < maxCnt) {
            Generate();
		}

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
    protected virtual void SetGeneratePosition()
	{
        var y = genPos.y + genObjDist;

        genPos = new Vector2(0, y);
	}

    // X���W�������_���Ɏw�肷��
    protected virtual void SetGeneratePosition(float xRange)
	{
        var x = Random.Range(-xRange, xRange);
        var y = genPos.y + genObjDist;

        genPos = new Vector2(x, y);
	}

    //-------------------------------------------------------------------

    // ����
    protected virtual void Generate()
	{
        SetGeneratePosition();      // �����ʒu�̎w��

        var obj = Instantiate(genObj, genPos, Quaternion.identity, parent);   // �C���X�^���X��
        genObjList.Add(obj);                                           // ���X�g�ɒǉ�
	}

    protected virtual GameObject Generate(float xRange)
    {
        SetGeneratePosition(xRange);

        var obj = Instantiate(genObj, genPos, Quaternion.identity, parent);
        genObjList.Add(obj);

        return obj;
    }
}
