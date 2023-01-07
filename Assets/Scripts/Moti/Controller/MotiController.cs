using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    [RequireComponent(typeof(MotiUniter), typeof(MotiStretcher))]
    public class MotiController : MonoBehaviour {
        Transform motiFolder;

        /* コンポーネント取得用 */
        #region Components
        Rigidbody2D rb;

        // checker
        GroundHitChecker ground;
        MotiHitChecker motiHit;
        FireHitChecker fireHit;
        InputChecker input;

        // controller
        MotiFamilyController family;
        StateController stateCtrl;
        MotiStretcher stretcher;
        MotiUniter uniter;
        MotiLineController line;

        // performer
        MotiParticleController part;
        MotiAudioController aud;
        #endregion

        /* プロパティ */
        #region Properties
        public Transform Folder { get; private set; }

        // controllers
        public Rigidbody2D RB => rb;

        public MotiFamilyController Family => family;
        public MotiStretcher Stretcher => stretcher;
        public MotiUniter Uniter => uniter;
        public MotiLineController Line => line;

        // checks
        public GroundHitChecker Ground => ground;
        public MotiHitChecker MotiHit => motiHit;
        public FireHitChecker FireHit => fireHit;
        public InputChecker Input => input;

        // states
        public StateController StateCtrl => stateCtrl;

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

            motiHit = checkerObj.GetComponent<MotiHitChecker>();
            ground = checkerObj.GetComponent<GroundHitChecker>();
            fireHit = checkerObj.GetComponent<FireHitChecker>();
            input = checkerObj.GetComponent<InputChecker>();

            part = partObj.GetComponent<MotiParticleController>();
            aud = audObj.GetComponent<MotiAudioController>();

            family = new MotiFamilyController(this);
            stateCtrl = new StateController(this);
            stretcher = GetComponent<MotiStretcher>();
            uniter = GetComponent<MotiUniter>();
            line = lineObj.GetComponent<MotiLineController>();

            /* 初期化 */
            stateCtrl.InitState(stateCtrl.NormalState);     // 初期状態の指定
        }

        // 子の初期化
        public void InitChild()
        {
            stateCtrl.TransitionState(StateCtrl.StretchingState);
        }

        void FixedUpdate()
        {
            family.FamilyUpdate();                      // 親子関係
            stateCtrl.NowStateUpdate();                 // 状態

            line.LineUpdate();                          // ライン
            stretcher.StretchingUpdate();               // 伸び

            Debug.DrawLine(transform.position, transform.position+(Vector3)ground.HitVector,Color.blue);

            Debug.DrawLine(transform.position, transform.position + transform.right * 2,Color.red);
        }

        //-------------------------------------------------------------------
    }
}