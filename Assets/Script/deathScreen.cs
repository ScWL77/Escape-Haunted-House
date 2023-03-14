using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreen : MonoBehaviour
{
    public string SceneName; //the menu scene's name
    public float waitTime; //the time it takes to go back to the main menu

    void Start() // take the player back to the main menu after a set amount of seconds in the waittime float
    {
        StartCoroutine(loadToMenu());
    }
    IEnumerator loadToMenu() //the coroutine
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneName);
    }
}
