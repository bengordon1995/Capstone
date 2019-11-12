using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleItem : Item
{
    public float scaleX = 0.5f;
    public float scaleY = 0.5f;
    public float scaleZ = 0.5f;
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
        GameObject.Find("Player").transform.localScale += new Vector3 (scaleX, scaleY, scaleZ);

    }


}
