namespace ConspiraSee
{
	using System;
	using UnityEngine;
	using UnityEngine.Windows;

	public class Holoframe : MonoBehaviour
	{
		
		private GameObject canvas, button1, button2, quad1, quad2;
		private Renderer render1, render2;

		private float scale = 0.001f;

		public Holoframe(Vector3 position, Holopic image)
		{
			GameObject myGo = new GameObject();
			canvas = myGo.GetComponent<Canvas>();
			quad1 = GameObject.CreatePrimitive(PrimitiveType.Quad);
			quad2 = GameObject.CreatePrimitive(PrimitiveType.Quad);
			quad1.transform.parent = canvas.transform;
			quad2.transform.parent = canvas.transform;
			quad1.transfrom.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
			quad2.transfrom.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
			quad1.transform.localScale = new Vector3(600*scale, 400*scale, 0);
			quad2.transform.localScale = new Vector3(600*scale, 400*scale, 0);
			canvas.transform.localScale = new Vector3(650*scale, 400*scale, 0);

			render1 = quad1.GetComponent<Renderer>() as Renderer;
			render1.Material = new Material(Shader.Find("Unlit/Texture"));

			render2 = quad2.GetComponent<Renderer>() as Renderer;
			render2.Material = new Material(Shader.Find("Unlit/Transparent"));

			render1.Material.SetTexture("_MainTex", image.GetMainLayer());
			render2.Material.SetTexture("_MainTex", image.GetStripedLayer());

		}

		private Texture2D processImage(Texture2D original, int[] selectedColor, int fuzz)
		{
            Color32[] baseImageColors = original.GetPixels32();
			Texture2D stripes = new Texture2D(2, 2);
			double dist;
			if (File.Exists(Application.dataPath + "/stripedHighlights_600x480.png"))
			{
				byte[] stripeFile = File.ReadAllBytes(Application.dataPath + "/stripedHighlights_600x480.png");
				stripes.LoadImage(stripeFile);
			}
			else
			{
				Debug.Log("404: Stripe File Not Found");
			}
			Color32[] stripedLayerArray = stripes.GetPixels32();
			Debug.Log(baseImageColors.Length);
			for ( int i = 0; i < stripedLayerArray.Length; i++ )
			{
				dist = ColorDistance(baseImageColors[i], selectedColor);

				if (dist < 100)
				{
					stripedLayerArray[i].a = 255;
					Debug.Log(baseImageColors[i].ToString());
					Debug.Log(dist);
				}
				else if (dist < 100 + fuzz) { stripedLayerArray[i].a = 126; }
				else { stripedLayerArray[i].a = 0; }
			}
			stripes.SetPixels32(stripedLayerArray);
			stripes.Apply();
			return stripes;
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
		(int)Math.Sqrt(a[0]*a[0] + a[1]*a[1] + a[2]*a[2]);

        public void ReprocessImage(Texture2D texture, int[] selectedColor, int fuzz)
        {
            this.stripedLayer = processImage(texture, selectedColor, fuzz);
        }
        public void SetDisplay(DisplayEnum displaySetting)
		{
			this.displayLayers = displaySetting;
		}

		public DisplayEnum GetDisplayEnum()
		{
			return displayLayers;
		}

		public Texture2D GetBaseLayer()
		{
			return this.baseLayer;
		}

		public Texture2D GetStripedLayer()
		{
			return this.stripedLayer;
		}
		
	}

	
	public enum DisplayEnum { BOTH, NEITHER, BASE, STRIPES }
}