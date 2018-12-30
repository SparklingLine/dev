using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorController : MonoBehaviour {

    public Color TargetColor;
    public CubeMovement player;

	private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player1")
        {
            player.targetColor = TargetColor;
            player.colorChange = true;
        }
    }
}
