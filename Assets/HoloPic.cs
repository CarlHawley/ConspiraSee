namespace ConspiraSee
{
	using System;
	using UnityEngine;
	using UnityEngine.Windows;

	public class Holopic
	{
		private Texture2D _baseLayer, _stripedLayer;
		private DisplayEnum _displayLayers;

		public Holopic(Color32[] original, int[] selectedColor, int width, int height) : this(original, selectedColor, width, height, 50, 10, 200) { }
		public Holopic(Color32[] original, int[] selectedColor, int width, int height, int fuzz, int cutoff, int maxOpacity)
		{
			this._baseLayer = new Texture2D(width, height);
			this._baseLayer.SetPixels32(original, 0);
			this._baseLayer.Apply();
			this._displayLayers = DisplayEnum.BOTH;
			processImage(original, selectedColor, fuzz, cutoff, maxOpacity);
		}


		// Run color selection algorithm for given pixel array
		private void processImage(Color32[] original, int[] selectedColor, int fuzz, int cutoff, int maxOpacity)
		{
			double dist;
			Color32[] baseImageColors = original;
			GameObject.Destroy(this._stripedLayer); // preventing memory leak
			this._stripedLayer = new Texture2D(this._baseLayer.width, this._baseLayer.height);
			
			if (File.Exists(Application.dataPath + "/stripedHighlights_896x504.png"))
			{
				byte[] stripeFile = File.ReadAllBytes(Application.dataPath + "/stripedHighlights_896x504.png");
				this._stripedLayer.LoadImage(stripeFile);

				// Solving texture size mismatch when testing in unity on nonhololens camera
				if (this._stripedLayer.width > this._baseLayer.width || this._stripedLayer.height > this._baseLayer.height)
                {
					Color[] temp = this._stripedLayer.GetPixels(0, 0, this._baseLayer.width, this._baseLayer.height);
					this._stripedLayer = new Texture2D(this._baseLayer.width, this._baseLayer.height);
					this._stripedLayer.SetPixels(temp);
					this._stripedLayer.Apply();
                }
			}
			else
			{
				//Debug.Log("404: Stripe File Not Found");
			}
			Color32[] stripedLayerArray = this._stripedLayer.GetPixels32(0);

			// Selection loop
			// Maximum opacity until reaching cutoff distance, then linear falloff untill cutoff + fuzz.
			for (int i = 0; i < stripedLayerArray.Length; i++)
			{
				dist = ColorDistance(baseImageColors[i], selectedColor);

				if (dist < cutoff)
				{
					stripedLayerArray[i].a = (byte)maxOpacity;
				}
				else if (dist < (cutoff + fuzz)) {
					int alpha = (int)(-(maxOpacity / (double)fuzz) * (dist - (fuzz + cutoff)));
					stripedLayerArray[i].a = (byte)alpha;
				}
				else {
					stripedLayerArray[i].a = 0; 
				}
			}
			// Apply modified pixels to layer
			this._stripedLayer.SetPixels32(stripedLayerArray, 0);
			this._stripedLayer.Apply();
		}


		// Calculates the redmean modified cartesian distance between colors
		private double ColorDistance(Color32 currentPix, int[] target) // [0, ~764.834]
		{
			double redmean = (0.5 * (currentPix.r + target[0]));
			double d_r = currentPix.r - target[0];
			double d_g = currentPix.g - target[1];
			double d_b = currentPix.b - target[2];
			double c = Math.Sqrt((2 + (redmean / 256)) * (d_r * d_r) + 4 * d_g * d_g + (2 + (255 - redmean) / 256) * d_b * d_b);
			return c;
		}

		// Other distance functions, currently depreciated:

		// Vector-wise distance function between a Color/Color32 object and an int array
		private int[] vectorDist(Color32 a, int[] b) =>
			new int[] { a.r - b[0], a.g - b[1], a.b - b[2], 12 };

		// Unary cartesian distance function for int array
		private int compositeDistance(int[] a) =>
			(int)Math.Sqrt(a[0] * a[0] + a[1] * a[1] + a[2] * a[2]);

		// End other distance funtions

		// Re-render image, for use in FaceFrame
		public void ReprocessImage(Color32[] texture, int[] selectedColor, int fuzz, int cutoff, int maxOpacity)
		{
			processImage(texture, selectedColor, fuzz, cutoff, maxOpacity);
		}

		public void SetDisplay(DisplayEnum displaySetting)
		{
			this._displayLayers = displaySetting;
		}

		public DisplayEnum GetDisplayEnum()
		{
			return this._displayLayers;
		}

		public Texture2D GetBaseLayer()
		{
			return this._baseLayer;
		}

		public Texture2D GetStripedLayer()
		{
			return this._stripedLayer;
		}

	}


	public enum DisplayEnum { BOTH, NEITHER, BASE, STRIPES }
}