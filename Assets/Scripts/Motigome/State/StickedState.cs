using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome
{
    public class StickedState : IState
    {
        /* プロパティ */
        public MotigomeController Ctrl { get; set; }

        /* コンストラクタ */
        public StickedState(MotigomeController ctrl)
        {
            Ctrl = ctrl;
        }

        /* メソッド */
        public void StateEnter()
        {

        }

        public void StateUpdate()
        {
            Ctrl.Sticked();
        }

        public void StateExit()
        {

        }
    }
}