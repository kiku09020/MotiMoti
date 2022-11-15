using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MotiUniter),typeof(MotiSticker),typeof(MotiStretcher))]
public class Moti : MonoBehaviour
{
    /* 値 */

    /* フラグ */

    /* コンポーネント取得用 */
    Rigidbody2D rb;

    // checker
    GroundChecker ground;
    HitChecker motiHit;
    InputChecker input;

    // controller
    MotiStateController stateCtrl;
    MotiStretcher stretcher;
    MotiUniter uniter;
    MotiLineController line;

    // performer
    MotiParticleController part;
    MotiAudioController aud;

    /* プロパティ */
    // 
    public Rigidbody2D RB => rb;

    public MotiStretcher Stretcher=>stretcher;
    public MotiUniter Uniter => uniter;
    public MotiLineController Line => line;

    // check
    public HitChecker MotiHit => motiHit;
    public GroundChecker Ground => ground;
    public InputChecker Input => input;

    // state
    public MotiStateController StateCtrl => stateCtrl;

    // performer
    public MotiParticleController Particle => part;
    public MotiAudioController Audio => aud;

//-------------------------------------------------------------------
    void Awake()
    {
        Transform checkerObj = transform.Find("HitChecker");
        Transform partObj = transform.Find("ParticleController");
        Transform audObj = transform.Find("AudioController");
        Transform lineObj = transform.Find("StretchedMotiLine");

        /* コンポーネント取得 */
        rb = GetComponent<Rigidbody2D>();

        motiHit = checkerObj.GetComponent<HitChecker>();
        ground = checkerObj. GetComponent<GroundChecker>();
        input = checkerObj.GetComponent<InputChecker>();

        part = partObj.GetComponent<MotiParticleController>();
        aud = audObj.GetComponent<MotiAudioController>();

        stateCtrl = new MotiStateController(this);
        stretcher = GetComponent<MotiStretcher>();
        uniter = GetComponent<MotiUniter>();
        line = lineObj.GetComponent<MotiLineController>();

        /* 初期化 */
        stateCtrl.InitState(stateCtrl.NormalState);     // 初期状態の指定
    }

    // クローンされたもちの初期化
    public void InitClonedMoti()
	{
        Awake();

        Input.TapDown();        // クローンもちも入力している状態にする
        StateCtrl.TransitionState(StateCtrl.StretchingState);
    }

    void FixedUpdate()
    {
        stateCtrl.NowStateUpdate();
    }
}
