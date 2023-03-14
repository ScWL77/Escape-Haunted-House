using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chaserJumpscare1: MonoBehaviour
{
    public Animator chaserAnim; // the chaser's animator
    public GameObject player;  // the player object
    public float jumpscareTime; //the time it takes for the jumpscare to finish and go to the death scene
    public string sceneName; //the death scene's name
    public enemyMonsterAI monsterscript;

    void OnTriggerEnter(Collider other) //when player enters the chaser's jumpscare trigger, the player will be disabled and the animation will be played and take player to the death scene
    {
        if (other.CompareTag("Player"))
        {
            player.SetActive(false);
            monsterscript.enabled = false; // when the enemy gets the player, the enemy's AI will disable
            chaserAnim.ResetTrigger("idle");
            chaserAnim.ResetTrigger("walk");
            chaserAnim.ResetTrigger("run");
            chaserAnim.SetTrigger("jumpscare");
            StartCoroutine(jumpscare());
        }
    }
    IEnumerator jumpscare() // take player to death scene after a few seconds in the jumpscareTime
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(sceneName);
    }
}
