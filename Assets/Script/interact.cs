using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interact : MonoBehaviour
{
    public bool interactable, toggle; //determine if player is looking at object and be interacted with, determines if the object has been interacted with or not
    public GameObject inttext, dialogue; //text that shows up when the object is interacted with,text that whos when player interacts with the object
    public string dialogueString; //the string that will be the dialogue text ("Just a painting")
    public Text dialogueText; // the text of the dialogue
    public float dialogueTime; // the amount of tiem the dialogue text shows up for

    void OnTriggerStay(Collider other) // if player is looking at the object and toggle == false which means object has not been interacted with, the inttext will show up and interactable will = true
    {
        if (other.CompareTag("MainCamera"))
        {
            if (toggle == false)
            {
                inttext.SetActive(true);
                interactable = true;
            }
        }
    }
    void OnTriggerExit(Collider other) // if player is looking away from the object, the inttext will go away and interactable will = false
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }
    void Update() // if interactable == true and player press E, the dialogue will show up and a coroutine will start to disable it in the wanted time. The string will also be applied to the text
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueText.text = dialogueString;
                dialogue.SetActive(true);
                inttext.SetActive(false);
                StartCoroutine(disableDialogue());
                toggle = true;
                interactable = false;
            }
        }
    }
    IEnumerator disableDialogue() // the dialogue will be turn off after the amount of time set in the dialogue time
    {
        yield return new WaitForSeconds(dialogueTime);
        dialogue.SetActive(false);
    }
}
