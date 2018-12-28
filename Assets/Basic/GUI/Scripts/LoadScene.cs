using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public bool Self;
	public int LoadSceneID;

	public void Click (){
		if (Self == true) {
			SceneManager.LoadScene (Application.loadedLevel);
		} else 
			SceneManager.LoadScene (LoadSceneID);
	}
}
