using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicMenuControl : MonoBehaviour
{
    public Slider SliderRed;
    public Slider SliderGreen;
    public Slider SliderBlue;

    // Start is called before the first frame update
    public BasicMenuControl()
    {
        SliderRed = GetComponent<Slider>();
        SliderGreen = GetComponent<Slider>();
        SliderBlue = GetComponent<Slider>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
