using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        SetCursor(0);
    }

    //public void LoadScene(string level)
    //{
    //    SceneManager.LoadScene(level);
    //}

    /// <summary>
    /// A function that changes cursor state,
    /// Mode 0 locks cursor,
    /// Mode 1 unlocks cursor
    /// </summary>
    /// <param name="mode"></param>
    public void SetCursor(int mode)
    {
        if (mode == 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (mode == 1)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void FadeIn()
    {
        var crossFade = FindObjectOfType<ScreenFade>();
        crossFade.FadeIn();
    }

    public void FadeOut()
    {
        var crossFade = FindObjectOfType<ScreenFade>();
        crossFade.FadeOut();
    }

}
