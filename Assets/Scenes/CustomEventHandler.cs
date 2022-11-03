using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI.Selectable;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Slider mainSlider;

    //Invoked when a submit button is clicked.
    public void SubmitSliderSetting()
    {
        //Displays the value of the slider in the console.
        Debug.Log(mainSlider.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
