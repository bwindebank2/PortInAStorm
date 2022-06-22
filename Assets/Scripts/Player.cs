using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region Variables
    [SerializeField] private int endTime = 3;

    // Animation
    private Animator gunAnimator;

    // Audio
    [SerializeField] private AudioSource gunAudio;
    [SerializeField] private AudioSource playerAudio;
    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip bang;
    [SerializeField] private AudioClip reloadSFX;
    [SerializeField] private AudioClip deathScream;
    [SerializeField] private float minPitch = 0.8f;
    [SerializeField] private float maxPitch = 1.8f;

    // Gun Stuff
    [SerializeField] private Transform bulSpawn;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireRate;
    [SerializeField] private float bulSpeed = 10f;
    [SerializeField] private float timeSinceLastShot = 0.5f;
    [SerializeField] private float reloadSpeed = 2.5f;
    [SerializeField] public bool isGunHeld;
    [SerializeField] public bool reloading = false;
    [SerializeField] public int magazineFul;
    [SerializeField] public int magazineCap = 5;

    #endregion  

    private void Awake()
    {
        magazineFul = magazineCap;
        gunAnimator = GetComponent<Animator>();
        gunAnimator.SetBool("Reloading", false);
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && isGunHeld && reloading == false && timeSinceLastShot >= fireRate && magazineFul > 0)
        {
            Gun1();
        }
        else if(Input.GetMouseButtonDown(0) && isGunHeld && reloading == false && timeSinceLastShot >= fireRate && magazineFul <= 0)
        {
            gunAudio.PlayOneShot(click);
            timeSinceLastShot = 0;
        }

        if (Input.GetKeyDown(KeyCode.R) && isGunHeld && reloading == false)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        reloading = true;
        gunAudio.PlayOneShot(reloadSFX);
        gunAnimator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadSpeed);

        reloading = false;
        gunAnimator.SetBool("Reloading", false);
        magazineFul = magazineCap;
    }

    void Gun1()
    {
        GameObject clone;
        clone = Instantiate(bullet, bulSpawn.position, bulSpawn.rotation);
        clone.gameObject.GetComponentInChildren<Rigidbody>().velocity = bulSpawn.TransformDirection(Vector3.forward * bulSpeed);
        Destroy(clone, 2f);
        float setPitch = Random.Range(minPitch, maxPitch);
        gunAudio.pitch = setPitch;
        gunAudio.PlayOneShot(bang);
        timeSinceLastShot = 0f;
        magazineFul -= 1;
    }

    void Respawn()
    {
        // find respawn point
        // teleport player to respawn point

        var player = gameObject;
        var spawnPoint = respawnPoint.transform.position;
        player.transform.position = spawnPoint;
    }

    public IEnumerator Death()
    {
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.FadeOut();

        float setPitch = Random.Range(0.8f, 1.8f);
        playerAudio.pitch = setPitch;
        playerAudio.PlayOneShot(deathScream);

        yield return new WaitForSeconds(endTime);

        gameManager.FadeIn();
        Respawn();

        // display death UI

        // SceneManager.LoadScene(0);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Respawn")
        {
            respawnPoint = other.gameObject.transform;
        }
    }
}
