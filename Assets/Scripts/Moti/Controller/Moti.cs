using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MotiUniter),typeof(MotiSticker),typeof(MotiStretcher))]
public class Moti : MonoBehaviour
{
    /* 値 */
    [Header("値")]
    [SerializeField] float jumpForce;

    /* フラグ */

    /* コンポーネント取得用 */
    Rigidbody2D rb;

    MotiStateController stateCtrl;
    HitChecker hit;
    MotiSticker stick;
    MotiStretcher stretch;
    MotiUniter unite;

    MotiParticleController part;
    MotiAudioController aud;

    /* プロパティ */
    public MotiStateController StateCtrl => stateCtrl;
    public MotiSticker Stick => stick;
    public MotiStretcher Stretch => stretch;
    public MotiUniter Unite => unite;

    public MotiParticleController Particle => part;
    public MotiAudioController Audio => aud;

//-------------------------------------------------------------------
    void Start()
    {
        GameObject partObj = transform.Find("ParticleController").gameObject;
        GameObject audObj = transform.Find("AudioController").gameObject;

        /* コンポーネント取得 */
        rb = GetComponent<Rigidbody2D>();

        hit = GetComponent<HitChecker>();
        stick = GetComponent<MotiSticker>();
        stretch = GetComponent<MotiStretcher>();
        unite = GetComponent<MotiUniter>();

        part = partObj.GetComponent<MotiParticleController>();
        aud = audObj.GetComponent<MotiAudioController>();

        stateCtrl = new MotiStateController(this);

        /* 初期化 */
        stateCtrl.InitState(stateCtrl.NormalState);     // 初期状態の指定
    }

    void Update()
    {
        stateCtrl.NowStateUpdate();
    }

    //-------------------------------------------------------------------
    // ジャンプ
    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
	}
}
