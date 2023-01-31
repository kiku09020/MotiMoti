using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionUI : Singleton<TransitionUI>
{
    [Header("Materials")]
    [SerializeField] List<Material> matList = new List<Material>();       // list

    [Header("Transition")]
    [SerializeField, Range(0, 3)] float transtionDuration;     // ��ʑJ�ڎ���

    [Header("Loop")]
    [SerializeField] bool isLoop;                               // ���[�v���邩
    [SerializeField, Range(0, 1)] float loopWaitDuration;           // ���[�v�J�n�܂ł̎���

    Material mat;
    Image img;

    // TransitionTyepe
    public enum Type
    {
        circleIn,       // In
        circleOut,		// Out
    }

    public float TransitionDuration => transtionDuration;

    protected override void Awake()
    {
        if (TryGetComponent(out Image img)) {
            this.img = GetComponent<Image>();
        }

        else {
            gameObject.AddComponent<Image>();
        }
    }

    // Transition�J�n
    public void PlayTransition(Type type)
    {
        mat = matList[(int)type];
        img.material = mat;                     // �}�e���A���ύX

        gameObject.SetActive(true);             // �\��
        StartCoroutine(Transition());			// �Đ�
    }

    // Transition�{��
    IEnumerator Transition()
    {
        var time = 0f;

        while (time < transtionDuration) {          // �w�莞�Ԃ܂ŌJ��Ԃ��Ēl���w�肷��
            var phase = time / transtionDuration;
            mat.SetFloat("_phase", phase);          // �}�e���A���̃v���p�e�B�̎w��

            yield return null;
            time += Time.deltaTime;
        }

        mat.SetFloat("_phase", 1);                  // while�I�����̎c��J�X�폜

        // ���[�v���̏���
        if (isLoop) {
            yield return new WaitForSeconds(loopWaitDuration);  // �ҋ@
            yield return Transition();                          // �ēx���s
        }
    }

    private void OnDestroy()
    {
        mat.SetFloat("_phase", 0);

        if (!mat) {
            Destroy(mat);		// �}�e���A���폜
        }
    }
}
