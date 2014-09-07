using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {


	public float m_speed = 1f;

	//add audio for coin
	public AudioClip _coinClip;
	protected AudioSource _audio;

	
	int scored = 0;
	public int m_scroe = 5;
	// Use this for initialization
	void Start () {

		_audio = this.audio;
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
		Debug.Log ("i'm a coin , i collided with "+collision.collider.name);
		
		if (collision.collider.name == "BottomEdge") {
			Destroy (this.gameObject);
			
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("i'm a coin , i collided with "+other.name);

		if (other.tag=="Player") {

			GameManager.instance.SetScore(m_scroe);

			//_audio.PlayOneShot(_coinClip);

			AudioSource.PlayClipAtPoint(_coinClip,this.transform.position);

			Destroy (this.gameObject);

		}
	}
}
