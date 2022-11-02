namespace ConspiraSee
{
	using System;
	using UnityEngine;
	using UnityEngine.Windows;

	public class Holopic
	{
		private Texture2D baseLayer, stripedLayer;
		private DisplayEnum displayLayers;

		public Holopic(Color32[] original, int[] selectedColor, int fuzz, int width, int height)
		{
			this.baseLayer = new Texture2D(width, height);
			this.baseLayer.SetPixels32(original,0);
			this.baseLayer.Apply();
			processImage(original, selectedColor, fuzz);
			this.displayLayers = DisplayEnum.BOTH;
		}

		private void processImage(Color32[] original, int[] selectedColor, int fuzz)
		{
			int cutoff = 50;
			Color32[] baseImageColors = original;
			GameObject.Destroy(this.stripedLayer);
			this.stripedLayer = new Texture2D(this.baseLayer.width, this.baseLayer.height);
			double dist;
			if (File.Exists(Application.dataPath + "/stripedHighlights_600x480.png"))
			{
				byte[] stripeFile = File.ReadAllBytes(Application.dataPath + "/stripedHighlights_600x480.png");
				this.stripedLayer.LoadImage(stripeFile);
			}
			else
			{
				Debug.Log("404: Stripe File Not Found");
			}
			Color32[] stripedLayerArray =this.stripedLayer.GetPixels32(0);
			for (int i = 0; i < stripedLayerArray.Length; i++)
			{
				dist = ColorDistance(baseImageColors[i], selectedColor);

				if (dist < cutoff)
				{
					stripedLayerArray[i].a = 255;
				}
				else if (dist < (cutoff + fuzz)) {
					int alpha = (int)(-(255 / (double)fuzz) * (dist - (fuzz + cutoff)));
					stripedLayerArray[i].a = (byte)alpha;
				}
				else {
					stripedLayerArray[i].a = 0; 
				}
			}
			this.stripedLayer.SetPixels32(stripedLayerArray, 0);
			this.stripedLayer.Apply();
		}


		// Calculates the cartesian distance between colors
		private double ColorDistance(Color32 currentPix, int[] target) //max is 764.834
		{
			double redmean = (0.5 * (currentPix.r + target[0]));
			double d_r = currentPix.r - target[0];
			double d_g = currentPix.g - target[1];
			double d_b = currentPix.b - target[2];
			double c = Math.Sqrt((2 + (redmean / 256)) * (d_r * d_r) + 4 * d_g * d_g + (2 + (255 - redmean) / 256) * d_b * d_b);
			return c;
			//return compositeDistance(vectorDist(currentPix, target));
		}

		// Vector-wise distance function between a Color/Color32 object and an int array
		private int[] vectorDist(Color32 a, int[] b) =>
			new int[] { a.r - b[0], a.g - b[1], a.b - b[2], 12 };

		// Unary cartesian distance function for int array
		private int compositeDistance(int[] a) =>
		(int)Math.Sqrt(a[0] * a[0] + a[1] * a[1] + a[2] * a[2]);

		public void ReprocessImage(Color32[] texture, int[] selectedColor, int fuzz)
		{
			processImage(texture, selectedColor, fuzz);
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