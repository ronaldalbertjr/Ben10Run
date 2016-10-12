using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    float time;
    void Update()
    {
        time += Time.deltaTime;
        InstantiateSpawner(ref time, prefab);
    }
    void InstantiateSpawner(ref float time, GameObject prefab)
    {
        if(time > 180)
        {
            Instantiate(prefab, new Vector3(Random.Range(-70f, 0.065f), 0, Random.Range(-60f,0)), new Quaternion(0, 0, 0, 0));
            time = 0;
        }
    }
}
