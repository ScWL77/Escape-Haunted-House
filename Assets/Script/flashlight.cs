using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    //light - the flashlight light
    //toggle - determines whether flashlight is on or off
    //toggleSound - sound of flashlight turning on and off

        public GameObject light;
        public bool toggle;
        public AudioSource toggleSound;

        void Start()
        {
            if (toggle == false) 
            {
                light.SetActive(false); //turn off the flashlight light
            }
            if (toggle == true) 
            {
                light.SetActive(true); //turn on the flashlight light
            }
        }

        void Update() // when the player presses f toggle will be set to the opposite of what it currently is depending on whether its true or flase, the flashlight will be turned on or off
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                toggle = !toggle;
                toggleSound.Play();
                if (toggle == false)
                {
                    light.SetActive(false);
                }
                if (toggle == true)
                {
                    light.SetActive(true);
                }
            }
        }
}
