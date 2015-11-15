using UnityEngine;
using System.Collections;

public class ParentCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
      Camera.main.transform.parent = this.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
