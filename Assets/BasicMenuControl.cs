using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicMenuControl : MonoBehaviour
{
    public Slider sliderRed;
    public Slider sliderGreen;
    public Slider sliderBlue;

    // Start is called before the first frame update
    public BasicMenuControl()
    {
        sliderRed = GetComponent<Slider>();
        sliderGreen = GetComponent<Slider>();
        sliderBlue = GetComponent<Slider>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
