using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour 
{
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			Debug.Log("colliding");
            SceneManager.LoadScene("Game");
		}
	}
}
