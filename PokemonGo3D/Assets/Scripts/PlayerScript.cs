using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	private Rigidbody rb;
	private Animator anim;
	[SerializeField] private float Axisz,Axisy,Speed;
	[SerializeField] private Animation anima;
    private bool animCheck;
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
        animCheck = Axisz != 0;
        anim.SetBool("IsWalking", animCheck);

        UpdateWalk();
        UpdateCapoeira();
        UpdateRotation();

        transform.Translate (0, 0, Axisz * Speed * Time.deltaTime);
	}
    
    void UpdateWalk()
    {
        if (Axisz > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Speed = 1.57f;
                anim.SetFloat("Walking2", 1);
            }
            else
            {
                Speed = 1;
                anim.SetFloat("Walking2", 0);
            }
        }
        else if (Axisz < 0)
        {
            anim.SetFloat("Walking2", -1);
        }
    }

    void UpdateCapoeira()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Capoeira", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Capoeira", false);
        }
    }
    void UpdateRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.AngleAxis(Axisy, transform.up);
            Axisy += Speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.AngleAxis(Axisy, transform.up);
            Axisy -= Speed;
        }
    }
}
