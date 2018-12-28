using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.LoadLevelAdditiveAsync ("The Prelude");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
