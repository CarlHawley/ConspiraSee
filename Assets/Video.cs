using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using ConspiraSee;

public class Video : MonoBehaviour
{
	WebCamTexture webtex;
	Renderer renderer;
	GameObject quad1 = null;
	GameObject quad2 = null;
	Renderer quad1Renderer = null;
	Renderer quad2Renderer = null;
	Holopic hp;
	Texture2D snapshot;
	int count;


	bool enabled = true;

	// Start is called before the first frame update
	void Start()
	{
		webtex = new WebCamTexture(640, 480);
		renderer = GetComponent<Renderer>();
		renderer.material = new Material(Shader.Find("Unlit/Texture"));
		webtex.Play();
		renderer.material.mainTexture = webtex;

		quad1 = GameObject.CreatePrimitive(PrimitiveType.Quad);
		quad1.transform.parent = this.transform;
		quad1.transform.localPosition = new Vector3(1.0f, 0.0f, 0.0f);
		quad1.transform.localScale = new Vector3(0.5f, 0.5f, 0);
		quad1Renderer = quad1.GetComponent<Renderer>() as Renderer;
		quad1Renderer.material = new Material(Shader.Find("Unlit/Texture"));

		quad2 = GameObject.CreatePrimitive(PrimitiveType.Quad);
		quad2.transform.parent = this.transform;
		quad2.transform.localPosition = new Vector3(-1.0f, 0.0f, 0.0f);
		quad2.transform.localScale = new Vector3(0.5f, 0.5f, 0);
		quad2Renderer = quad2.GetComponent<Renderer>() as Renderer;
		quad2Renderer.material = new Material(Shader.Find("Unlit/Transparent"));

		snapshot = new Texture2D(640, 480);
		snapshot.SetPixels32(webtex.GetPixels32());
		snapshot.Apply();
		hp = new Holopic(snapshot, new int[] { 3, 29, 132 }, 10);




	}
	// Update is called once per frame
	void Update()
	{
        if (enabled && count > 120)
        {
			snapshot.SetPixels32(webtex.GetPixels32());
			snapshot.Apply();
			hp = new Holopic(snapshot, new int[] { 3, 29, 132 }, 10);
			quad1Renderer.material.SetTexture("_MainTex", hp.GetBaseLayer());
			quad2Renderer.material.SetTexture("_MainTex", hp.GetStripedLayer());
			count = count % 120;
			//enabled = false;
			
		}
        else
        {
			if (count > 120)
				count = count % 120;
        }
		count++;
		
	}
}