using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicMenuBehaviour : MonoBehaviour
{
    [SerializeField] private Slider sliderRed = null;
    [SerializeField] private Slider sliderGreen = null;
    [SerializeField] private Slider sliderBlue = null;

    public void assignRed() {
        sliderRed = GetComponent<Slider>();
        sliderGreen = GetComponent<Slider>();
        sliderBlue = GetComponent<Slider>();
        sliderRed.value = 255;
        sliderGreen.value = 0;
        sliderBlue.value = 0;
    }
}
