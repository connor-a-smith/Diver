using UnityEngine;
using System.Collections;

public class FogScript : MonoBehaviour {

    public GameObject trashController;
    public TrashGenerator trashGenerator;
    private float alphaStart;



	// Use this for initialization
	void Start () {
	
	  trashGenerator = trashController.GetComponent<TrashGenerator>();
	  alphaStart = this.GetComponent<ParticleSystem>().startColor.a;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	  Color tempColor = this.GetComponent<ParticleSystem>().startColor;
	  tempColor.a = ((trashGenerator.trashProportion - 0.95f) * 10 * alphaStart);
	  this.GetComponent<ParticleSystem>().startColor = tempColor;
	
	}
}
