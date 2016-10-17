using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
	private GameObject buttonPlay, buttonTheGame, buttonCredits;
	private Vector3 speedButton, buttonSettingsPosition, buttonPlayPosition;
	private bool canGo1, canGo2;
	private Transform mainCameraPos, camGoTo1, camOriginalPos;
	public Canvas canvasPrincipal;
	
	void Start()
	{
		buttonPlay = GameObject.Find("PlayButton");
		buttonTheGame = GameObject.Find("TheGameButton");
		//buttonCredits = GameObject.FindGameObjectWithTag("ButtonCredits");
		mainCameraPos = Camera.main.transform;
		camGoTo1 = GameObject.Find("TheGamePos").transform;
		camOriginalPos = GameObject.Find("OriginalPos").transform;
		
		speedButton = new Vector3 (6,0,0);
		canGo1 = true;
		canGo2 = true;
	}

	void Update()
	{
		MoveButton();
	}
	
	public void PlayGame()
	{
		Application.LoadLevel("Game");
	}
	
	public void TheGame()
	{
		canvasPrincipal.enabled = false;
		mainCameraPos.position = Vector3.MoveTowards(mainCameraPos.position, camGoTo1.position, 10);
		mainCameraPos.Rotate(0, 270, 0);
	}
	
	public void Credits()
	{
		Debug.Log("Credits");
	}

	public void Back2Menu()
	{
		mainCameraPos.position = Vector3.MoveTowards(mainCameraPos.position, camOriginalPos.position, 10);
		mainCameraPos.Rotate(0, 90, 0);
		canvasPrincipal.enabled = true;
	}
	
	void MoveButton()
	{
		if (canGo1)
		{	
			buttonPlay.transform.position -= speedButton;
			if(buttonPlay.transform.position.x  <= (Screen.width / 2))
				canGo1 = false;
		}
		if (canGo2)
		{
			buttonTheGame.transform.position += speedButton;
			if(buttonTheGame.transform.position.x >= (Screen.width / 2))
				canGo2 = false;
		}
	}
}
