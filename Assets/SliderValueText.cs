using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
    [SerializeField] private Slider _slider = null;
    [SerializeField] private Text _textComp = null;
    // Start is called before the first frame update

    private void Start()
    {
        LoadValues();
    }
    public void UpdateSliderText(float value) {
        _textComp.text = value.ToString();
    }

    public void SaveValue() {
        float sliderValue = _slider.value;
        PlayerPrefs.SetFloat("Slider Value", sliderValue);
        Debug.Log(sliderValue);
        LoadValues();
    }

    void LoadValues() {
        float sliderValue = PlayerPrefs.GetFloat("Slider Value");
        _slider.value = sliderValue;
    }
}
