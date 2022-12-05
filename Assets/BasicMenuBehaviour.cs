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
        tempRed.value = 140;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 5;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 30;
    }

    public void assignOrange()
    {
        sliderRed = GameObject.Find("redSlider");
        tempRed = sliderRed.GetComponent<Slider>();
        tempRed.value = 180;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 30;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 15;
    }

    public void assignYellow()
    {
        sliderRed = GameObject.Find("redSlider");
        tempRed = sliderRed.GetComponent<Slider>();
        tempRed.value = 150;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 110;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 30;
    }

    public void assignGreen()
    {
        sliderRed = GameObject.Find("redSlider");
        tempRed = sliderRed.GetComponent<Slider>();
        tempRed.value = 10;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 100;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 90;
    }

    public void assignBlue()
    {
        sliderRed = GameObject.Find("redSlider");
        tempRed = sliderRed.GetComponent<Slider>();
        tempRed.value = 0;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 40;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 110;
    }

    public void assignIndigo()
    {
        sliderRed = GameObject.Find("redSlider");
        tempRed = sliderRed.GetComponent<Slider>();
        tempRed.value = 20;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 20;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 60;
    }

    public void assignViolet()
    {
        sliderRed = GameObject.Find("redSlider");
        tempRed = sliderRed.GetComponent<Slider>();
        tempRed.value = 80;

        sliderGreen = GameObject.Find("greenSlider");
        tempGreen = sliderGreen.GetComponent<Slider>();
        tempGreen.value = 0;


        sliderBlue = GameObject.Find("blueSlider");
        tempBlue = sliderBlue.GetComponent<Slider>();
        tempBlue.value = 110;
    }
}
