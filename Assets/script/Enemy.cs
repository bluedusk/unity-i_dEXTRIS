using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float m_speed = 1f;

	int scored = 0;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		//向下移动

		gameObject.transform.Translate (new Vector3(0,-m_speed*Time.deltaTime,0));



		//加分条件
		if (this.transform.position.y<=-8.0f && scored==0) {

			Debug.Log ("score++");

			GameManager.instance.SetScore();

			scored=1;
			}

	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log (collision.collider.name);

		if (collision.collider.name == "BottomEdge") {
			Destroy (this.gameObject);

				}
	}
}
