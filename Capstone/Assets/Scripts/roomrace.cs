using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomrace : MonoBehaviour
{
    public GameObject[] checkpoints;//create some empty game objects and move them where you want the enemy to move to
    public float distanceToTarget;//distance to each checkpoint before it moves to the next
    public int currentTarget;
    public float speed;
    public GameObject targetItem;//should be the item its moving toward
    public bool collected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget == -1 || collected)
        {
            return;
        }
        if (Vector3.Distance(transform.position, checkpoints[currentTarget].transform.position) < distanceToTarget)//within x units of each other
        {
            currentTarget += 1;
            if (currentTarget == checkpoints.Length)//already reached the last one
            {
                currentTarget = -1;
                collected = true;
                targetItem.SetActive(false);
                return;
            }
        }
        Vector3 direction = (checkpoints[currentTarget].transform.position - transform.position).normalized;//get direction of where to go
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
