using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    [RequireComponent(typeof(MotiUniter), typeof(MotiStretcher))]
    public class MotiController : MonoBehaviour {

        /* プロパティ */
        #region Properties
        public Transform Folder { get; private set; }

        // controllers
        

        public MotiFamilyController Family { get; private set; }
        public MotiStretcher Stretcher { get; private set; }
        public MotiUniter Uniter { get; private set; }
        public MotiLineController Line { get; private set; }
        public MotiLineCollision LineCol { get; private set; }

        // checkers
        public GroundHitChecker Ground { get; private set; }
        public MotiHitChecker MotiHit { get; private set; }
        public EnemyHitChecker EnemyHit { get; private set; }
        public InputChecker Input { get; private set; }

        // states
        public StateController StateCtrl { get; private set; }

        // performers
        public MotiParticleController Particle { get; private set; }
        public MotiAudioController Audio { get; private set; }
        #endregion

        //-------------------------------------------------------------------
        void Awake()
        {
            Transform checkerObj = transform.Find("HitChecker");
            Transform partObj = transform.Find("ParticleController");
            Transform audObj = transform.Find("AudioController");
            Transform lineObj = transform.Find("StretchedMotiLine");

            Folder = GameObject.Find("Motis").transform;

            /* コンポーネント取得 */
            

            MotiHit = checkerObj.GetComponent<MotiHitChecker>();
            Ground = checkerObj.GetComponent<GroundHitChecker>();
            EnemyHit = checkerObj.GetComponent<EnemyHitChecker>();
            Input = checkerObj.GetComponent<InputChecker>();

            Particle = partObj.GetComponent<MotiParticleController>();
            Audio = audObj.GetComponent<MotiAudioController>();

            Family = new MotiFamilyController(this);
            StateCtrl = new StateController(this);
            Stretcher = GetComponent<MotiStretcher>();
            Uniter = GetComponent<MotiUniter>();

            Line = lineObj.GetComponent<MotiLineController>();
            LineCol = lineObj.GetComponent<MotiLineCollision>();

            /* 初期化 */
            StateCtrl.Init(StateCtrl.NormalState);     // 初期状態の指定
        }

        // 子の初期化
        public void InitChild()
        {
            StateCtrl.StateTransition(StateCtrl.StretchingState);
        }

        void FixedUpdate()
        {
            Family.FamilyUpdate();                      // 親子関係
            StateCtrl.StateUpdate();                 // 状態

            Line.LineUpdate();                          // ライン
            Stretcher.StretchingUpdate();               // 伸び
        }

        //-------------------------------------------------------------------
    }
}