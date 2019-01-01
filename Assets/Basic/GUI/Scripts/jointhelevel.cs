using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//岩
public class jointhelevel : MonoBehaviour {

	public LevelControl LevelControl;

	public void Click () {
		SceneManager.LoadSceneAsync (LevelControl.NowSceneID);
	}
}
