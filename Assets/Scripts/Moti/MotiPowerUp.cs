using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
    public class MotiPowerUp : Singleton<MotiPowerUp> {
        [SerializeField] float powerUpTime;
        float timer;

        public static bool IsPowerUp;       // �p���[�A�b�v��


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