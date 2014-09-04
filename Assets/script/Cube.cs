using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
	//move speed
	public float m_speed = 1000.0f;

	public int location;

	GameObject[] m_Players;


	// Use this for initialization
	void Start () {


		if (m_Players == null)
			m_Players = GameObject.FindGameObjectsWithTag("Player");
	
		if (location==1) {
			gameObject.transform.position = new Vector3(-0.55f,-8f,0);
		}
		if (location==2) {
			gameObject.transform.position = new Vector3(0.5f,-8f,0);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//float movex = 0;



		if (Input.touchCount>0) {
			Debug.Log (Input.touchCount.ToString());
			}

		//没有按键或触摸
		if (!Input.anyKey && Input.touchCount==0) {

	
			if (location==1 ) {
				gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,new Vector3(-0.55f,-8f,0),1);
			}
			if (location==2) {
				gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,new Vector3(0.5f,-8f,0),1);
			}
				}

		if (Input.GetKey (KeyCode.W)) {

			gameObject.transform.Translate (new Vector3(0,m_speed*Time.deltaTime,0));

		}

		if (Input.GetKey (KeyCode.S)) {
			
			gameObject.transform.Translate (new Vector3(0,-m_speed*Time.deltaTime,0));

			
		}
		if (Input.touchCount>0) {

			Vector2 realWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Debug.Log (realWorldPos.x.ToString()+"-------------"+Input.GetTouch(0).position.x.ToString());

			if (Input.touchCount==1) {

				if (realWorldPos.x<0) {
					MoveL ();
				}
				else {
					MoveR ();
				}

			}
			else {
				MoveLR ();
			}

		}

		//A或者触摸左边
		if (Input.GetKey (KeyCode.A)) {

			MoveL ();
						
		}
		if (Input.GetKey (KeyCode.D)) {
			
			MoveR();
			
		}

		if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.A)) {

				//Debug.Log("D and A");

			MoveLR ();


		}

	

		//移动






		//if enemy , destroy






	}

	void MoveL()
	{
		if (location==1 ) {
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,new Vector3(-6.01f,gameObject.transform.position.y,0),1);
		}
		if (location==2) {
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,new Vector3(-4.96f,gameObject.transform.position.y,0),1);
		}

	}

	void MoveR()
	{
		if (location==1 ) {
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,new Vector3(5f,gameObject.transform.position.y,0),1);
		}
		if (location==2) {
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,new Vector3(6.05f,gameObject.transform.position.y,0),1);
		}
	}

	void MoveLR()
	{
		if (location==1 ) {
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,new Vector3(-6.01f,gameObject.transform.position.y,0),1);
		}
		if (location==2) {
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,new Vector3(6.05f,gameObject.transform.position.y,0),1);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log (collision.collider.name);
		
		if (collision.collider.tag == "Enemy") {

			foreach (GameObject obj in m_Players) {

				Destroy (obj);

			}

			GameManager.instance.GameOver();

		}
	}


	void OnTirggerEnter()
	{


	}
}
