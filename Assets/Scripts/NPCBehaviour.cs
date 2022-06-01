using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject textBox;

    [SerializeField] private bool isHidden = true;

    [SerializeField] private AudioClip speakingSFX;
    [SerializeField] private AudioSource npcAS;

    private void Start()
    {
        npcAS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textBox.SetActive(true);
            isHidden = false;
            npcAS.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textBox.SetActive(false);
            isHidden = true;

        }
    }
}
