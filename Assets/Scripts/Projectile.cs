using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject bulParticle;
    [SerializeField] private float projDamage = 15;

    private void OnCollisionEnter(Collision collision)
    {
        //GameObject clone = bulParticle;
        //Instantiate(clone, gameObject.transform);
        //Destroy(clone,0.5f);

        var other = collision.gameObject;
        if(other.gameObject.tag == "Entity")
        {
            if(other.GetComponent<Enemy>().health != 0)
            {
                other.gameObject.GetComponent<Enemy>().TakeDamage(projDamage);
            }
        }

        Destroy(this.gameObject);

    }
}
