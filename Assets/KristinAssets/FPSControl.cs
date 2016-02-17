using UnityEngine;
using System.Collections;

public class FPSControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1, ForceMode.Impulse);

        }
	}
}
