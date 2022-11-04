using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public bool LookAtTarget = false;
    public Transform target;

    public Rigidbody rb;
    public float speed;

    public float distance;

    void Update()
    {
        if (LookAtTarget)
        {
            transform.LookAt(target);
        }

        if (target.GetComponent<Rigidbody>().velocity != Vector3.zero) 
        {
            if (Vector3.Distance(transform.position, target.position) > distance) 
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
            }
            else 
            {
                rb.velocity = Vector3.zero;
            }
            
        }
        else 
        {
            rb.velocity = Vector3.zero;
        }
    }
}
