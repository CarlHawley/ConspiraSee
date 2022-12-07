using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
[ExecuteAlways]
public class CanvasElementVisibility : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    [SerializeField]
    private bool _visible;
    public bool Visible
    {
        get => _visible;
        set
        {
            _visible = value;
            if (_visible) ShowElement();
            else HideElement();
        }
    }

    private void OnValidate()
    {
        if (Visible) ShowElement();
        else HideElement();
    }

    private void ShowElement()
    {
        if (!_canvasGroup) _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    private void HideElement()
    {
        if (!_canvasGroup) _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
