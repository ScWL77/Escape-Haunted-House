using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupFlashlight : MonoBehaviour
{
    // inttext - the interaction text
    //flashlight_table - the flashlight on the table
    //flashlight_hand - the flashlight the player is holding
    //pickup sound - audio
    //bools - interactable- determine whether or not the player is looking at the flashlight and can pick it up

    public GameObject inttext, flashlight_table, flashlight_hand;
    public AudioSource pickup;
    public bool interactable;

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
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false);
                interactable = false;
                //pickup.Play();
                flashlight_hand.SetActive(true);
                flashlight_table.SetActive(false);
            }
        }
    }
}
