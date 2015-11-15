using UnityEngine;
using System.Collections;

public class Swim : MonoBehaviour {

    public float forwardMag;
    
    private const float deltaThresh = 0.0001f;
    private const float speed = 0.5f;
    
    private Vector3 forwardPosition = new Vector3(0,0,0);
    private Vector3 startingPosition;
         
    private float oldDistanceBetween;
    private float newDistanceBetween;
    
    private float delta = 0;
    private float oldDelta = 0;
    private float deltaDelta = 0;
    
    private Vector3 playerDelta;
    private Vector3 oldPlayerLoc;
    private Vector3 newPlayerLoc;
    
    private GameObject child;
    public GameObject parent;
        
    public GameObject playerCamera;
    public GameObject forwardObject;
    //private GameObject 
    
    private float lowestDistance = 0;
    
	// Use this for initialization
	void Start () {
	
	  forwardPosition = getForwardPosition();
	  newPlayerLoc = playerCamera.transform.position;
	  oldPlayerLoc = newPlayerLoc;
	  //distanceBetween = Mathf.Abs(Vector3.Distance (forwardPosition, forwardObject.transform.position));
	
	}
	
	// Update is called once per frame
	void Update () {
	
	  Debug.Log ("PARENT LOC: " + parent.transform.position);
	  Debug.Log ("THIS LOC: " + this.transform.position);
	  
	
	  //newPlayerLoc = playerCamera.transform.position;
	  //playerDelta = newPlayerLoc - oldPlayerLoc;
	  
      newDistanceBetween = Vector3.Distance(this.transform.localPosition,
		                                      startingPosition);
		                                      
	  delta = Mathf.Abs(newDistanceBetween - oldDistanceBetween);
	  
	  //deltaDelta = Mathf.Abs (delta - oldDelta);
	  

	  if (delta < deltaThresh) {
	   
	    startingPosition = this.transform.localPosition;
	    //Debug.Log ("Local Position: " + this.transform.localPosition);
	   // Debug.Log ("Starting Position: " + ;
	   
	  }
	  
	  else {
	 
	    playerCamera.GetComponent<Rigidbody>().AddForce ((-1 * forwardObject.transform.forward * delta * speed), ForceMode.Impulse);
	    Debug.Log ("DELTA: " + deltaDelta);
	  }
	  
	  /*
	  Vector3 currPosition = forwardObject.transform.position;
	  float newDistanceBetween = Mathf.Abs (Vector3.Distance (currPosition, forwardPosition));
	  
	  forwardPosition = getForwardPosition();
      distanceBetween = Mathf.Abs (Vector3.Distance(currPosition, forwardPosition));
	  */	
	  
		
	  
	  oldDistanceBetween = newDistanceBetween;
	  oldDelta = delta;
	  oldPlayerLoc = newPlayerLoc;
	  
	  
	}
	
	Vector3 getForwardPosition() {
	
	  return this.transform.localPosition + (forwardObject.transform.forward * forwardMag);
	
	}
}