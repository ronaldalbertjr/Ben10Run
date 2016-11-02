using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
	private Rigidbody rb;
	private Animator anim;
	[SerializeField] private float Axisz,Axisy,Speed,jumpSpeed;
    private bool animCheck;
    private Vector3 velocityAux;
    private bool capoeira = false;
	private AudioSource camAudio;
	public AudioClip capoeiraSound, moonWalkSound, normalSound;
	private bool moonwalk;
   [SerializeField] bool jumping;
   [SerializeField] AnimationClip jumpAnim,capoeiraAnim;
   [SerializeField] GameObject sphere;
   [HideInInspector] public int captureCount;
    public int BerimbausNum;
	void Start ()
	{
        BerimbausNum = 0;
        captureCount = 0;
        rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator> ();
		Speed = 1;
		Axisy = 180;
        jumping = false;
		moonwalk = false;
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
			if(velocityAux == new Vector3(0,0,0))
				anim.SetFloat("Walking2", 0);
			if(moonwalk)
			{
				if(camAudio.clip != moonWalkSound)
				{
					camAudio.clip = moonWalkSound;
					camAudio.Play();
				}
				moonwalk = false;
			}
			else if(!moonwalk)
			{
				if(camAudio.clip == moonWalkSound)
				{
					camAudio.clip = normalSound;
					camAudio.Play();
				}
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
			moonwalk = true;
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
                if (BerimbausNum > 0)
                {
                    anim.SetTrigger("Capoeira");
                    capoeira = true;
                    camAudio.PlayOneShot(capoeiraSound);
                    StartCoroutine(capoeirafinish(coll.gameObject));
                    BerimbausNum--;
                }
                else StartCoroutine(NoBerimbau(coll.gameObject));
            }
        }
        else if (coll.gameObject.tag== "Pokestop")
        {
            if (Input.GetKeyDown(KeyCode.Return) && !capoeira)
            {
                anim.SetTrigger("Capoeira");
                capoeira = true;
                camAudio.PlayOneShot(capoeiraSound);
                StartCoroutine(Pokestopfinish(coll.gameObject));
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
    IEnumerator Pokestopfinish(GameObject obj)
    {
        yield return new WaitForSeconds(capoeiraAnim.length);
        capoeira = false;      
        for (int i = 0;i<3;i++)
        { 
           GameObject g = Instantiate(sphere, obj.transform.position, Quaternion.identity) as GameObject;
           g.GetComponent<CaptureBall>().berimbau = true;
            g.GetComponent<CaptureBall>().player = this.gameObject;
            yield return new WaitForSeconds(0.5f);
        }
        obj.SetActive(false);
        yield return new WaitForSeconds(300);
        obj.SetActive(true);
    }
    IEnumerator NoBerimbau(GameObject alien)
    {
        GameObject.Find("BerimbauText").GetComponent<Text>().text = "Você não possui berimbau para capturar esse alien";
        yield return new WaitForSeconds(5);
        GameObject.Find("BerimbauText").GetComponent<Text>().text = "";
        Destroy(alien, 25);
    }
}
