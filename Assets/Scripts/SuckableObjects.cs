using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SuckableObjects : MonoBehaviour
{
    public Rigidbody rb;
    public Transform target;
    public float force;





    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, force * Time.deltaTime);
        }


    }

    public void Upgrade()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().errorHappened == false)
        {
            StartCoroutine("ForceUpgrade");
        }
    }

    IEnumerator ForceUpgrade()
    {
        yield return new WaitForSeconds(4);

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().errorHappened == false)
        {
            force++;
        }
    }
}



        