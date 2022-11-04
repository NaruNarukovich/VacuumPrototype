using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public Rigidbody rb;
    public Transform target;
    public float force;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
            transform.LookAt(target);
            rb.AddForce(transform.forward * force);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
