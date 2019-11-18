using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Item
{
    public GameObject[] items;
    public float spawnX = 0f;
    public float spawnY = 0f;
    public float spawnZ = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(items[Random.Range(0, items.Length)], new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
