using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Moti.MotiController moti;

//-------------------------------------------------------------------
    void Awake()
    {
        
    }

    public void ChangedValue()
    {
        if (moti) {
            moti.Stretcher.moveSensitivity = (slider.value / slider.maxValue) ;
        }
    }

//-------------------------------------------------------------------

}
