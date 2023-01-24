using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField] float spd;     // �X�N���[�����x

    Renderer rend;

//-------------------------------------------------------------------
    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void LateUpdate()
    {
        var camPos = CameraController.Instance.transform.position;

        transform.position = new Vector3(0, camPos.y, 1);        // �J�����ʒu�܂ňړ�

        var sclrSpd = 3000 - camPos.y;
        var y = Mathf.Repeat(sclrSpd * spd , 1);
        var ofst = new Vector2(0, y);

        rend.sharedMaterial.SetTextureOffset("_MainTex", ofst);
    }

    //-------------------------------------------------------------------

    private void OnApplicationQuit()
    {
        rend.sharedMaterial.SetTextureOffset("_MainTex", Vector2.zero);
    }
}
