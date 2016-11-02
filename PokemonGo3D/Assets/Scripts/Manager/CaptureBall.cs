using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CaptureBall : MonoBehaviour
{
    Rigidbody rb;
    bool follow;
    public GameObject player; 
    public bool berimbau = false;
	void Start ()
	{
        follow = false;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 10);
        StartCoroutine(wait());
	}

	void Update ()
	{
        if (follow)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
        }
	}

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);

        rb.velocity = Vector3.zero;
        follow = true;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (!berimbau)
            {
                player.GetComponent<PlayerScript>().captureCount++;
                GameObject.Find("Score").GetComponent<Text>().text = player.GetComponent<PlayerScript>().captureCount.ToString();
            }
            else {
                player.GetComponent<PlayerScript>().BerimbausNum++;
                GameObject.Find("Berimbaus").GetComponent<Text>().text = player.GetComponent<PlayerScript>().BerimbausNum.ToString();
            }
            Destroy(gameObject);
        }
    }
}
