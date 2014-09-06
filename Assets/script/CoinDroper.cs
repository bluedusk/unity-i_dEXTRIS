using UnityEngine;
using System.Collections;

public class CoinDroper : MonoBehaviour {

	public Transform _coin;
	
	public float timeInterval = 1.0f;
	

	public float[] dropLocation = new float[3];
	
	int spawnLocationIndex = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		timeInterval -= Time.deltaTime;
		
		
		spawnLocationIndex = Random.Range (0,3);
		
		if (timeInterval<=0) {
			Instantiate (_coin,new Vector3(dropLocation[spawnLocationIndex], transform.position.y,0), transform.rotation);
			timeInterval = 1.0f;
		}
		
		
	}
	
	
	void OnDrawGizmos()
	{
		
		Gizmos.DrawIcon (transform.position,"item.png",true);
		
	}
}
