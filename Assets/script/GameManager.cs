using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public static GameManager instance = null;

	public static int m_score = 0;
	public static int m_hscore = 0;


	private int LayerInt;

	int life = 1;

	public Transform _btnGroup;
	public Transform _imgGameOver;

	Cube player;
	GUIText txt_score;
	GUIText txt_hscore;
	// Use this for initialization
	void Start () {

		//获得并激活按钮,获得没用啊，还是得在inspector里面设定；
		//_btnGroup = GameObject.Find ("btnGroup").transform;
		_btnGroup.gameObject.SetActive (false);
		_imgGameOver.gameObject.SetActive (false);

		instance = this;



		//获取UI层的Layer Id
		LayerInt = LayerMask.NameToLayer ("UI");
		txt_score = this.transform.FindChild("txt-score").GetComponent<GUIText>();
		txt_hscore = this.transform.FindChild("txt-hscore").GetComponent<GUIText>();
		
		m_score = 0;
		txt_hscore.text = "Best: " + m_hscore;


	
	}
	
	// Update is called once per frame
	void Update () {

		//处理按钮点击事件；
//
//		if (Input.GetMouseButtonDown(0)) {
//
//			Vector3 mouseVector3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//			RaycastHit2D hit;
//
//			hit = Physics2D.Raycast(Camera.main.transform.position,mouseVector3,100,1<<LayerInt);
//
//			if (hit.collider!=null) {
//				Debug.Log (hit.collider.name);
//
//				Debug.DrawLine(Camera.main.transform.position,hit.point,Color.red,1);
//
//				switch (hit.collider.name) {
//				case "btnStart":
//					GameStart();
//					break;
//				default:
//					break;
//				
//				}
//				
//			}
//
//		}

		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			if(Physics.Raycast(ray,out hitInfo))
			{
				Debug.DrawLine(ray.origin,hitInfo.point);
				GameObject gameObj = hitInfo.collider.gameObject;
				Debug.Log("click object name is " + gameObj.name);
				if(gameObj.name == "btnStart")
				{
					Debug.Log("pick up!");
					GameStart();
				}
			}
		}
	}
	
	public void SetScore()
	{
		
		m_score += 1;

		txt_score.text = "Score: " + m_score;
		
	}
	public void SetScore(int score)
	{
		
		m_score += score;
		
		txt_score.text = "Score: " + m_score;
		
	}
	public void SetHScore()
	{
		if (m_score>m_hscore) {

			m_hscore = m_score;
		}

		txt_hscore.text = "Best: " + m_hscore;
	
	}
	public void GameOver()
	{
	
		Debug.Log ("Game Over");
		_btnGroup.gameObject.SetActive (true);
		_imgGameOver.gameObject.SetActive (true);

		Time.timeScale = 0;

		life = 0;

	}

	void OnGUI()
	{
		if (life==0) {

//			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
//			GUI.skin.label.fontSize = 40;
//			
//			
//			GUI.Label (new Rect (0, 0, Screen.width, Screen.height), "Game Over!");

//			if (GUI.Button(new Rect (Screen.width*0.5f-75, Screen.height*0.7f-45,150,40), "Try Again")) {
//				GameStart();
//
//			}
		}


	}

	void GameStart()
	{

		_btnGroup.gameObject.SetActive (false);
		Application.LoadLevel(Application.loadedLevelName);
		Time.timeScale = 1;

	}
}











