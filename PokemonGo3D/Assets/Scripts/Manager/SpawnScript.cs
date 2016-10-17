using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
   [SerializeField] private GameObject[] points;

    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("SpawnPoint");
        StartCoroutine(InstantiateSpawner(prefab));
    }

    IEnumerator InstantiateSpawner(GameObject prefab)
    {
        while (true)
        {
            Instantiate(prefab,points[Random.Range(0,points.Length)].transform.position, new Quaternion(0, 0, 0, 0));
            yield return new WaitForSeconds(30);
        }
    }
}
