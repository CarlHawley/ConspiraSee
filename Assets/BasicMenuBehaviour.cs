// BasicMenu 
using UnityEngine;
using UnityEngine.UI;

public class BasicMenuBehaviour : MonoBehaviour
{   
    // delcaring game object to get slider
    GameObject sliderRed;
    GameObject sliderGreen;
    GameObject sliderBlue;
       
    Slider tempRed;
    Slider tempGreen;
    Slider tempBlue;


    public void assignRed()
    {
        sliderRed = GameObject.Find("redSlider");
        tempRed = sliderRed.GetComponent<Slider>();
        tempRed.value = 180;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 0;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 0;
    }

    public void assignOrange()
    {
        sliderRed = GameObject.Find("redSlider");
        tempRed = sliderRed.GetComponent<Slider>();
        tempRed.value = 180;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 150;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 66;
    }

    public void assignYellow()
    {
        sliderRed = GameObject.Find("redSlider");
        tempRed = sliderRed.GetComponent<Slider>();
        tempRed.value = 170;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 170;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 20;
    }

    public void assignGreen()
    {
        sliderRed = GameObject.Find("redSlider");
        tempRed = sliderRed.GetComponent<Slider>();
        tempRed.value = 40;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 180;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 50;
    }

    public void assignBlue()
    {
        sliderRed = GameObject.Find("redSlider");
        tempRed = sliderRed.GetComponent<Slider>();
        tempRed.value = 0;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 0;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 180;
    }

    public void assignIndigo()
    {
        sliderRed = GameObject.Find("redSlider");
        tempRed = sliderRed.GetComponent<Slider>();
        tempRed.value = 75;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 0;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 130;
    }

    public void assignViolet()
    {
        sliderRed = GameObject.Find("redSlider");
        tempRed = sliderRed.GetComponent<Slider>();
        tempRed.value = 143;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 0;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 180;
    }
}
