using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour {

	public GameObject ContinueUI;
	public MainLine MainLine;

	public void Click () {
		MainLine.GoToEaster ();
		ContinueUI.SetActive (false);
	}
}
