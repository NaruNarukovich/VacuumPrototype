using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class Rope : MonoBehaviour
{
    ObiRope rope;
    ObiRopeCursor cursor;
    void Start()
    {
        cursor = GetComponentInChildren<ObiRopeCursor>();
        rope = cursor.GetComponent<ObiRope>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            cursor.ChangeLength(rope.restLength - 1f * Time.deltaTime);
        }
        
    }
}


