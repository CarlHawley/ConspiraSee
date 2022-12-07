using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Threading.Tasks;
using ConspiraSee;
using UnityEngine.Scripting;
/*
public class Video : MonoBehaviour
{
	WebCamTexture webtex;
	Renderer renderer;
	//GameObject quad1 = null;
	//GameObject quad2 = null;
	//Renderer quad1Renderer = null;
	//Renderer quad2Renderer = null;
	Holopic hp;
	Texture2D snapshot;
	int count;

	int[] color;

	Slider[] sliders;
	bool enabled = true;

	// Start is called before the first frame update
	void Start()
	{
		sliders = new Slider[3];
		sliders[0] = GameObject.Find("redSlider").GetComponent<Slider>();
		sliders[1] = GameObject.Find("greenSlider").GetComponent<Slider>();
		sliders[2] = GameObject.Find("blueSlider").GetComponent<Slider>();
		color = updateColor(sliders);
		webtex = new WebCamTexture(896, 504);
		//webtex = new WebCamTexture(640, 480);
		renderer = this.GetComponent<Renderer>() as Renderer ;
		//renderer.material = new Material(Shader.Find("Unlit/Transparent"));
		webtex.Play();
		renderer.material.mainTexture = webtex;
		float aspectratio = (float)webtex.width / (float)webtex.height;
		Vector3 scale = transform.localScale;
		scale.x = scale.y * aspectratio;
		transform.localScale = scale;
		
		/*quad1 = GameObject.CreatePrimitive(PrimitiveType.Quad);
		quad1.transform.parent = this.transform;
		quad1.transform.localPosition = new Vector3(0.0f, 0.0f, 0.5f);
		quad1.transform.localScale = new Vector3(1.0f, 1.0f, 0);
		quad1Renderer = quad1.GetComponent<Renderer>() as Renderer;
		quad1Renderer.material = new Material(Shader.Find("Unlit/Texture"));*/

		/*quad2 = GameObject.CreatePrimitive(PrimitiveType.Quad);
		quad2.transform.parent = this.transform;
		quad2.transform.localPosition = new Vector3(-1.0f, 0.0f, 0.0f);
		quad2.transform.localScale = new Vector3(0.5f, 0.5f, 0);
		quad2Renderer = quad2.GetComponent<Renderer>() as Renderer;
		quad2Renderer.material = new Material(Shader.Find("Unlit/Transparent"));
		*/
		//snapshot = new Texture2D(640, 480);
		//snapshot.SetPixels32(webtex.GetPixels32());
		//snapshot.Apply();
		//hp = new Holopic(webtex.GetPixels32(),color, 10, webtex.width, webtex.height);
		//renderer.material.mainTexture = hp.GetStripedLayer();

	//}*/
	/*
	int[] updateColor(Slider[] sliderArray)
	{

		int[] colorArray = new int[3];

		for (int i = 0; i < 3; i++)
		{
			colorArray[i] = (int)sliderArray[i].value;
		}
		return colorArray;
	}


	// Update is called once per frame
	void Update()
	{
		transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.67f + Camera.main.transform.up * -0.04f;
		transform.rotation = Camera.main.transform.rotation;

        if (enabled)
        {
			//snapshot.SetPixels32(webtex.GetPixels32());
			//snapshot.Apply();
			hp.ReprocessImage(webtex.GetPixels32(),updateColor(sliders),50);
			//quad1Renderer.material.SetTexture("_MainTex", hp.GetBaseLayer());
			//quad2Renderer.material.SetTexture("_MainTex", hp.GetStripedLayer());
			renderer.material.mainTexture = hp.GetStripedLayer();

			//enabled = false;
			
		}
		
	}
}*/