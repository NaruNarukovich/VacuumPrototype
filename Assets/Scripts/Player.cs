using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private FixedJoystick joystick;
    public float speed;
    
    public bool errorHappened = true;
    public float distance;
    public Transform target;
    public float impulse;
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }

        if(Vector3.Distance(transform.position, target.position) > distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, impulse);
            //rb.velocity = Vector3.zero;
        }
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Money")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Rope Upgrade")
        {
            errorHappened = false;
        }
        if (collision.gameObject.tag == "Force Upgrade")
        {
            errorHappened = false;

            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Money").Length; i++) 
            {
                GameObject.FindGameObjectsWithTag("Money")[i].GetComponent<SuckableObjects>().Upgrade();
            }
        }

    }

 

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Force Upgrade")
        {
            errorHappened = true;
        }
        if (collision.gameObject.tag == "Rope Upgrade")
        {
            errorHappened = true;
        }
    }

    
}
