using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFloat : MonoBehaviour
{
    [SerializeField] private int upForce = 200;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, upForce, 0));
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 0));
    }
}
