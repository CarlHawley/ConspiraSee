// BasicMenu 
using UnityEngine;
using UnityEngine.UI;

public class BasicMenuBehaviour : MonoBehaviour
{   
    // delcaring game object to get slider
    GameObject _sliderRed;
    GameObject _sliderGreen;
    GameObject _sliderBlue;
       
    Slider _tempRed;
    Slider _tempGreen;
    Slider _tempBlue;


    public void AssignRed()
    {
        _sliderRed = GameObject.Find("redSlider");
        _tempRed = _sliderRed.GetComponent<Slider>();
        _tempRed.value = 140;

        _sliderGreen = GameObject.Find("greenSlider");
        _tempGreen = _sliderGreen.GetComponent<Slider>();
        _tempGreen.value = 5;


        _sliderBlue = GameObject.Find("blueSlider");
        _tempBlue = _sliderBlue.GetComponent<Slider>();
        _tempBlue.value = 30;
    }

    public void AssignOrange()
    {
        _sliderRed = GameObject.Find("redSlider");
        _tempRed = _sliderRed.GetComponent<Slider>();
        _tempRed.value = 180;

        _sliderGreen = GameObject.Find("greenSlider");
        _tempGreen = _sliderGreen.GetComponent<Slider>();
        _tempGreen.value = 30;


        _sliderBlue = GameObject.Find("blueSlider");
        _tempBlue = _sliderBlue.GetComponent<Slider>();
        _tempBlue.value = 15;
    }

    public void AssignYellow()
    {
        _sliderRed = GameObject.Find("redSlider");
        _tempRed = _sliderRed.GetComponent<Slider>();
        _tempRed.value = 150;

        _sliderGreen = GameObject.Find("greenSlider");
        _tempGreen = _sliderGreen.GetComponent<Slider>();
        _tempGreen.value = 110;


        _sliderBlue = GameObject.Find("blueSlider");
        _tempBlue = _sliderBlue.GetComponent<Slider>();
        _tempBlue.value = 30;
    }

    public void AssignGreen()
    {
        _sliderRed = GameObject.Find("redSlider");
        _tempRed = _sliderRed.GetComponent<Slider>();
        _tempRed.value = 10;

        _sliderGreen = GameObject.Find("greenSlider");
        _tempGreen = _sliderGreen.GetComponent<Slider>();
        _tempGreen.value = 100;


        _sliderBlue = GameObject.Find("blueSlider");
        _tempBlue = _sliderBlue.GetComponent<Slider>();
        _tempBlue.value = 90;
    }

    public void AssignBlue()
    {
        _sliderRed = GameObject.Find("redSlider");
        _tempRed = _sliderRed.GetComponent<Slider>();
        _tempRed.value = 0;

        _sliderGreen = GameObject.Find("greenSlider");
        _tempGreen = _sliderGreen.GetComponent<Slider>();
        _tempGreen.value = 40;


        _sliderBlue = GameObject.Find("blueSlider");
        _tempBlue = _sliderBlue.GetComponent<Slider>();
        _tempBlue.value = 110;
    }

    public void AssignIndigo()
    {
        _sliderRed = GameObject.Find("redSlider");
        _tempRed = _sliderRed.GetComponent<Slider>();
        _tempRed.value = 20;

        _sliderGreen = GameObject.Find("greenSlider");
        _tempGreen = _sliderGreen.GetComponent<Slider>();
        _tempGreen.value = 20;


        _sliderBlue = GameObject.Find("blueSlider");
        _tempBlue = _sliderBlue.GetComponent<Slider>();
        _tempBlue.value = 60;
    }

    public void AssignViolet()
    {
        _sliderRed = GameObject.Find("redSlider");
        _tempRed = _sliderRed.GetComponent<Slider>();
        _tempRed.value = 80;

        _sliderGreen = GameObject.Find("greenSlider");
        _tempGreen = _sliderGreen.GetComponent<Slider>();
        _tempGreen.value = 0;


        _sliderBlue = GameObject.Find("blueSlider");
        _tempBlue = _sliderBlue.GetComponent<Slider>();
        _tempBlue.value = 110;
    }
}
