using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	private Rigidbody rb;
	private Animator anim;
	[SerializeField] private float Axisz,Axisy,Speed,jumpSpeed;
    private bool animCheck;
    Vector3 velocityAux;
    bool capoeira = false;
	private AudioSource camAudio;
	public AudioClip capoeiraSound, moonWalkSound, normalSound;
   [SerializeField] bool jumping;
   [SerializeField] AnimationClip jumpAnim,capoeiraAnim;
   [SerializeField] GameObject sphere;
   [HideInInspector] public int captureCount;

	void Start ()
	{
        captureCount = 0;
        rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator> ();
		Speed = 1;
		Axisy = 180;
        jumping = false;
		camAudio = Camera.main.GetComponent<AudioSource> ();
	}

	void FixedUpdate ()
	{
        if (!capoeira)
        {
            Axisz = Input.GetAxis("Vertical");
            animCheck = Axisz != 0;
            anim.SetBool("IsWalking", animCheck);

            UpdateWalk();
            //UpdateCapoeira();
            UpdateRotation();

            velocityAux = transform.forward * Axisz * Speed;
            velocityAux.y = rb.velocity.y;
            rb.velocity = velocityAux;
            if(Input.GetKeyDown(KeyCode.Space) && !jumping)
            {
                Jumping();
                StartCoroutine(jumpFinish());
            }
        }
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
  
    void Jumping()
    {
        anim.SetTrigger("Jumping");
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        jumping = true;
    }
   
    void UpdateRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.AngleAxis(Axisy, transform.up);
            Axisy += Speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.AngleAxis(Axisy, transform.up);
            Axisy -= Speed;
        }
    }

    IEnumerator jumpFinish()
    {
        yield return new WaitForSeconds(jumpAnim.length);
        jumping = false;    
    }

    void OnTriggerStay (Collider coll)
    {
        if (coll.gameObject.tag == "Alien")
        {
            if (Input.GetKeyDown(KeyCode.Return) && !capoeira)
            {
                anim.SetTrigger("Capoeira");
                capoeira = true;
				camAudio.PlayOneShot(capoeiraSound);
                StartCoroutine(capoeirafinish(coll.gameObject));
            }
        }
    }

    IEnumerator capoeirafinish( GameObject obj)
    {
        yield return new WaitForSeconds(capoeiraAnim.length);
        capoeira = false;
        Instantiate(sphere, obj.transform.position, Quaternion.identity);
        Destroy(obj.gameObject);        
    }
}
