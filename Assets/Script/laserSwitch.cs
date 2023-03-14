using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserSwitch : MonoBehaviour
{
    public Animator switchAnim; //the switch animator
    public GameObject lasers, intText; //the lasers blocking the exit //the interaction text
    public bool interactable, toggle; // determines whether player is looking at the switch or not // determines whether player can interact with the switch or not

    void OnTriggerStay(Collider other) // if toggle is false and player is looking at switch, intText will be enabled and interactable equal true
    {
        if (other.CompareTag("MainCamera"))
        {
            if (toggle == false)
            {
                intText.SetActive(true);
                interactable = true;
            }
        }
    }
    void OnTriggerExit(Collider other) //if player looks away from the the switch, intText is disabled and interactable equals false
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    void Update() //if interactable is true and player presses E, switch animation will play and laser will disable
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switchAnim.SetTrigger("pull");
                lasers.SetActive(false);
                intText.SetActive(false);
                toggle = true;
                interactable = false;
            }
        }
    }
}
