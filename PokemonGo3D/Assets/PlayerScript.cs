using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	private Rigidbody rb;
	private Animator anim;
	[SerializeField] private float Axisz,Axisy,Speed;
	[SerializeField] private Animation anima;
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		Speed = 1;
		Axisy = 180;

	}

	void Update ()
	{
		Axisz = Input.GetAxis ("Vertical");
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			Speed = 1.57f;
			anim.SetInteger("Walking", 3);
		}
		else if (Input.GetKeyUp (KeyCode.LeftShift)) {
			Speed = 1;
			anim.SetInteger("Walking", 1);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Capoeira", true);
		}
		else if (Input.GetKeyUp (KeyCode.Space)) {
			anim.SetBool ("Capoeira",false);
		}

		if (Input.GetKey ("right")) {
			transform.rotation = Quaternion.AngleAxis(Axisy, transform.up);
			Axisy += Speed ;
		}
		if (Input.GetKey ("left")) {
			transform.rotation = Quaternion.AngleAxis(Axisy , transform.up);
			Axisy-=Speed; 
		}
		if (Axisz == 0) {
			anim.SetInteger ("Walking", 0);
		} else if (Axisz < 0) {
			anim.SetInteger ("Walking", 2);
		} else if (Axisy > 0) {
			anim.SetInteger("Walking",1);
		}
		transform.Translate (0, 0, Axisz * Speed * Time.deltaTime);
	}
}
