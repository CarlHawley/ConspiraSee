using UnityEngine;
using UnityEngine.UI;
using ConspiraSee;

public class FaceFrame : MonoBehaviour
{
	private static WebCamTexture s_webcamTexture;
	private static Renderer s_renderer;
	private static Holopic s_holoPic;
	private static Slider[] s_sliders;

	public int FuzzFactor; // How rapidly the holoPic selection algo decays
	public int CutoffFactor; // How tightly the holoPic selection algo selects
	public int MaxOpacityFactor; // Maximum opacity for the holopic selection algo

	// Start is called before the first frame update
	void Start()
	{
		float aspectRatio;
		Vector3 scale;

		// Get handle to holoLens webcam and begin rendering to texture
		//s_webcamTexture = new WebCamTexture(896, 504); // Magic numbers are smallest holoLens main camera resolution
		s_webcamTexture = new WebCamTexture();
		s_renderer = GetComponent<Renderer>();
		s_webcamTexture.Play();
		s_renderer.material.mainTexture = s_webcamTexture;

		// Transform parent quad to correct aspect ratio
		aspectRatio = (float)s_webcamTexture.width / (float)s_webcamTexture.height;
		scale = transform.localScale;
		scale.x = scale.y * aspectRatio;
		transform.localScale = scale;

		// Get slider handles from UI Component
		s_sliders = new Slider[3] {
			GameObject.Find("redSlider").GetComponent<Slider>(),
			GameObject.Find("greenSlider").GetComponent<Slider>(),
			GameObject.Find("blueSlider").GetComponent<Slider>()
			//fuzz factor and cutoff factor go here
		};
		
		// Create holoPic for frame processing
		s_holoPic = new Holopic(s_webcamTexture.GetPixels32(), GetColorFromSliders(), s_webcamTexture.width, s_webcamTexture.height);
	}

	int[] GetColorFromSliders()
	{
		// Extract RGB values from UI and return as int[3] {R,G,B}
		int[] colorArray = new int[3];

		for (int i = 0; i < 3; i++)
		{
			colorArray[i] = (int)s_sliders[i].value;
		}
		return colorArray;
	}


	// Update is called once per frame
	void Update()
	{
		// Manual tuning of FaceFrame position to optimize alignment, and update position per frame
		transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.67f + Camera.main.transform.up * -0.04f; 
		transform.rotation = Camera.main.transform.rotation;

		// Get next frame from camera and reprocess the new image with the selected color
		s_holoPic.ReprocessImage(s_webcamTexture.GetPixels32(), GetColorFromSliders(), FuzzFactor, CutoffFactor, MaxOpacityFactor);
		// Render new color selection frame to parent quad
		s_renderer.material.mainTexture = s_holoPic.GetStripedLayer();			
		
	}
}