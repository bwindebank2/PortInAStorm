using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    //[SerializeField] private bool isPaused = false;

    public void Awake()
    {
        SetCursor();
        //pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        if(pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            var gameManager = FindObjectOfType<GameManager>().gameObject;
            gameManager.GetComponent<GameManager>().SetCursor(1);
            //pauseMenu.SetActive(!isPaused);
            //isPaused = !isPaused;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        var gameManager = FindObjectOfType<GameManager>().gameObject;
        gameManager.GetComponent<GameManager>().SetCursor(0);
    }

    public void Settings()
    {
        // nothing yet
        Debug.Log("Settings");
    }

    public void MainMenu()
    {
        //quit to main
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        var player = FindObjectOfType<Player>().gameObject;
        StartCoroutine(player.GetComponent<Player>().LoadLevel(0));
        Debug.Log("Quit to main");
    }

    public void QuitGame()
    {
        //quit to main
        Debug.Log("Quit to desktop");
        Application.Quit();
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

    void SetCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
