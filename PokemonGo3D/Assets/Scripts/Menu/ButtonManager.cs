using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	private GameObject buttonPlay, buttonTheGame, buttonCredits;
	private Vector3 speedButton, buttonSettingsPosition, buttonPlayPosition;
	private bool canGo1, canGo2, camMove1;
	private Transform mainCameraPos, camGoTo1, camOriginalPos;
	public Canvas canvasPrincipal, loginCanvas;
	
	void Start()
	{
        loginCanvas = GameObject.Find("LoginCanvas").GetComponent<Canvas>();
		buttonPlay = GameObject.Find("PlayButton");
		buttonTheGame = GameObject.Find("TheGameButton");
		mainCameraPos = Camera.main.transform;
		camGoTo1 = GameObject.Find("TheGamePos").transform;
		camOriginalPos = GameObject.Find("OriginalPos").transform;
        PlayerPrefs.DeleteAll();
		speedButton = new Vector3 (6,0,0);
		canGo1 = true;
		canGo2 = true;
		camMove1 = false;
        loginCanvas.enabled = false;
	}

	void Update()
	{
		MoveButton();
		if(mainCameraPos.position != camGoTo1.position)
		{
			if(camMove1)
			{
				canvasPrincipal.enabled = false;
				mainCameraPos.position = Vector3.Lerp(mainCameraPos.position, camGoTo1.position, Time.deltaTime);
                mainCameraPos.rotation = Quaternion.Lerp(mainCameraPos.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime);
			}
		}
	}
	
	public void PlayGame()
	{
        if (!PlayerPrefs.HasKey("Username"))
        {
            loginCanvas.enabled = true;
            canvasPrincipal.enabled = false;
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
	}
	
	public void TheGame()
	{
		camMove1 = true;
	}
	
	public void Credits()
	{
		Debug.Log("Credits");
	}

	public void Back2Menu()
	{
        camMove1 = false;
        StartCoroutine(BackToOriginalPos());
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

    IEnumerator BackToOriginalPos()
    {
            while (Vector3.Distance(mainCameraPos.position, camOriginalPos.position) > 0.1f)
            {
                mainCameraPos.position = Vector3.Lerp(mainCameraPos.position, camOriginalPos.position, Time.deltaTime);
                mainCameraPos.rotation = Quaternion.Lerp(mainCameraPos.rotation, Quaternion.Euler(0, 270, 0), Time.deltaTime);
                yield return new WaitForSeconds(0.0001f);
            }
            canvasPrincipal.enabled = true;
            yield return 0;
    }
}
