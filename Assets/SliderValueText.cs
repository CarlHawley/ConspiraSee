using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
    [SerializeField] private Slider slider = null;
    [SerializeField] private Text textComp = null;
    // Start is called before the first frame update

    private void Start()
    {
        LoadValues();
    }
    public void sliderStart(float value) {
        textComp.text = value.ToString("0");
    }

    public void saveValue() {
        float sliderValue = slider.value;
        PlayerPrefs.SetFloat("Slider Value", sliderValue);
        Debug.Log(sliderValue);
        //LoadValues();
    }

    void LoadValues() {
        float sliderValue = PlayerPrefs.GetFloat("Slider Value");
        slider.value = sliderValue;

    }
}
