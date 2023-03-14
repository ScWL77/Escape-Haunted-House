using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstepSounds : MonoBehaviour
{
    public AudioSource footstepswalk; //footstepwalk sound

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            footstepswalk.enabled = true;
        }
        else
        {
            footstepswalk.enabled = false;
        }
    }
}
