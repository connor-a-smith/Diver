using UnityEngine;
using System.Collections;

public class TrashGenerator : MonoBehaviour {

    public double delay = .5;
    private double remainingTime;

    public Vector2 origin;
    public Vector2 dimensions;

    public float spawnHeight;

    Object[] prefabs;

    public int totalTrash = 0;
    public int collectedTrash = 0;

    //The amount of trash needed to reach peak dirtiness.
    public int maxTrashToDirtiness = 50;

    //This proportion indicates how dirty the ocean is.
    public float trashProportion = 0;

	public GameObject GUIWindow;


	//debug collision
	//private bool stop = false;

	private bool endSceneStart = false;

    // Use this for initialization
    void Start()
    {
        string folderPath = Application.dataPath + "/TrashPrefabs";

        prefabs = Resources.LoadAll("TrashPrefabs");

        //Generate 100 pieces of trash to start.
        for (int i = 0; i < 100; i++)
        {
            generateGarbage();
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (trashProportion < .96 && !endSceneStart) {
			GUIWindow.SetActive (true);
			remainingTime = 5;
			endSceneStart = true;
		}

		if (endSceneStart == true) {
			remainingTime -= Time.deltaTime;
			//If the timer expired, then create a new object.
			if (remainingTime < 0) {
				GUIWindow.SetActive (false);
				remainingTime = delay;

				//debug purposes
				//if (totalTrash == 100) {
				//	stop = true;
				//}
				//debug purposes
				//if (stop != true) {
				//	generateGarbage();
				//}
				if (totalTrash < 1000) {
					generateGarbage ();
				}
			}
		}
	}

    void generateGarbage()
    {
        totalTrash++;

        //Return proportion of 0 up to 1.
        trashProportion = Mathf.Min(((float) totalTrash) / ((float)maxTrashToDirtiness), 1);

        //Location the object will spawn at.
        Vector3 spawnPosition = new Vector3(Random.Range(origin.x, dimensions.x), spawnHeight, Random.Range(origin.y, dimensions.y));
        //Debug.Log(spawnPosition);    


        //Create the actual object.
        GameObject newObject = (GameObject) Object.Instantiate(prefabs[Random.Range(0, prefabs.Length)], spawnPosition, new Quaternion());

        //If it doesn't have the trashscript, add it so that it collides with player.
        if (!newObject.GetComponent<TrashScript>())
        {
            newObject.AddComponent<TrashScript>();
        }
    }

    public void trashDestroyed()
    {
        totalTrash--;
        trashProportion = Mathf.Min(((float)totalTrash) / ((float)maxTrashToDirtiness), 1);
        //Debug.Log ("DELETED!!!");
        //Debug.Log ("Total Trash: " + totalTrash);
        //Debug.Log ("Max Trash To Dirtiness: " + maxTrashToDirtiness);
        //Debug.Log ("New Proportion: " + trashProportion);
        //Change color.
    }
}
