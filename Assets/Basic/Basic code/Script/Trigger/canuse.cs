using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canuse : MonoBehaviour {

	public MainLine Line;
	public bool use;
	public bool IsStop;
	public bool start;
	public bool Over;

	void OnTriggerEnter (Collider Other)
	{
		if (Other.tag == "line") {
			Line.canuse = use;
			Line.Is_Stop = IsStop;
			Line.Over = Over;
			Line.start = start;
		}
	}
}
