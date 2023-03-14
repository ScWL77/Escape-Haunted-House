using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public string sceneName; //level 2's scene name
    public int levelNumber; // the level's number

    void OnTriggerEnter(Collider other) // when the player enters the trigger they will be taken to level 2 and the player pref will save the level number they are up to
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("level", levelNumber);
            PlayerPrefs.Save();
            SceneManager.LoadScene(sceneName);
        }
    }
}
