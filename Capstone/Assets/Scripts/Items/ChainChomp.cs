using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainChomp : Item
{
    public GameObject ChainChompPrefab;
    private GameObject lastChain;

    private float x;
    private float y;
    private float z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    protected override void powerUpAction()
    {
        Instantiate(ChainChompPrefab, new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, GameObject.Find("Player").transform.position.z), Quaternion.identity);
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        ChainChompPrefab.transform.GetChild(4).GetComponent<WheelJoint2D>().connectedBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        
    }
}
