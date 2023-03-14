using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginningCutscene : MonoBehaviour
{
    //cutsceneCam - the cutscene object
    //player - the player object
    //float cutsceneTime - time cutscene runs for

    public GameObject cutsceneCam, player;
    public float cutsceneTime;
    void Start()
    {
        StartCoroutine(cutscene()); // a coroutine will start
    }
    IEnumerator cutscene() // in this coroutine after the amount of time the cutscene runs for, the cutscene camera will turn off and player will be turned on
    {
        yield return new WaitForSeconds(cutsceneTime);
        player.SetActive(true);
        cutsceneCam.SetActive(false);
    }

}
