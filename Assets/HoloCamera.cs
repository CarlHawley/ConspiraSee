using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloCamera : MonoBehaviour
{
    WebCamTexture webcam;
    // Start is called before the first frame update
    void Start()
    {
        webcam = new WebCamTexture();
        webcam.Play();
        Debug.LogFormat("webcam: {0} {1} x {2}", webcam.deviceName, webcam.width, webcam.height);
    }

    public Texture2D TakePhoto()
    {
        Debug.Log("take photo");
        Texture2D webcamImage = new Texture2D(webcam.width, webcam.height);
        webcamImage.SetPixels(webcam.GetPixels());
        return webcamImage;
    }
    public void TakePhotoToPreview(Renderer preview)
    {
        Texture2D image = TakePhoto();
        preview.material.mainTexture = image;
        float aspetRatio = (float)image.width / (float)image.height;
        Vector3 scale = preview.transform.localScale;
        scale.x = scale.y * aspetRatio;
        preview.transform.localScale = scale;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
