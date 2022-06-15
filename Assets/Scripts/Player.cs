using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int endTime = 3;

    // Audio
    [SerializeField] private AudioSource GunSFX;


    // Gun Stuff
    [SerializeField] private Transform bulSpawn;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireRate;
    [SerializeField] private float bulSpeed;
    [SerializeField] private bool isGunHeld;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && isGunHeld)
        {
            Instantiate(bullet, bulSpawn);
            GunSFX.Play();
        }
    }

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
