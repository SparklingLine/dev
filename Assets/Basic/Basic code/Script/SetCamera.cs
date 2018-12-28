using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera : MonoBehaviour {

	public Camera Camera;
	public CameraClearFlags ClearFlags = CameraClearFlags.Skybox;
	public Color Color;

	// Use this for initialization
	void OnTriggerEnter () {
		Camera.clearFlags = ClearFlags;
		Camera.backgroundColor = Color;
	}
}
