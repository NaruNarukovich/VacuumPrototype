using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeForce : MonoBehaviour
{
    public bool errorHappened = true;
    GameObject player;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            errorHappened = false;
            StartCoroutine("SpeedBoost");

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            errorHappened = true;
        }
    }

    IEnumerator SpeedBoost()
    {
        if( errorHappened == false)
        {
            yield return new WaitForSeconds(1);
            player.gameObject.GetComponent<Player>().speed++;
        }
        else
        {
            StopCoroutine("Speedboost");
        }
    }
}
