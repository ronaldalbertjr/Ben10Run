using UnityEngine;
using System.Collections;

public class SpawnBen10AlienScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] aliens;
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Instantiate(aliens[Random.Range(0, aliens.Length - 1)], this.transform.position, this.transform.rotation);
        }
    }
}
