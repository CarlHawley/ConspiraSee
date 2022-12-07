// BasicMenu 
using UnityEngine;
using UnityEngine.UI;

public class BasicMenuBehaviour : MonoBehaviour
{   
    // delcaring game object to get slider
    [SerializeField] GameObject _sliderRed;
    [SerializeField] GameObject _sliderGreen;
    [SerializeField] GameObject _sliderBlue;
       

    public void AssignRed()
    {
        _sliderRed.GetComponent<Slider>().value = 140;

        _sliderGreen.GetComponent<Slider>().value = 5;

        _sliderBlue.GetComponent<Slider>().value = 30;
    }

    public void AssignOrange()
    {
        _sliderRed.GetComponent<Slider>().value = 180;

        _sliderGreen.GetComponent<Slider>().value = 30;

        _sliderBlue.GetComponent<Slider>().value = 15;
    }

    public void AssignYellow()
    {
        _sliderRed.GetComponent<Slider>().value = 150;

        _sliderGreen.GetComponent<Slider>().value = 110;

        _sliderBlue.GetComponent<Slider>().value = 30;
    }

    public void AssignGreen()
    {
        _sliderRed.GetComponent<Slider>().value = 10;

        _sliderGreen.GetComponent<Slider>().value = 100;

        _sliderBlue.GetComponent<Slider>().value = 90;
    }

    public void AssignBlue()
    {
        _sliderRed.GetComponent<Slider>().value = 0;

        _sliderGreen.GetComponent<Slider>().value = 40;

        _sliderBlue.GetComponent<Slider>().value = 110;
    }

    public void AssignIndigo()
    {
        _sliderRed.GetComponent<Slider>().value = 20;

        _sliderGreen.GetComponent<Slider>().value = 20;

        _sliderBlue.GetComponent<Slider>().value = 60;
    }

    public void AssignViolet()
    {
        _sliderRed.GetComponent<Slider>().value = 80;

        _sliderGreen.GetComponent<Slider>().value = 0;

        _sliderBlue.GetComponent<Slider>().value = 110;
    }
}
