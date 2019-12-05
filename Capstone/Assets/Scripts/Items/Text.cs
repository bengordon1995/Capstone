using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text : Item
{
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

        StartCoroutine(displayMessage());
        
    }

    IEnumerator displayMessage()
    {
        this.GetComponent<GUIText>().text = "Testing";
        yield return new WaitForSeconds(2);
        this.GetComponent<GUIText>().text = "";
 

    }
}
