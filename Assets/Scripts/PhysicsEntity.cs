using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEntity : MonoBehaviour
{
    [SerializeField] AudioClip colSFX;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.tag == "Ground" || collision != null && collision.gameObject.tag == "Projectile" || collision != null && collision.gameObject.tag == "Interactable" || collision != null && collision.gameObject.tag == "Entity" || collision != null && collision.gameObject.tag == "Player")
        {
            var Audio = GetComponent<AudioSource>();
            if (colSFX != null && Audio != null)
            {
                Audio.PlayOneShot(colSFX);
            }
        }
    }
}
