using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    private bool isLerping = false;
    public GameObject _camera;
    public GameObject CamPos;
    public float speed = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isLerping)
        {
            _camera.transform.position = Vector3.Slerp(_camera.transform.position, CamPos.transform.position, speed * Time.deltaTime);
            _camera.transform.rotation = Quaternion.Slerp(_camera.transform.rotation, CamPos.transform.rotation, speed * Time.deltaTime);
            //_camera.transform.position = CamPos.transform.position;
            //_camera.transform.rotation = CamPos.transform.rotation;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isLerping = true;
            Debug.Log("trigger");
        }        
    }
}
