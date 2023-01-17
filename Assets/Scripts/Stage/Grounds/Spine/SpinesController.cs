using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spines {
    public class SpinesController : MonoBehaviour {
        [Header("Time")]
        [SerializeField] float waitTime;
        [SerializeField] float atackTime;

        StateController state;

        //-------------------------------------------------------------------
        void Awake()
        {
            state = GetComponent<StateController>();
        }

        void FixedUpdate()
        {

        }

        //-------------------------------------------------------------------

    }
}