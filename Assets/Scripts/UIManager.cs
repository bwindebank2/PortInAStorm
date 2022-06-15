using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region variables
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private AudioSource pauseSFX;

    [SerializeField] private bool isPaused = false;
    [SerializeField] private bool isOptions = false;

    //[SerializeField] private int menuState;

    #region clips
    [SerializeField] private AudioClip fart1;
    [SerializeField] private AudioClip fart2;
    [SerializeField] private AudioClip fart3;
    [SerializeField] private AudioClip boing1;
    [SerializeField] private AudioClip boing2;
    [SerializeField] private AudioClip boing3;
    [SerializeField] private AudioClip boing4;
    #endregion

    [SerializeField] private int sfxIndex;

    #endregion

    #region functions
    public void Awake()
    {
        SetCursor();
        //pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        if(pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
        if(optionsMenu != null)
        {
            optionsMenu.SetActive(false);
        }
    }

    void Update()
    {
        // if you press the esc key and you're not on the main menu it cycles the menu state
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (isPaused == false)
            {
                MenuSwitch(2);
            }
            else
            {
                MenuSwitch(1);
            }
        }
    }

    /// <summary>
    /// Determines which menus to open depending on the menuState variable. When called it will switch the menus depending on what the variable is set to.
    /// 1 has no menu, 2 is pause menu, 3 is options menu.
    /// </summary>
    void MenuSwitch(float menuState)
    {
        switch(menuState)
        {
            case 1:
                // no menus open
                pauseMenu.SetActive(false);
                optionsMenu.SetActive(false);
                isPaused = false;
                Resume();
                Debug.Log("State 1");
                break;
            case 2:
                // pause menu open
                pauseMenu.SetActive(true);
                optionsMenu.SetActive(false);
                isPaused = true;
                Pause();
                Debug.Log("State 2");
                break;
            //case 3:
            //    // options menus open
            //    pauseMenu.SetActive(false);
            //    optionsMenu.SetActive(true);
            //    break;
        }

    }

    #region Pause Menu
    /// <summary>
    /// Pauses the game, freezing time
    /// </summary>
    private void Pause()
    {
        EnablePlayer(1);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        var gameManager = FindObjectOfType<GameManager>().gameObject;
        gameManager.GetComponent<GameManager>().SetCursor(1);
        PauseSFX();
        //pauseMenu.SetActive(!isPaused);
        //isPaused = !isPaused;
    }

    /// <summary>
    /// Selects a random funny sound for the pause menu
    /// </summary>
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

    /// <summary>
    /// Unpauses the game, unfreezing time
    /// </summary>
    public void Resume()
    {
        EnablePlayer(0);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        var gameManager = FindObjectOfType<GameManager>().gameObject;
        gameManager.GetComponent<GameManager>().SetCursor(0);
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

    #region main menu
    //public void PlayGame()
    //{
    //    var nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    //    if (nextLevel >= SceneManager.sceneCountInBuildSettings)
    //    {
    //        nextLevel = 1;
    //    }
    //    var player = FindObjectOfType<Player>().gameObject;
    //    StartCoroutine(player.GetComponent<Player>().LoadLevel(nextLevel));
    //}

    //public void OptionsMenu()
    //{
    //    optionsMenu.SetActive(true);
    //}
    #endregion
    void SetCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    /// <summary>
    /// Enable player can enable or disable the player. 0 Enables the player. 1 Disables the player.
    /// </summary>
    /// <param name="state"></param>
    private void EnablePlayer(float state)
    {
        var player = FindObjectOfType<Player>().gameObject;
        switch (state)
        {
            case 0:
                //player.GetComponent<CharacterController>().enabled = true;
                player.GetComponent<Player>().enabled = true;
                player.GetComponentInChildren<PlayerInteract>().enabled = true;
                // enable player movement
                // enable interaction
                // enable gun
                break;
            case 1:
                //player.GetComponent<CharacterController>().enabled = false;
                player.GetComponent<Player>().enabled = false;
                player.GetComponentInChildren<PlayerInteract>().enabled = false;
                // disable player movement
                // disable interaction
                // disable gun
                break;
        }

    }
    #endregion

    #endregion
}
