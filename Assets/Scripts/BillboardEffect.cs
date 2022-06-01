using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardEffect : MonoBehaviour
{
    public Transform camTransform;
    private Quaternion originalRotation;
    [SerializeField] private float damping = 1;

    void Start()
    {
        //originalRotation = transform.rotation;
    }

    void Update()
    {
        var lookPos = camTransform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

        //transform.rotation = camTransform.rotation.y * originalRotation.y;
    }

    //var lookPos = target.position - transform.position;
    //lookPos.y = 0;
    //var rotation = Quaternion.LookRotation(lookPos);
    //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime* damping);
}
