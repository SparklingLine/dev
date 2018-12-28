using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour {

	public int LevelID;
	public int SceneID;
	public string LevelNameZh_CN;
	public string LevelNameEn;
	public AudioClip Audio;
	[HideInInspector]public int Progress;
	[HideInInspector]public int Diamond;
	public int MaxDiamond;
	[HideInInspector]public int Crown;

}
