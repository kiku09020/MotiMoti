using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBase : MonoBehaviour
{
    [Header("GenerateObject")]
    [SerializeField] protected GameObject generatedObj;         // �����I�u�W�F�N�g
    [SerializeField] protected Transform parent;                // ��������parent

    [Space(10)]
    [SerializeField] protected float genObjDist;                // �I�u�W�F�N�g���m�̋���
    [SerializeField] protected int maxCnt;                      // �I�u�W�F�N�g�̍ő吔

    // position
    [Space(10)]
    [SerializeField] protected Vector2 startGenPos;             // �ŏ��̐����ʒu
    protected Vector2 genPos;                                   // �����ʒu

    // target
    [Space(10)]
    [SerializeField] protected float targetObjMaxDist;          // �v���C���[���琶���ʒu�̍ő勗��
    protected static GameObject targetObj;                      // �v���C���[(Ground������)

    // list
    protected List<GameObject> genObjs = new List<GameObject>();

    /* �v���p�e�B */
    public List<GameObject> GenObjects => genObjs;
    public static GameObject TargetObj => targetObj;
    public int MaxCnt => maxCnt;

	//-------------------------------------------------------------------
    protected virtual void Awake()
    {
        targetObj = GameObject.Find("Moti");
        genPos = startGenPos;

		while (genObjs.Count < maxCnt) {
            Generate();
		}

    }

    void FixedUpdate()
    {
        if (!GameManager.isResult) {
            var dist = DistanceCaluculator.CheckDistance(targetObj.transform.position, genPos);
            if (dist < targetObjMaxDist) {
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

    // ����
    protected virtual void Generate()
	{
        SetGeneratePosition();      // �����ʒu�̎w��

        var obj = Instantiate(generatedObj, genPos, Quaternion.identity, parent);   // �C���X�^���X��
        genObjs.Add(obj);                                                           // ���X�g�ɒǉ�
	}

    protected virtual void Generate(float xRange)
    {
        SetGeneratePosition(xRange);

        var obj = Instantiate(generatedObj, genPos, Quaternion.identity, parent);
        genObjs.Add(obj);
    }
}