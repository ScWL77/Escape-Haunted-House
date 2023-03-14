using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{

    public GameObject inttext, light;        //intText - interaction text object //light - light object
    public bool toggle = true, interactable; // toggle - bool that determines whether the light is on or not 
                                             //interactable - bool that determines whether the light switch is being looked at by the player or not
    public Renderer lightBulb;               //lightBulb (the light bulb's renderer)
    public Material offlight, onlight;       //offlight - material of the light bulb when turned off //onlight - material of the light bulb when turned on
    public AudioSource lightSwitchSound;     //lightSwitchSound - light switch's audio source
    public Animator switchAnim;              //switchAnim - the light switch's animator
    public string animationName;

    void OnTriggerStay(Collider other) // if the player is looking at the light switch, the interaction text will turn on and the interactable bool will be set to true
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other) // if the player looks away from the light switch, the interaction text will turn off and the interactable bool will be set to false
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }
    void Update() // if the interactable bool is set to true, the player can press E to toggle the light switch
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                //lightSwitchSound.Play();
                switchAnim.Play(animationName);
                switchAnim.ResetTrigger("press");
                switchAnim.SetTrigger("press");
            }
        }
        if (toggle == false)
        {
            light.SetActive(false);
            lightBulb.material = offlight;
        }
        if (toggle == true)
        {
            light.SetActive(true);
            lightBulb.material = onlight;
        }
    }
}
