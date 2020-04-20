using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject enemy;
    public static float delay;
    
    
    // Start is called before the first frame update
    void Start()
    {
        delay = 2f;
        StartCoroutine("Spawn");
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
        
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            int Pos = Random.Range(0, spawners.Length);
            Transform position = spawners[Pos].transform;
            GameObject Enemy =Instantiate(enemy, position.transform);
            yield return new WaitForSeconds(delay);
        }
    }

}
