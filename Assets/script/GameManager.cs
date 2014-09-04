using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public static GameManager instance = null;

	public static int m_score = 0;

	int life = 1;

	Cube player;
	GUIText txt_score;
	// Use this for initialization
	void Start () {

		instance = this;
		txt_score = this.transform.FindChild("txt-score").GetComponent<GUIText>();


	
	}
	
	// Update is called once per frame
	void Update () {
	
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
	public void GameOver()
	{
	
		Debug.Log ("Game Over");
		Time.timeScale = 0;

		life = 0;



	}

	void OnGUI()
	{
		if (life==0) {

			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.fontSize = 40;
			
			
			GUI.Label (new Rect (0, 0, Screen.width, Screen.height), "Game Over!");

			if (GUI.Button(new Rect (Screen.width*0.5f-75, Screen.height*0.7f-45,150,40), "Try Again")) {
				Application.LoadLevel(Application.loadedLevelName);
				Time.timeScale = 1;

			}
		}


	}
}











