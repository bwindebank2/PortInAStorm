using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Trigger : MonoBehaviour
{
    public Material def;
    public Material trans;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            var mesh = gameObject.GetComponentInParent<MeshRenderer>();
            mesh.material = trans;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            var mesh = gameObject.GetComponentInParent<MeshRenderer>();
            mesh.material = def;
        }
    }
}
