﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformAttach : MonoBehaviour
{

	public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.transform.position;
    }
}
