using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaryEventTrigger : MonoBehaviour
{
    //scare - the object will do the scare
    //collision - the trigger's collider

    public GameObject scare;
    public AudioSource scareSound;
    public Collider collision;

    void OnTriggerEnter(Collider other) // when the player enters the trigger, the scare object will appear and the trigger's collider will disable
    {
        if (other.CompareTag("Player"))
        {
            scare.SetActive(true);
            //scareSound.Play();
            collision.enabled = false;
        }
    }
}
