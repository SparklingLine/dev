using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Share : MonoBehaviour {

	public GameObject OverTab;

	public void Click (){
		ScreenCapture.CaptureScreenshot (Application.dataPath + "GUIScreenShot");
		OverTab.SetActive (false);
		ScreenCapture.CaptureScreenshot (Application.dataPath + "NoGUIScreenShot");
		OverTab.SetActive (true);
	}
}
