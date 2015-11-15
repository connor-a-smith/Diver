using UnityEngine;
using System.Collections;

public class DebugRay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	  Debug.DrawRay (this.transform.position, this.transform.forward);
	
	}
}
