using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GenerateTargetChecker))]
public abstract class GeneratorBase<T> : Singleton<T> where T :GeneratorBase<T>
{
    [Header("�����I�v�V����")]
    [SerializeField,Tooltip("�I�u�W�F�N�g���m�̊Ԋu")]
    float generatedObjDist;

    [SerializeField, Tooltip("�^�[�Q�b�g���琶���ʒu�܂ł̋���")]
    float generatedDistanceFromTarget;

    [SerializeField,Tooltip("�����J�n�n�_")] 
    float startGeneratedPosY;


    [SerializeField, Tooltip("������")]
    protected Transform parent;

    [Header("�����^�C�v")]
    [SerializeField,Tooltip("�����^�C�v")]
    GenerateType generateType;

    [SerializeField,Tooltip("�����֌W�̒l")] 
    float value;

    // �����ʒu
    protected Vector2 generatedPos;

    // �������ꂽ�I�u�W�F�N�g�̃��X�g
    List<GameObject> generatedObjList = new List<GameObject>();
    public List<GameObject> GeneratedObjList => generatedObjList;

    // �����^�C�v
    enum GenerateType {
        random,
        edge,
        constant,
    }

    IGenerateType genType;

    /* �R���|�[�l���g */
    GenerateTargetChecker targetChecker;


//-------------------------------------------------------------------
    protected override void Awake()
    {
        /* �R���|�[�l���g�擾 */
        targetChecker = GetComponent<GenerateTargetChecker>();

        // �����悪�w�肳��Ă��Ȃ���΁A���g��transform�𐶐���Ƃ���
        if (!parent) {
            parent = transform;
        }

        generatedPos = new Vector2(0,startGeneratedPosY);       // �ŏ��̐�����̎w��

        //�^�C�v�w��
        SetGenerateType();
    }

    // �����^�C�v�̎w��
    void SetGenerateType()
    {
        switch (generateType) {
            case GenerateType.random:       genType = new GenType_Random(); break;
            case GenerateType.edge:         genType = new GenType_Edge();   break;
            case GenerateType.constant:     genType = new GenType_Const();  break;
        }
    }


    void FixedUpdate()
    {
        if (!GameManager.isResult) {

            // �^�[�Q�b�g�Ƃ̋������w���菬�����Ȃ����琶������
            if(targetChecker.CheckTargetWithinDistance(generatedDistanceFromTarget, generatedPos)) {
                Generate();
            }
        }
    }

    // ����
    void Generate()
    {
        generatedPos= genType.SetPosition(generatedPos.y + generatedObjDist, value);
        GenerateBase();
    }

    /// <summary>
    /// ����
    /// </summary>
    protected abstract void GenerateBase();
}
