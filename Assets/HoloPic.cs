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
					Debug.Log("Color: R" + baseImageColors[i].r + "' G" + baseImageColors[i].g + "' B" + baseImageColors[i].b);
					Debug.Log(dist);
				}
				else if (dist < 100 + fuzz) { stripedLayerArray[i].a = 126; }
				else { stripedLayerArray[i].a = 0; }
			}
			stripes.SetPixels32(stripedLayerArray);
			stripes.Apply();
			return stripes;
		}

		private double ColorDistance(Color32 currentPix, int[] target)
		{
            return Math.Sqrt(Math.Pow(currentPix[0] - target[0], 2) + Math.Pow(currentPix[1] - target[1], 2) + Math.Pow(currentPix[2] - target[2], 2));
		}
		public void setDisplay(DisplayEnum displaySetting)
		{
			this.displayLayers = displaySetting;
		}

		public DisplayEnum getDisplayEnum()
		{
			return displayLayers;
		}

		public void setDisplayEnum(DisplayEnum newDisplayEnum)
		{
			this.displayLayers = newDisplayEnum;
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