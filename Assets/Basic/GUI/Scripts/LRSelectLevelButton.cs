using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRSelectLevelButton : MonoBehaviour {

	public LevelControl Control;
	public GameObject LevelButtons;
	public bool Left = true;

	public void Click () {
		if (Left == true) {
			if (LevelButtons.transform.Find ((Control.NowLevelID - 1).ToString ()) != null) {
				LevelButtons.transform.Find ((Control.NowLevelID - 1).ToString ()).GetComponent<SelectLevel> ().Click ();
			}
		} else {
			if (LevelButtons.transform.Find ((Control.NowLevelID + 1).ToString ()) != null) {
				LevelButtons.transform.Find ((Control.NowLevelID + 1).ToString ()).GetComponent<SelectLevel> ().Click ();
			}
		}
	}
}
