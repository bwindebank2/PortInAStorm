using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public int endTime = 3;
    public int nextLevel;

    public AudioSource teleportSource;

    private void Start()
    {
        
        nextLevel = SceneManager.GetActiveScene().buildIndex +1;
        if (nextLevel >= SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // obtain reference to player
            // call load level function and pass index parameter
            teleportSource.Play();
            var player = FindObjectOfType<Player>().gameObject;
            StartCoroutine(player.GetComponent<Player>().LoadLevel(nextLevel));
        }
    }
}
