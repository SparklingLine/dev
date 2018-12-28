using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPos : MonoBehaviour {

	public MainLine MainLine;
	public Vector3 NewPos = Vector3.zero;
	public float waittime = 0;
	public float needtime = 0;
	public bool SpaceWorld = true;
	private bool Done = false;
	private Vector3 StartPos;
	private bool CheckedPos;

	void Start () {
		StartPos = this.transform.localPosition;
	}

	void Update () {
		if (MainLine.start == true) {
			if (MainLine.start_audio.time >= waittime) {
				if (MainLine.start_audio.time <= (waittime + needtime)) {
					if (Done == false) {
						if (SpaceWorld == true)
							this.transform.DOMove (NewPos, needtime, false);
						else
							this.transform.DOLocalMove (NewPos, needtime, false);
						Done = true;
					}
				} else {
					Done = false;
					if (SpaceWorld == true)
						this.transform.position = NewPos;
					else
						this.transform.localPosition = NewPos;
				}
			} else {
				Done = false;
				if (CheckedPos == false) {
					CheckedPos = true;
					this.transform.localPosition = StartPos;
				}
			}
		} else
			CheckedPos = false;
	}
}
