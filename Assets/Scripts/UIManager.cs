using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private AudioSource pauseSFX;

    [SerializeField] private bool isPaused = false;

    [SerializeField] private AudioClip fart1;
    [SerializeField] private AudioClip fart2;
    [SerializeField] private AudioClip fart3;
    [SerializeField] private AudioClip boing1;
    [SerializeField] private AudioClip boing2;
    [SerializeField] private AudioClip boing3;
    [SerializeField] private AudioClip boing4;

    [SerializeField] private int sfxIndex;


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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            Pause();
        }

        if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            Resume();
        }
    }

    #region Pause Menu
    private void Pause()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        PauseSFX();
        Time.timeScale = 0;
        var gameManager = FindObjectOfType<GameManager>().gameObject;
        gameManager.GetComponent<GameManager>().SetCursor(1);
        //pauseMenu.SetActive(!isPaused);
        //isPaused = !isPaused;
    }

    public void PauseSFX()
    {
        sfxIndex = Random.Range(1, 7);
        
        if (sfxIndex == 1)
        {
            pauseSFX.PlayOneShot(fart1);
        }

        if (sfxIndex == 2)
        {
            pauseSFX.PlayOneShot(fart2);
        }

        if (sfxIndex == 3)
        {
            pauseSFX.PlayOneShot(fart3);
        }

        if (sfxIndex == 4)
        {
            pauseSFX.PlayOneShot(boing1);
        }

        if (sfxIndex == 5)
        {
            pauseSFX.PlayOneShot(boing2);
        }

        if (sfxIndex == 6)
        {
            pauseSFX.PlayOneShot(boing3);
        }
        
        if (sfxIndex == 7)
        {
            pauseSFX.PlayOneShot(boing4);
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        var gameManager = FindObjectOfType<GameManager>().gameObject;
        gameManager.GetComponent<GameManager>().SetCursor(0);
        isPaused = false;

        if (optionsMenu.activeSelf == true)
        {
            optionsMenu.SetActive(false);
        }
    }

    public void Settings()
    {
        // nothing yet
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
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
    #endregion

    
}
