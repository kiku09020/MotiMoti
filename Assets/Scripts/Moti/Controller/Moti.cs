using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MotiUniter),typeof(MotiSticker),typeof(MotiStretcher))]
public class Moti : MonoBehaviour
{
    /* 値 */
    Transform motiFolder;

    /* フラグ */

    /* コンポーネント取得用 */
    #region Components
    Rigidbody2D rb;

    // checker
    GroundChecker ground;
    HitChecker motiHit;
    InputChecker input;

    // controller
    MotiFamilyController family;
    MotiStateController stateCtrl;
    MotiStretcher stretcher;
    MotiUniter uniter;
    MotiLineController line;

    // performer
    MotiParticleController part;
    MotiAudioController aud;
    #endregion

    /* プロパティ */
    #region Properties
    // values
    public Transform Folder => motiFolder;

    // controllers
    public Rigidbody2D RB => rb;

    public MotiFamilyController Family => family;
    public MotiStretcher Stretcher=>stretcher;
    public MotiUniter Uniter => uniter;
    public MotiLineController Line => line;

    // checks
    public HitChecker MotiHit => motiHit;
    public GroundChecker Ground => ground;
    public InputChecker Input => input;

    // states
    public MotiStateController StateCtrl => stateCtrl;

    // performers
    public MotiParticleController Particle => part;
    public MotiAudioController Audio => aud;
    #endregion

    //-------------------------------------------------------------------
    void Awake()
    {
        Transform checkerObj = transform.Find("HitChecker");
        Transform partObj = transform.Find("ParticleController");
        Transform audObj = transform.Find("AudioController");
        Transform lineObj = transform.Find("StretchedMotiLine");

        motiFolder = GameObject.Find("Motis").transform;

        /* コンポーネント取得 */
        rb = GetComponent<Rigidbody2D>();

        motiHit = checkerObj.GetComponent<HitChecker>();
        ground = checkerObj. GetComponent<GroundChecker>();
        input = checkerObj.GetComponent<InputChecker>();

        part = partObj.GetComponent<MotiParticleController>();
        aud = audObj.GetComponent<MotiAudioController>();

        family = new MotiFamilyController(this);
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
        family.CheckExistFamily();
    }
}
