using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupKey : MonoBehaviour
{
    // inttext - the interaction text
    //key - the key
    //pickup sound - audio
    //bools - interactable- determine whether or not the player is looking at the key and can interact with it

    public GameObject inttext, key,spookystuff;
    public AudioSource pickup;
    public bool interactable,scaryEvent;

    void OnTriggerStay(Collider other) // when the player looks at the flashlight, the inttext will turn on and interactable will be set to true
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other) // when the player looks away from the flashlight, the inttext will turn off and interactable will be set to false
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }
    void Update() // if interactable is set true and player can press E to pickup the flashlight and it will be in their hands 
    //allow scary stuff to be enabled if scaryEvent = true and the key has been picked up
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false);
                interactable = false;
                pickup.Play();
                if(scaryEvent == true)
                {
                    spookystuff.SetActive(true);
                }
                key.SetActive(false);
            }
        }
    }
}
