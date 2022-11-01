namespace ConspiraSee
{
	using System;
	using UnityEngine;
	using UnityEngine.Windows;

	public class Holopic
	{
		private Texture2D baseLayer, stripedLayer;
		private DisplayEnum displayLayers;

		public Holopic(Texture2D original, int[] selectedColor, int fuzz)
		{
			this.baseLayer = original;
			this.stripedLayer = processImage(original, selectedColor, fuzz);
			this.displayLayers = DisplayEnum.BOTH;
		}

		private Texture2D processImage(Texture2D original, int[] selectedColor, int fuzz)
		{
			Color32[] baseImageColors = original.GetPixels32(0);
			Debug.Log(original.width);
			Debug.Log(original.height);
			Debug.Log(baseImageColors.Length);
			Texture2D stripes = new Texture2D(original.width, original.height);
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
			Debug.Log(stripes.width);
			Debug.Log(stripes.height);
			Color32[] stripedLayerArray = stripes.GetPixels32(0);
			Debug.Log(stripedLayerArray.Length);
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
			stripes.SetPixels32(stripedLayerArray, 0);
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
		(int)Math.Sqrt(a[0] * a[0] + a[1] * a[1] + a[2] * a[2]);

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