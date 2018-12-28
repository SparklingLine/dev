using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class AnimationInfo : MonoBehaviour {

	public List<string> AnimationsName = new List<string> ();
	private Animation AniCom;

	public void Start (){
		AniCom = this.GetComponent<Animation> ();
		InvokeRepeating ("UpdateInfo", 0f, 1f);
	}

	public void UpdateInfo(){
		AnimationsName.Clear ();
		foreach (AnimationState state in AniCom){
			AnimationsName.Add (state.name);
		}
	}
}
