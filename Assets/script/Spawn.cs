using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {


	public Transform enemy;

	public float timeInterval = 2.0f;


	public float[] spawnLocation = new float[3];

	int spawnLocationIndex = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		timeInterval -= Time.deltaTime;


		spawnLocationIndex = Random.Range (0,3);

		if (timeInterval<=0) {
			Instantiate (enemy,new Vector3(spawnLocation[spawnLocationIndex], transform.position.y,0), transform.rotation);
		
			timeInterval = 2.0f;
			}

	
	}


	void OnDrawGizmos()
	{

		Gizmos.DrawIcon (transform.position,"item.png",true);

	}
}
