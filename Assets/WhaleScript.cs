using UnityEngine;
using System.Collections;

public class WhaleScript : MonoBehaviour {

	private Vector3 environmentSize;
	private Vector3 environmentLocation;

	
	//to store name of player
	private float speed = 20; //to store speed of floating cell parts
	private Vector3 minVal;
	private Vector3 maxVal;
	
	private bool check = false; //to check if in coroutine or not
	private float i; //to store time lerp counter
	
	private Vector3 startLocation;
	private Quaternion startRotation;
	private Quaternion endRotation;
	private Vector3 destination;
	private Vector3 testVector = new Vector3(0,0,0); //sets testVector to 0's
	// Use this for initialization
	
	void Start () {
	
		minVal = new Vector3(-100, 0, -100);
		maxVal = new Vector3(100, 50, 100);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//run coroutine ONLY if check is FALSE 
		if (!check) { 
			
			StartCoroutine(Float()); //call blobFloat coroutine 
		}
	}
	
	/* 
	 * Name: blobFloat
	 * Description: Coroutine that creates new random destination in relation to 
	 *              the player and uses lerp so the blob can move toward that 
	 *              destination.
	 */ 
	IEnumerator Float() { 
		
		Random randomRange;
		
		check = true; //ensures coroutine doesn't run in update again
		//checks if its first time destination if being set
		if (destination == testVector) {
			
			//creates new random x, y, z location 
			destination = new Vector3(Camera.main.transform.position.x + Random.Range (minVal.x, maxVal.x),
			                          Camera.main.transform.position.y + Random.Range(minVal.y, maxVal.y), 
			                          Camera.main.transform.position.z + Random.Range(minVal.z, maxVal.z));
			
			
		}
		
		Quaternion oldRotation = this.transform.rotation;
		transform.LookAt(destination);
		Quaternion newRotation = this.transform.rotation;
		transform.rotation = oldRotation;
		
		for (i = 0.0f; i < (speed/2); i+=Time.deltaTime) {
			
		  this.transform.rotation = Quaternion.Lerp (oldRotation, newRotation, i/(speed/2));
		  yield return null;
			
		}
		
		startLocation = this.transform.position;
		
		//uses lerp to change location in duration of time
		for (i=0.0f; i<(speed-0.5); i+=Time.deltaTime ) {
			
			Vector3 location = Vector3.Lerp(startLocation, destination, i/speed );
			this.transform.position = location; //sets position to new location 
			//bone.transform.rotation = Quaternion.Lerp (startRotation, endRotation, i/speed);
			yield return null; 
			
		}
		
		destination = testVector; //resets the destination to start again
		
		
		startLocation = transform.position; //makes position the new start 
		check = false; //ensures coroutine runs again in update 
		
	}
}

