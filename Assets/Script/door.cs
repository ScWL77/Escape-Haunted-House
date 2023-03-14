using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    //intText - the interaction text
    //bool interactable - determines if the door can be interacted with or not
    //toggle - determines if the door is open or closed
    //doorAnim - the door's animator
    //when the key is active, the door will be locked and the locked text will show up when the player tries to open it. If the key isnt active, the door can be interacted with as normal

    public GameObject intText,key,lockedText;
    public bool interactable, toggle;
    public Animator doorAnim;

    void OnTriggerStay(Collider other) //if the player is looking at the door, the inttext will be active and interactable will be set to true
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other) // if the player looks away from the door, the inttext will no longer be active and interactable will be set to false
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    void Update() // if the interactable is set to true and the player presses E, the door's toggle bool will be set to the opposite of what it currently is and will either open or close
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (key.active == false)
                {
                    toggle = !toggle;
                    if (toggle == true) //if door is close
                    {
                        doorAnim.ResetTrigger("close");
                        doorAnim.SetTrigger("open"); //activate the trigger parameter open to open the door
                    }
                    if (toggle == false) //if door is open
                    {
                        doorAnim.ResetTrigger("open");
                        doorAnim.SetTrigger("close"); //activate the trigger parameter close to close the door
                    }
                    intText.SetActive(false);
                    interactable = false;
                }
                if (key.active == true)
                {
                    lockedText.SetActive(true);
                    StopCoroutine("disableText");
                    StartCoroutine("disableText");
                }
            }
        }
    }

    IEnumerator disableText()
    {
        yield return new WaitForSeconds(2.0f);
        lockedText.SetActive(false);
    }
}
