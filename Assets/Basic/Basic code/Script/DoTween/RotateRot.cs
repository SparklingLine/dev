using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateRot : MonoBehaviour {

	public MainLine MainLine;
	public Vector3 NewRot = Vector3.zero;
	public float waittime = 0;
	public float needtime = 0;
	public bool SpaceWorld = true;
	private bool Done = false;
	private Vector3 StartRot;
	private bool CheckedRot;

	void Start () {
		StartRot = this.transform.localEulerAngles;
	}

	void Update () {
		if (MainLine.start == true) {
			if (MainLine.start_audio.time >= waittime) {
				if (MainLine.start_audio.time <= (waittime + needtime)) {
					if (Done == false) {
						if (SpaceWorld == true)
							this.transform.DORotate (NewRot, needtime);
						else
							this.transform.DOLocalRotate (NewRot, needtime);
						Done = true;
					}
				} else {
					Done = false;
					if (SpaceWorld == true)
						this.transform.eulerAngles = NewRot;
					else
						this.transform.localEulerAngles = NewRot;
				}
			} else {
				Done = false;
				if (CheckedRot == false) {
					CheckedRot = true;
					this.transform.localEulerAngles = StartRot;
				}
			}
		} else
			CheckedRot = false;
	}
}
