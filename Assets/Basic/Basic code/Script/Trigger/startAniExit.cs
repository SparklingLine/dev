using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAniExit : MonoBehaviour {

	public GameObject Animation;
	public string AniClipName;
	private AnimationInfo AnimationInfoCom;
	private Animation AnimationCom;
	private bool Done = false;

	void Start (){
		AnimationCom = Animation.GetComponent<Animation> ();
	}

	void OnTriggerExit (Collider other){
		if (Done != true){
			Done = true;
			AnimationCom.Play (AniClipName, PlayMode.StopAll);
		}
	}
}
