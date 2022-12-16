using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    [RequireComponent(typeof(MotiUniter), typeof(MotiSticker), typeof(MotiStretcher))]
    public class MotiController : MonoBehaviour
    {
        /* 値 */
        Vector2 pos;
        Vector2 scale;
        float scaleValue;

        Transform motiFolder;

        [Header("transform")]
        [SerializeField] float maxScaleValue;        // 大きさの最大値

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
        MotiSticker sticker;
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
        public Vector2 Pos => pos;
        public Vector2 Scale => scale;
        public float ScaleValue => scaleValue;
        public float MaxScaleValue => maxScaleValue;

        public Transform Folder => motiFolder;

        // controllers
        public Rigidbody2D RB => rb;

        public MotiFamilyController Family => family;
        public MotiStretcher Stretcher => stretcher;
        public MotiSticker Sticker => sticker;
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
            ground = checkerObj.GetComponent<GroundChecker>();
            input = checkerObj.GetComponent<InputChecker>();

            part = partObj.GetComponent<MotiParticleController>();
            aud = audObj.GetComponent<MotiAudioController>();

            family = new MotiFamilyController(this);
            stateCtrl = new MotiStateController(this);
            sticker = GetComponent<MotiSticker>();
            stretcher = GetComponent<MotiStretcher>();
            uniter = GetComponent<MotiUniter>();
            line = lineObj.GetComponent<MotiLineController>();

            /* 初期化 */
            SetValues();
            stateCtrl.InitState(stateCtrl.NormalState);     // 初期状態の指定
        }

        // 子の初期化
        public void InitChild()
        {
            stateCtrl.TransitionState(StateCtrl.StretchingState);
        }

        void FixedUpdate()
        {
            SetValues();
            stateCtrl.NowStateUpdate();                 // 状態
            family.FamilyUpdate();                      // 親子関係

            sticker.Stick();                            // くっつき
            line.LineUpdate();                          // ライン
            stretcher.StretchingUpdate();               // 伸び
        }

        //-------------------------------------------------------------------
        // 値の取得
        void SetValues()
        {
            pos = transform.position;
            scale = transform.localScale;
            scaleValue = scale.x;
        }

        // 大きさを変更する
        public void SetScale(float targetScaleValue)
        {
            if (targetScaleValue < maxScaleValue) {
                transform.localScale = new Vector2(targetScaleValue, targetScaleValue);
            }
        }

        // オブジェクトとの距離を調べる
        public Vector2 CheckVector(Vector2 targetPos)
        {
            var vec = targetPos - (Vector2)transform.position;

            Debug.DrawRay(transform.position, vec, Color.blue);

            return vec;
        }
    }
}