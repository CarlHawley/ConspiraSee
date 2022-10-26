using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.Windows.WebCam;
using UnityEngine.Windows;
using ConspiraSee;

public class HoloCamera : MonoBehaviour
{
    Texture2D targetTexture = null;
    CameraParameters cameraParameters = new CameraParameters();
    PhotoCapture photoCaptureObject = null;

    Resolution cameraResolution;
    GameObject quad1 = null;
    GameObject quad2 = null;
    Renderer quad1Renderer = null;
    Renderer quad2Renderer = null;
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
        quad1 = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quad2 = GameObject.CreatePrimitive(PrimitiveType.Quad);

        quad1.transform.parent = this.transform;
        quad1.transform.localPosition = new Vector3(0.0f, 0.0f, 3.0f);
        quad1.transform.localScale = new Vector3(cameraResolution.width * scale, cameraResolution.height * scale, 0);

        quad2.transform.parent = this.transform;
        quad2.transform.localPosition = new Vector3(0.0f, 0.0f, 3.0f);
        quad2.transform.localScale = new Vector3(cameraResolution.width * scale, cameraResolution.height * scale, 0);

        targetTexture = new Texture2D(cameraResolution.width, cameraResolution.height);

        cameraParameters.hologramOpacity = 0.0f;
        cameraParameters.cameraResolutionWidth = cameraResolution.width;
        cameraParameters.cameraResolutionHeight = cameraResolution.height;
        cameraParameters.pixelFormat = CapturePixelFormat.BGRA32;

        quad1Renderer = quad1.GetComponent<Renderer>() as Renderer;
        quad1Renderer.material = new Material(Shader.Find("Unlit/Texture"));

        quad2Renderer = quad2.GetComponent<Renderer>() as Renderer;
        quad2Renderer.material = new Material(Shader.Find("Unlit/Transparent"));

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
        Holopic hp = new Holopic(targetTexture, new int[] {180, 0, 180}, 30);

        // apply our texture to our gameobject

        quad1Renderer.material.SetTexture("_MainTex", hp.GetBaseLayer());
        quad2Renderer.material.SetTexture("_MainTex", hp.GetStripedLayer());

        // Deactivate our camera
        photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
    }
    void OnCapturedPhotoToMemoryTester(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame)
    {
        byte[] stripes = File.ReadAllBytes(Application.dataPath + "/stripedHighlights.png");
        targetTexture.LoadImage(stripes);

        quad1Renderer.material.SetTexture("_MainTex", targetTexture);
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

    private void SaveTexture(Texture2D texture)
    {
        byte[] bytes = texture.EncodeToPNG();
        var dirPath = Application.dataPath + "/../SavedImage/";
        if(!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        File.WriteAllBytes(dirPath + "Image.png", bytes);
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