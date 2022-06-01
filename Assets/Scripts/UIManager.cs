using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void Awake()
    {
        SetCursor();
    }

    void SetCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
