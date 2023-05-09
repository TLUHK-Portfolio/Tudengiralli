using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectSlider : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    GameManager GM;

    // Start is called before the first frame update
    void Awake()
    {
        slider.value = GM.GetEffectVolume();
    }
}
