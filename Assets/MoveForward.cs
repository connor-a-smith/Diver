using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	  Camera.main.transform.parent = this.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	  this.transform.position += (Camera.main.transform.forward * speed);
	
	}
}
