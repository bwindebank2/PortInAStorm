using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            var player = FindObjectOfType<Player>().gameObject;
            StartCoroutine(player.GetComponent<Player>().Death());
        }

        if (other.gameObject.tag == ("Grabbable"))
        {
            Destroy(other.gameObject);
        }
    }
}
