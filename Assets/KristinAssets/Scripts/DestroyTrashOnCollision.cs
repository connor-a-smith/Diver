using UnityEngine;
using System.Collections;

public class DestroyTrashOnCollision : MonoBehaviour {
    public TrashGenerator generator;

	// Use this for initialization
	void Start () {
        if (!generator)
        {
            generator = GameObject.Find("TrashController").GetComponent<TrashGenerator>();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<TrashScript>())
        {
            Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();

            generator.trashDestroyed();
        }
    }
}
