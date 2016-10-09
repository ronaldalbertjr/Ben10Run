using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour 
{
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			Debug.Log("colliding");
			Application.LoadLevel("Game");
		}
	}
}
