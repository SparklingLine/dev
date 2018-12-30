using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour {

    public float density;
    public Color fogColor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player1")
        {
            RenderSettings.fogColor = fogColor;
            RenderSettings.fogDensity = density;
            if(this.gameObject.tag == "FogOn")
            {
                RenderSettings.fog = true;
            }
            else if(this.gameObject.tag == "FogOff")
            {
                RenderSettings.fog = false;
            }

        }
    }

	
}
