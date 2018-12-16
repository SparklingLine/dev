using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class build_road : MonoBehaviour {

    public GameObject cube;
    public int roadWidth;
    //private MainLine MainLineCom;
    private GameObject road;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
           // road = Instantiate(cube, new Vector3(cube.transform.position.x, cube.transform.position.y - 1, cube.transform.position.z), cube.transform.rotation);
            //road.transform.localScale = new Vector3(cube.transform.localScale.x + roadWidth, 1f, cube.transform.localScale.z + roadWidth);
        }
    }
}
