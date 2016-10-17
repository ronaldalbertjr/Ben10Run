using UnityEngine;
using System.Collections;

public class SpawnBen10AlienScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] aliens;
    void Start()
    {
        StartCoroutine("DestroySpawner");
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Instantiate(aliens[Random.Range(0, aliens.Length)], this.transform.position, this.transform.rotation);
			Destroy(this.gameObject);
        }
        if (col.tag=="AlienSpawner")
        {
            Destroy(col.gameObject);
        }
    }
    IEnumerator DestroySpawner()
    {
        yield return new WaitForSeconds(600);
        Destroy(this.gameObject);
    }
}
