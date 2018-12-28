using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelectLevel : MonoBehaviour {

	public LevelControl GameControl;
	public float To;

	public void Click () {
		GameControl.SelectLevel (this.gameObject, To);
	}
}