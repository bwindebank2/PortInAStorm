using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Sink(-2);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Sink(+2);
        }
    }

    private void Sink(int end)
    {
        //start is starting position, end it amount to move up or down from starting pos
        var startPos = gameObject.transform.position;
    }


}
