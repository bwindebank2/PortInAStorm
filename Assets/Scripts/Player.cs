using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int endTime = 3;

    public IEnumerator Death()
    {
        print("quit game");

        var gameManager = FindObjectOfType<GameManager>();
        gameManager.FadeOut();

        yield return new WaitForSeconds(endTime);

        // display death UI

        SceneManager.LoadScene(0);
    }

    public IEnumerator LoadLevel(int levelindex)
    {
        print("quit game");

        var gameManager = FindObjectOfType<GameManager>();
        gameManager.FadeOut();

        yield return new WaitForSeconds(endTime);

        // display death UI

        SceneManager.LoadScene(levelindex);
    }
}
