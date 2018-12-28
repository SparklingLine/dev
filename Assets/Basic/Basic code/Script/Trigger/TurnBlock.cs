using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBlock : MonoBehaviour {

	public MainLine MainLine;
	private bool ok;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (ok == false && other.GetComponent<MainLine> () != null) {
			MainLine.TurnBlock ();
			Debug.Log ("OK");
			ok = true;
		}
	}
}
