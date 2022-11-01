using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public class Video : MonoBehaviour
{
    WebCamTexture webtex;
    Color32[] data;
	Texture2D stripes;
	Renderer renderer;
	int[] selectedColor = { 180, 100, 180 };
	int fuzz = 30;
	bool enabled = false;
	// Start is called before the first frame update
	void Start()
    {
		stripes = new Texture2D(2, 2);
		if (File.Exists(Application.dataPath + "/stripedHighlights_600x480.png"))
		{
			byte[] stripeFile = File.ReadAllBytes(Application.dataPath + "/stripedHighlights_600x480.png");
			stripes.LoadImage(stripeFile);
		}
		else
		{
			Debug.Log("404: Stripe File Not Found");
		}

		webtex = new WebCamTexture(640, 480);
        renderer = GetComponent<Renderer>();
		webtex.Play();
		data = webtex.GetPixels32();
	}
    // Update is called once per frame
    void Update()
    {
		if (webtex.didUpdateThisFrame)
		{
			webtex.GetPixels32(data);
			processImage(webtex.GetPixels32(), stripes.GetPixels32());
			//renderer.material.mainTexture = webtex;
			renderer.material.mainTexture = stripes;
		}
		

    }
	async private void processImage(Color32[] baseImageColors, Color32[] stripedLayerArray)
	{
		await Task.Run(() =>
		{
			double dist;
			//Debug.Log(baseImageColors.Length);
			for (int i = 0; i < stripedLayerArray.Length; i++)
			{
				dist = ColorDistance(baseImageColors[i], selectedColor);

				if (dist < 100)
				{
					stripedLayerArray[i].a = 255;
					//Debug.Log(baseImageColors[i].ToString());
					//Debug.Log(dist);
				}
				else if (dist < 100 + fuzz) { stripedLayerArray[i].a = 126; }
				else { stripedLayerArray[i].a = 0; }
			}
			
			//stripes.Apply();
		});
		stripes.SetPixels32(stripedLayerArray);
		stripes.Apply();

	}


	// Calculates the cartesian distance between colors
	private double ColorDistance(Color32 currentPix, int[] target)
	{
		return compositeDistance(vectorDist(currentPix, target));
	}

	// Vector-wise distance function between a Color/Color32 object and an int array
	private int[] vectorDist(Color32 a, int[] b) =>
		new int[] { a.r - b[0], a.g - b[1], a.b - b[2], 12 };

	// Unary cartesian distance function for int array
	private int compositeDistance(int[] a) =>
	(int)System.Math.Sqrt(a[0] * a[0] + a[1] * a[1] + a[2] * a[2]);
}
