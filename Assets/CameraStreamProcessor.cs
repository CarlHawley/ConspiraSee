using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class CameraStreamProcessor : MonoBehaviour
{
    public int Width;
    public int Height;
    public int Scale;

    private Texture2D _targetTexture;
    private CameraParameters _cameraParameters;
    private PhotoCapture _photoCaptureObject;
    private Resolution _cameraResolution;
    private bool _isCapturing;
    private bool _ready;

    // Start is called before the first frame update
    void Start()
    {
        this._isCapturing = false;
        this._ready = false;
        _cameraParameters = new CameraParameters();
        _photoCaptureObject = null;

        _cameraResolution.width = this.Width;
        _cameraResolution.height = this.Height;
        _cameraParameters.cameraResolutionWidth = this.Width;
        _cameraParameters.cameraResolutionHeight = this.Height;

        _cameraResolution.refreshRate = 0;
        _cameraParameters.hologramOpacity = 0.0f;
        _cameraParameters.pixelFormat = CapturePixelFormat.BGRA32;

        _targetTexture = new Texture2D(_cameraResolution.width * this.Scale, _cameraResolution.height * this.Scale); 
    }

    // Update is called once per frame
    void Update()
    {
        if (_isCapturing && _ready)
        {
            _ready = false;
            PhotoCapture.CreateAsync(false, delegate (PhotoCapture captureObject)
            {
                _photoCaptureObject = captureObject;
                //Activate camera
                _photoCaptureObject.StartPhotoModeAsync(_cameraParameters, delegate (PhotoCapture.PhotoCaptureResult result)
                {
                    //Take picture
                    _photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
                });
            });
        }
    }

    private void OnCapturedPhotoToMemory(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame)
    {
        //copy to texture
        photoCaptureFrame.UploadImageDataToTexture(_targetTexture);
        //deactivate camera
        _photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
    }

    private void OnStoppedPhotoMode(PhotoCapture.PhotoCaptureResult result)
    {
        //shutdown
        _photoCaptureObject.Dispose();
        _photoCaptureObject = null;
        _ready = true;
    }

    public void ToggleCapture()
    {
        this._isCapturing = !this._isCapturing;
    }
    public void SetCapture(bool isCapturing)
    {
        this._isCapturing = isCapturing;
    }
    public Texture2D GetShallowTexture()
    {
        return _targetTexture;
    }
    public Texture2D GetDeepTexture()
    {
        Texture2D result = new Texture2D(_cameraResolution.width * this.Scale, _cameraResolution.height * this.Scale);
        Graphics.CopyTexture(_targetTexture, result);
        return result;
    }
}
