using UnityEngine;
using System.Collections;

public class bottomedge : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{



	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log (collision.collider.name);

		Destroy (collision.collider);
	}
}
