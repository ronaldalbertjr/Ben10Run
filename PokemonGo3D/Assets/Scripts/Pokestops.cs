using UnityEngine;
using System.Collections;

public class Pokestops : MonoBehaviour {

    float randX, randY,randZ;
    [SerializeField] float speed = 5;
	void Start()
    {
        randX = Random.Range(-1, 1);
        randY = Random.Range(-1, 1);
        randZ = Random.Range(-1, 1);

    }
	// Update is called once per frame
	void Update () {
        RotationPlanet();
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            GetComponent<MeshRenderer>().enabled = true; 
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
    void RotationPlanet()
    {
        Vector3 rand = new Vector3(randX, randY, randZ);
        transform.Rotate(rand*speed*Time.deltaTime);
    }
}
