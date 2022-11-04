using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLength : MonoBehaviour
{
    public bool errorHappened = true;
    GameObject player;
    GameObject vacuum;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            errorHappened = false;
            StartCoroutine("LengthBoost");

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            errorHappened = true;
        }
    }

    IEnumerator LengthBoost()
    {
        if (errorHappened == false)
        {
            yield return new WaitForSeconds(1);
            player.gameObject.GetComponent<Player>().distance++;
            vacuum.gameObject.GetComponent<LookAt>().distance++;
        }
        else
        {
            StopCoroutine("Lengthboost");
        }
    }
}
