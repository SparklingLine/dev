using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitContinue : MonoBehaviour {

	public MainLine MainLine;
	public GameObject ContinueUI;

	public void click () {
		MainLine.OverTab.SetActive (true);
		MainLine.OverTab.GetComponent<GameOverControl> ().GameOver (false, MainLine.NowPercentage, MainLine.PickDiamondCount, MainLine.GetPickCrownCount());
		ContinueUI.SetActive (false);
	}
}
