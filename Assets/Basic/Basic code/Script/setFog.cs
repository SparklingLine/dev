using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setFog : MonoBehaviour {

	public bool Fog = false;
	public FogMode Fogmode;
	public Color Fogcolor;

	// Use this for initialization
	void OnTriggerEnter () {
		RenderSettings.fog = Fog;
		RenderSettings.fogMode = Fogmode;
		RenderSettings.fogColor = Fogcolor;
	}
}
