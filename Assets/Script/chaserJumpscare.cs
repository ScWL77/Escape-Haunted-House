using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chaserJumpscare: MonoBehaviour
{
    public Animator chaserAnim; // the chaser's animator
    public GameObject player;  // the player object
    public AudioSource chaseSource;
    public float jumpscareTime; //the time it takes for the jumpscare to finish and go to the death scene
    public string sceneName; //the death scene's name

    void OnTriggerEnter(Collider other) //when player enters the chaser's jumpscare trigger, the player will be disabled and the animation will be played and take player to the death scene
    {
        if (other.CompareTag("Player"))
        {
            player.SetActive(false);
            chaseSource.enabled = false; // to stop the chase sound when the player is killed
            chaserAnim.SetTrigger("jumpscare");
            StartCoroutine(jumpscare());
        }
    }
    IEnumerator jumpscare() // take player to death scene after a few seconds in the jumpscareTime
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(sceneName); //load the death scene
    }
}
