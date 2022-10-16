using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.Windows.WebCam;

public class HoloCamera : MonoBehaviour
{
    Texture2D targetTexture = null;
    CameraParameters cameraParameters = new CameraParameters();
    PhotoCapture photoCaptureObject = null;

    Resolution cameraResolution;
    GameObject quad = null;
    Renderer quadRenderer = null;
    bool isCapture = false;
    bool done = true;
    // Use this for initialization
    void Start()
    {

        //cameraResolution.width = 1440;
        //cameraResolution.height = 936;
        cameraResolution.width = 600;
        cameraResolution.height = 480;
        cameraResolution.refreshRate = 0;

        float scale = 0.001f;
        quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

        quad.transform.parent = this.transform;
        quad.transform.localPosition = new Vector3(0.0f, 0.0f, 3.0f);
        quad.transform.localScale = new Vector3(cameraResolution.width * scale, cameraResolution.height * scale, 0);

        targetTexture = new Texture2D(cameraResolution.width, cameraResolution.height);

        cameraParameters.hologramOpacity = 0.0f;
        cameraParameters.cameraResolutionWidth = cameraResolution.width;
        cameraParameters.cameraResolutionHeight = cameraResolution.height;
        cameraParameters.pixelFormat = CapturePixelFormat.BGRA32;

        quadRenderer = quad.GetComponent<Renderer>() as Renderer;
        quadRenderer.material = new Material(Shader.Find("Unlit/Texture"));

        

    }

    public void ToggleCapture()
    {
        isCapture = !isCapture;
    }
    public void TakePhoto()
    {
        PhotoCapture.CreateAsync(false, delegate (PhotoCapture captureObject) {
            photoCaptureObject = captureObject;
            // Activate the camera
            photoCaptureObject.StartPhotoModeAsync(cameraParameters, delegate (PhotoCapture.PhotoCaptureResult result) {
                // Take a picture
                photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
            });
        });
    }
    void OnCapturedPhotoToMemory(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame)
    {
        // Copy the raw image data into our target texture
        photoCaptureFrame.UploadImageDataToTexture(targetTexture);

        // apply our texture to our gameobject

        quadRenderer.material.SetTexture("_MainTex", targetTexture);

        // Deactivate our camera
        photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
    }

    void OnStoppedPhotoMode(PhotoCapture.PhotoCaptureResult result)
    {
        // Shutdown our photo capture resource
        photoCaptureObject.Dispose();
        photoCaptureObject = null;
        done = true;
    }

    void Update()
    {
        if (isCapture && done)
        {
            done = false;
            PhotoCapture.CreateAsync(false, delegate (PhotoCapture captureObject)
            {
                photoCaptureObject = captureObject;
                // Activate the camera
                photoCaptureObject.StartPhotoModeAsync(cameraParameters, delegate (PhotoCapture.PhotoCaptureResult result)
                {
                    // Take a picture
                    photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
                    
                });
            });
            
        }
    }
}