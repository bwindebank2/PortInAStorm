using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //check to see what player is looking at
    //check if it is interactable/grabbable
    //if it is we want to get prompt to pick it up
    //if we press key, item is picked up
    //the object is moves to the player's hand transform and is held there until dropped
    //player enters carrying state, item enters carried state
    //while carrying player cannot jump or pick up other objects
    //while being carried an object doesn't conform to physics
    //when pickup key is pressed while holding object, it is dropped
    //if throw key is pressed, it is thrown

    [SerializeField] private Transform hand;
    [SerializeField] private Transform world;
    [SerializeField] private int layerMask;

    [SerializeField] private GameObject heldObject;

    [SerializeField] private float throwForce = 50;
    [SerializeField] private float interactRange = 3;

    [SerializeField] private bool grabbing = false;
    
    [SerializeField] private Vector3 scalechange = new Vector3(0.5f, 0.5f, 0.5f);

    public void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * interactRange;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Input.GetMouseButtonDown(0))
        {
            //check for item, report item
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            layerMask = 1 << 7;
            if (Physics.Raycast(ray, out hit, interactRange, layerMask))
            {
                var target = hit.collider.gameObject;
                Debug.Log(target);

                if (target.tag == "Grabbable" && grabbing != true)
                { // pick it up
                    SetToHeld(target);
                    Debug.Log("Pick up the " + target);
                    grabbing = true;
                }
            }
        }

        void SetToHeld(GameObject target)
        {
            heldObject = target;
            Debug.Log(heldObject);
            //heldObject.GetComponent<Interactable>().Interact();
            heldObject.transform.SetParent(hand);
            heldObject.transform.position = hand.position;
            heldObject.transform.localScale = new Vector3(heldObject.transform.localScale.x / 2, heldObject.transform.localScale.y / 2, heldObject.transform.localScale.z / 2); //scalechange;
            heldObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (grabbing == true) // release held item
            {
                if (heldObject != null)
                {
                    heldObject.transform.SetParent(world);
                    heldObject.GetComponent<Rigidbody>().isKinematic = false;
                    heldObject.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
                    heldObject.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * throwForce);
                    heldObject.transform.localScale += new Vector3(heldObject.transform.localScale.x, heldObject.transform.localScale.y, heldObject.transform.localScale.z);
                    heldObject = null; // reset held item
                    grabbing = false;
                }
                else
                {
                    grabbing = false;
                }
                return;
            }
        }

        // int layerMask = 1 << 6;
        //layerMask = ~layerMask;
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10, layerMask))
        //{
        //    Destroy(hit.collider.gameObject);
        //}
        //else
        //{
        //    Debug.Log("Did not Hit");
        //}
    }
}
