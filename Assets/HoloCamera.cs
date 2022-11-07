using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.Windows.WebCam;

public class HoloCamera : MonoBehaviour
{

    public int width;
    public int height;
    public float scale;


    Texture2D targetTexture = null;
    CameraParameters cameraParameters = new CameraParameters();
    PhotoCapture photoCaptureObject = null;

    Resolution cameraResolution;
    GameObject quad = null;
    Renderer quadRenderer = null;
    bool isCapture = false;
    bool done = true;
    float offset = 0.0f;
    // Use this for initialization
    void Start()
    {
        cameraResolution.width = this.width;
        cameraResolution.height = this.height;
        cameraResolution.refreshRate = 0;

        quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

        quad.transform.parent = this.transform;
        quad.transform.localPosition = new Vector3(0.0f, 0.0f, 3.0f);
        quad.transform.localScale = new Vector3(cameraResolution.width * this.scale, cameraResolution.height * this.scale, 0);

        targetTexture = new Texture2D(cameraResolution.width, cameraResolution.height);

        cameraParameters.hologramOpacity = 0.0f;
        cameraParameters.cameraResolutionWidth = cameraResolution.width;
        cameraParameters.cameraResolutionHeight = cameraResolution.height;
        cameraParameters.pixelFormat = CapturePixelFormat.BGRA32;

        quadRenderer = quad.GetComponent<Renderer>() as Renderer;
        quadRenderer.material = new Material(Shader.Find("Unlit/Texture"));

        

    }

    
    public void extractPhoto()
    {
        GameObject quad2 = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quad2.transform.parent = this.transform;
        quad2.transform.localPosition = new Vector3(5.0f, 0.0f, offset);
        quad2.transform.localScale = quad.transform.localScale;
        Renderer quad2Renderer = quad2.GetComponent<Renderer>() as Renderer;
        quad2Renderer.material = new Material(Shader.Find("Unlit/Texture"));
        Texture2D target2 = new Texture2D(cameraResolution.width, cameraResolution.height);
        Graphics.CopyTexture(targetTexture, target2);
        quad2Renderer.material.SetTexture("_MainTex", target2);
        offset += 1.0f;
    }


    public void ToggleCapture()
    {
        isCapture = !isCapture;
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