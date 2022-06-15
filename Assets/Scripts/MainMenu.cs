using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    #region functions
    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && optionsMenu.activeSelf == true)
        {
            BackToMain();
        }
    }

    public void PlayGame()
    {
        var nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel >= SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 1;
        }
        var player = FindObjectOfType<Player>().gameObject;
        StartCoroutine(player.GetComponent<Player>().LoadLevel(nextLevel));
    }

    public void OptionsMenu()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void BackToMain()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    #endregion
}
