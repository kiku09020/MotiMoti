using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
    public class MotiPowerUp : Singleton<MotiPowerUp> {
        [SerializeField] float powerUpTime;
        float timer;

        public static bool IsPowerUp;       // パワーアップ中


        //-------------------------------------------------------------------
        void Awake()
        {

        }

        void FixedUpdate()
        {

        }

        //-------------------------------------------------------------------

    }
}