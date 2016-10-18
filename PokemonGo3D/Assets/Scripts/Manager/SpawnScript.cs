using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
	[SerializeField] private GameObject[] points;
	public GameObject[] spawedAlienObj;
	public Text aliensClose;

    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("SpawnPoint");
        StartCoroutine(InstantiateSpawner(prefab));
    }

	void Update()
	{
		spawedAlienObj = GameObject.FindGameObjectsWithTag ("Alien");
		if (spawedAlienObj.Length >= 1)
			aliensClose.text = "Tem alien nos arrepores";
		else
			aliensClose.text = "";
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
