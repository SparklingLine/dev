using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

	public MainLine MainLine;
	public Sprite PauseSprite;
	public Sprite ContinueSprite;

	public void Start () {
		InvokeRepeating ("ButtonRenderer", 0f, 3f);
	}

	public void Click () {
		MainLine.PC ();
		if (MainLine.Pause == true) {
			this.GetComponent<Image> ().sprite = ContinueSprite;
		} else {
			this.GetComponent<Image> ().sprite = PauseSprite;
		}
	}

	public void ButtonRenderer () {
		this.gameObject.SetActive(!MainLine.Over);
	}
}