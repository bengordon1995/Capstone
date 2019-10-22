using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payload : MonoBehaviour
{
    public GameObject player;
    public GameObject payload;
    public GameObject[] checkpoints;
    public int currentTarget;
    public float payloadSpeed;
    public float payloadTargetProximity;
    public float playerPayloadProximity;
    // Start is called before the first frame update
    void Start()
    {
        currentTarget = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget == -1 || Vector3.Distance(player.transform.position, payload.transform.position) > playerPayloadProximity)//no objects to go to or player not close enough
        {
            return;
        }
        if (Vector3.Distance(payload.transform.position, checkpoints[currentTarget].transform.position)<payloadTargetProximity)//within x units of each other
        {
            currentTarget += 1;
            if (currentTarget == checkpoints.Length)//already reached the last one
            {
                currentTarget = -1;
                return;
            }
        }
        Vector3 direction = (checkpoints[currentTarget].transform.position - payload.transform.position).normalized;//get direction of where to go
        payload.transform.Translate(direction * payloadSpeed * Time.deltaTime);
    }
}
