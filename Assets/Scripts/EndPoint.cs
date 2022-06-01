using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameEnd();
        }
    }

    private void GameEnd()
    {
        print("quit game");
        SceneManager.LoadScene("Menu");
    }
}
